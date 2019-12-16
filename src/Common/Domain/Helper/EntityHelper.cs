using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common.Domain.Helper
{
    public class EntityHelper
    {
        private static ConcurrentDictionary<string, List<PropertyInfo>> _mapsProperties = new ConcurrentDictionary<string, List<PropertyInfo>>();


        /// <summary>
        /// Get Properties List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<PropertyInfo> GetCachedPropertiesList<T>(T source) where T : class
        {
            if (source == null) return new List<PropertyInfo>();
            var className = source.GetType().Name;

            if (!_mapsProperties.ContainsKey(className))
            {
                _mapsProperties.TryAdd(className, GetPropertiesList(source.GetType()));
            }

            return _mapsProperties[className];
        }

        /// <summary>
        /// Get List of property
        /// </summary>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        public static List<PropertyInfo> GetPropertiesList<T>(T source) where T : class
        {
            var sourceProperties = source.GetType().GetProperties();



            var properties = (from s in sourceProperties
                              where s.CanRead &&
                                    s.CanWrite &&
                                    s.PropertyType.IsPublic &&
                                    s.PropertyType.IsArray == false &&
                                    (s.PropertyType.IsValueType ||
                                     s.PropertyType == typeof(string)
                                    )
                              select s).ToList();



            //get only array properties
            var arrayProperties = (from s in sourceProperties
                                   where s.CanRead &&
                                         s.CanWrite &&
                                         s.PropertyType.IsPublic &&
                                         s.PropertyType.IsArray
                                   select s).ToList();



            if (arrayProperties.Any())
                properties.AddRange(arrayProperties);



            return properties;
        }



        public static string ConvertToCommaSeparatedString(Array array)
        {
            string returnValue = string.Empty;



            if (array.GetType().GetElementType() == typeof(Int32))
            {
                returnValue = string.Join(",", (Int32[])array);
            }



            return returnValue;
        }

    }
}
