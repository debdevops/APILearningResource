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

        #region Old code

        //private readonly HttpClient _httpClient;

        //public APIHttpClient(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        //public async Task<T> GetAsync<T>(string url)
        //{
        //    try
        //    {
        //        HttpResponseMessage response = await _httpClient.GetAsync(url);
        //        response.EnsureSuccessStatusCode();

        //        string responseData = await response.Content.ReadAsStringAsync();
        //        T Result = JsonSerializer.Deserialize<T>(responseData);

        //        return Result;
        //    }
        //    catch (HttpRequestException httpException)
        //    {
        //        throw new Exception($"Request error: {httpException.Message}");
        //    }
        //    catch (JsonException ex)
        //    {
        //        // Handle JSON deserialization errors
        //        throw new Exception($"Serialization error: {ex.Message}");
        //    }
        //    catch (Exception e)
        //    {
        //        // Handle other exceptions
        //        throw new Exception($"Unexpected error: {e.Message}");
        //    }

        //}

        //public async Task<T> SendAsync<T>(HttpMethod httpMethod, string url, HttpContent httpContent = null)
        //{
        //    try
        //    {
        //        var request = new HttpRequestMessage(httpMethod, url)
        //        {
        //            Content = httpContent
        //        };

        //        HttpResponseMessage response = await _httpClient.SendAsync(request);
        //        response.EnsureSuccessStatusCode();

        //        string responseData = await response.Content.ReadAsStringAsync();
        //        var options = new JsonSerializerOptions
        //        {
        //            PropertyNameCaseInsensitive = true
        //        };

        //        T Result = JsonSerializer.Deserialize<T>(responseData, options);

        //        return Result;
        //    }
        //    catch (HttpRequestException httpException)
        //    {
        //        throw new Exception($"Request error: {httpException.Message}");
        //    }
        //    catch (JsonException ex)
        //    {
        //        // Handle JSON deserialization errors
        //        throw new Exception($"Serialization error: {ex.Message}");
        //    }
        //    catch (Exception e)
        //    {
        //        // Handle other exceptions
        //        throw new Exception($"Unexpected error: {e.Message}");
        //    }
        //}

        #endregion
    }
}
