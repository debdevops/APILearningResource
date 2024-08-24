using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClient
{
    public interface IAPIHttpClient
    {
        Task<T> GetAsync<T>(string url);
        Task<T> SendAsync<T>(HttpMethod method, string url, HttpContent content = null);
    }
}
