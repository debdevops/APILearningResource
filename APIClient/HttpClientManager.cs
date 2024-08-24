using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClient
{
    public class HttpClientManager : IHttpClientWrapper
    {
        private readonly HttpClient _httpClient;

        public HttpClientManager(HttpClient httpClient)
        {
               httpClient = _httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public Task<HttpResponseMessage> GetAsync(string requestUri)
        {
           var result = _httpClient.GetAsync(requestUri);
            return result;
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            var result = _httpClient.SendAsync(request);
            return result;
        }
    }
}
