using CTRD.ECommerce.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CTRD.ECommerce.Api.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultHttpClientAccessor : IHttpClientAccessor
    {
        /// <summary>
        /// 
        /// </summary>
        public HttpClient Client { get; }

        /// <summary>
        /// 
        /// </summary>
        public DefaultHttpClientAccessor()
        {
            Client = new HttpClient();
        }
    }
}
