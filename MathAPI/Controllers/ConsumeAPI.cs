using APIClient;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.Text;
using MathAPI.Model;
using System.Reflection;

namespace MathAPI.Controllers
{
    public class ConsumeAPIController : ControllerBase
    {

        private readonly IAPIHttpClient _apiClient;

        public ConsumeAPIController(IAPIHttpClient apiHttpClient)
        {
            _apiClient = apiHttpClient;
        }

        [HttpGet]
        [Route("GetData")]
        [ActionName("GetData")]
        public async Task<IActionResult> GeteData(string url)
        {
            var result = await _apiClient.GetAsync<object>(url);
            return Ok(result);
        }

        [HttpPost]
        [ActionName("SendData")]
        [Route("SendData")]
        public async Task<IActionResult> SendData([FromBody] MyRequestModel myRequestModel)
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            // Serialize the request model to JSON
            var jsonContent = new StringContent(JsonSerializer.Serialize(myRequestModel), Encoding.UTF8, "application/json");

            var result = await _apiClient.SendAsync<MyRequestModel>(HttpMethod.Post, url, jsonContent);

            return Ok(result);
        }
    }
}
