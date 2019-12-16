using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTRD.ECommerce.Infrastructure.Interfaces
{
    public interface IConnectionFactory : IDisposable
    {
        IDbConnection GetConnection();
    }
}
