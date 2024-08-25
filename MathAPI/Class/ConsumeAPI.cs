using APIClient;
using MathAPI.Interface;

namespace MathAPI.Class
{
    /// <summary>
    /// Consume API
    /// </summary>
    /// <seealso cref="MathAPI.Interface.IConsumeAPI" />
    public class ConsumeAPI : IConsumeAPI
    {
        /// <summary>
        /// The API client
        /// </summary>
        private readonly IAPIHttpClient _apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumeAPI"/> class.
        /// </summary>
        /// <param name="apiHttpClient">The API HTTP client.</param>
        public ConsumeAPI(IAPIHttpClient apiHttpClient)
        {
            _apiClient = apiHttpClient;
        }

        /// <summary>
        /// Gets the data asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<T> GetDataAsync<T>(string url)
        {
            return await _apiClient.GetAsync<T>(url);
        }

        /// <summary>
        /// Sends the data asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public async Task<T> SendDataAsync<T>(HttpMethod method, string url, HttpContent content)
        {
            return await _apiClient.SendAsync<T>(method, url, content);
        }
    }
}
