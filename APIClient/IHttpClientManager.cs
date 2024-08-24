using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClient
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}
