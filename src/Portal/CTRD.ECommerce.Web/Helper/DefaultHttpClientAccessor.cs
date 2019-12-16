using CTRD.ECommerce.Web.Interfaces;
using System.Net.Http;

namespace CTRD.ECommerce.Web.Helper
{
    public class DefaultHttpClientAccessor : IHttpClientAccessor
    {
        public HttpClient Client { get; }

        public DefaultHttpClientAccessor()
        {
            Client = new HttpClient();
        }
    }
}
