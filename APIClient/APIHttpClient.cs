using System.Text.Json;

namespace APIClient
{
    public class APIHttpClient: IAPIHttpClient
    {
        private readonly IHttpClientWrapper _httpClientWrapper;

        public APIHttpClient(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClientWrapper.GetAsync(url);
            string responseData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<T>(responseData, options);
        }

        public async Task<T> SendAsync<T>(HttpMethod method, string url, HttpContent content = null)
        {
            var request = new HttpRequestMessage(method, url)
            {
                Content = content
            };

            HttpResponseMessage response = await _httpClientWrapper.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string responseData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<T>(responseData, options);
        }

        
    }
}
