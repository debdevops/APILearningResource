using System.Text.Json;

namespace APIClient
{
    /// <summary>
    ///  Http Client
    /// </summary>
    /// <seealso cref="APIClient.IAPIHttpClient" />
    public class APIHttpClient: IAPIHttpClient
    {
        /// <summary>
        /// The HTTP client wrapper
        /// </summary>
        private readonly IHttpClientWrapper _httpClientWrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="APIHttpClient"/> class.
        /// </summary>
        /// <param name="httpClientWrapper">The HTTP client wrapper.</param>
        public APIHttpClient(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClientWrapper.GetAsync(url);
            string responseData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<T>(responseData, options);
        }

        /// <summary>
        /// Sends the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
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
