namespace MathAPI.Interface
{
    /// <summary>
    /// Interface for Consume API
    /// </summary>
    public interface IConsumeAPI
    {
        /// <summary>
        /// Gets the data asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        Task<T> GetDataAsync<T>(string url);
        /// <summary>
        /// Sends the data asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        Task<T> SendDataAsync<T>(HttpMethod method, string url, HttpContent content);
    }
}
