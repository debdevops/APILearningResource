namespace MathAPI.Interface
{
    public interface IConsumeAPI
    {
        Task<T> GetDataAsync<T>(string url);
        Task<T> SendDataAsync<T>(HttpMethod method, string url, HttpContent content);
    }
}
