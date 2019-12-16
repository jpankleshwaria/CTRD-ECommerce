using System.Net.Http;

namespace CTRD.ECommerce.Api.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHttpClientAccessor
    {
        /// <summary>
        /// 
        /// </summary>
        HttpClient Client { get; }
    }
}
