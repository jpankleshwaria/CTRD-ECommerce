using System.Net.Http;

namespace CTRD.ECommerce.Web.Interfaces
{
    public interface IHttpClientAccessor
    {
        HttpClient Client { get; }
    }
}
