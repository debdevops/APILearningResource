using APIClient;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.Text;
using MathAPI.Model;
using System.Reflection;
using MathAPI.Interface;

namespace MathAPI.Controllers
{
    public class ConsumeAPIController : ControllerBase
    {

        private readonly IConsumeAPI _consumeAPI;

        public ConsumeAPIController(IConsumeAPI consumeAPI)
        {
            _consumeAPI = consumeAPI;
        }

        [HttpGet]
        [Route("GetData")]
        [ActionName("GetData")]
        public async Task<IActionResult> GeteData(string url)
        {
            var result = await _consumeAPI.GetDataAsync<object>(url);
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

            var result = await _consumeAPI.SendDataAsync<MyResponseModel>(HttpMethod.Post, url, jsonContent);

            return Ok(result);
        }
    }
}
