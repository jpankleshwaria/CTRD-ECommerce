using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Common.Domain.Attributes;
using Common.Domain.Constants;

namespace Common.Domain.Helper
{
    public static class SqlHelper
    {
        public static IList<SqlParameter> ConvertToParmeters<T>(T query) where T : class
        {
            var parameters = new List<SqlParameter>();
            foreach (var property in EntityHelper.GetCachedPropertiesList<T>(query))
            {
                if (property.PropertyType == typeof(string))
                {
                    string currentValue = (string)property.GetValue(query, null);
                    property.SetValue(query, currentValue != null ? currentValue.Trim() : null, null);
                }
                var para = new SqlParameter(string.Format("@{0}", property.Name), property.GetValue(query, null) ?? DBNull.Value);
                parameters.Add(para);
            }
            return parameters;
        }

        public static string GetParmeters(object query)
        {
            string para = string.Join(",", EntityHelper.GetCachedPropertiesList(query).Select(p => " @" + p.Name).ToArray());

            return para;
        }

        public static List<T> FromDBSql<T>(this DbQuery<T> query, string storedProcName, object request) where T : class
        {
            var parameters = ConvertToParmeters(request);
            return query.FromSql(storedProcName, parameters.ToArray()).ToList();

        }
        public static List<T> FromDBSql<T>(this DbContext context, string storedProcName, object request) where T : class
        {
            var parameters = ConvertToParmeters(request);
            return context.Query<T>().FromSql(storedProcName, parameters.ToArray()).ToList();

        }


        public static Task<List<T>> FromDBSqlAsync<T>(this DbContext context, string storedProcName, object request) where T : class
        {
            var parameters = ConvertToParmeters(request);
            return context.Query<T>().FromSql(storedProcName, parameters.ToArray()).ToListAsync();
        }

        public static T FromDBSqlToObject<T>(this DbContext context, string storedProcName, object request) where T : class
        {
            var parameters = ConvertToParmeters(request);
            return context.Query<T>().FromSql(storedProcName, parameters.ToArray()).FirstOrDefault<T>();

        }

        /// <summary>
        /// implemented to handle multiple result set STORE PROCEDURE, 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="mapEntities">mapping function to iterate reader, reader.next will move to the next result set data</param>
        /// <param name="exec"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static T ExecuteReader<T>(this DbContext context, Func<DbDataReader, T> mapEntities, string storedProcName, object request)
        {
            var parameters = ConvertToParmeters(request);
            var conn = context.Database.GetDbConnection();
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = storedProcName;
                    command.Parameters.AddRange(parameters.ToArray());
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            T data = mapEntities(reader);
                            return data;
                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public static DynamicParameters GetDynamicParmeters<T>(object query) where T : class
        {
            var parameters = new DynamicParameters();
                       
            var propertyList = EntityHelper.GetPropertiesList(query);
                       
            foreach (PropertyInfo property in propertyList)
            {
                if (property.PropertyType == typeof(string))
                {
                    string currentValue = (string)property.GetValue(query, null);
                    property.SetValue(query, currentValue != null ? currentValue.Trim() : null, null);
                }

                var paramAttribute = property.GetCustomAttribute<DbParamAttribute>();
                if (paramAttribute != null)
                {
                    if (paramAttribute.Ignore)
                        continue;
                                       
                    var paramValue = property.GetValue(query, null);

                    
                    switch (paramAttribute.Direction)
                    {
                        case ParamDirection.Output:
                            parameters.Add(string.Format("@{0}", property.Name), paramValue, null, System.Data.ParameterDirection.Output);
                            break;
                    }
                                       
                    if (paramAttribute.ConvertToCommaSeparated && property.PropertyType.BaseType == typeof(Array))
                    {
                        parameters.Add(string.Format("@{0}", property.Name),
                            EntityHelper.ConvertToCommaSeparatedString((Array)paramValue), null);
                    }
                }
                else
                {
                    parameters.Add(string.Format("@{0}", property.Name), property.GetValue(query, null) ?? null);
                }
            }
            return parameters;
        }
    }
}
