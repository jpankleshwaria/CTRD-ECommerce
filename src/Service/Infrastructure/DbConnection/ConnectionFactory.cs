using System.Data;
using System.Data.SqlClient;
using Common.Domain.Constants;
using CTRD.ECommerce.Infrastructure.Interfaces;

namespace CTRD.ECommerce.Infrastructure.DbConnection
{
    public class ConnectionFactory : IConnectionFactory
    {
        private IDbConnection connection = null;

        public IDbConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(Constants.CspDbConnectionString);
            }
            return connection;
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
    }
}
