using APIClient;
using MathAPI.Interface;

namespace MathAPI.Class
{
    public class ConsumeAPI : IConsumeAPI
    {
        private readonly IAPIHttpClient _apiClient;

        public ConsumeAPI(IAPIHttpClient apiHttpClient)
        {
            _apiClient = apiHttpClient;
        }

        public async Task<T> GetDataAsync<T>(string url)
        {
            return await _apiClient.GetAsync<T>(url);
        }

        public async Task<T> SendDataAsync<T>(HttpMethod method, string url, HttpContent content)
        {
            return await _apiClient.SendAsync<T>(method, url, content);
        }
    }
}
