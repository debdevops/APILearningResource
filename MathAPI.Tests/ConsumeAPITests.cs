using APIClient;
using MathAPI.Controllers;
using MathAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MathAPI.Tests
{
    [TestClass]
    public class ConsumeAPITests
    {
        private Mock<IAPIHttpClient> _mockApiClient;
        private ConsumeAPIController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockApiClient = new Mock<IAPIHttpClient>();
            _controller = new ConsumeAPIController(_mockApiClient.Object);
        }

        [TestMethod]
        public async Task GeteData_ReturnsOkResult_WithExpectedData()
        {
            // Arrange
            var url = "https://example.com/api/resource";
            var expectedResult = new { Id = 1, Name = "Test" };
            var responseString = JsonSerializer.Serialize(expectedResult);

            _mockApiClient.Setup(client => client.GetAsync<object>(url))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.GeteData(url) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            var resultValue = result.Value;
            Assert.AreEqual(responseString, JsonSerializer.Serialize(resultValue));
        }

        //[TestMethod]
        //public async Task SendData_ReturnsOkResult_WithExpectedResponse()
        //{
        //    // Arrange
        //    var requestModel = new MyRequestModel { body = "test", title = "test", userId = 1 };
        //    var expectedResult = new MyRequestModel { body = "test", title = "test", userId = 1 };
        //    var jsonContent = new StringContent(JsonSerializer.Serialize(requestModel), Encoding.UTF8, "application/json");
        //    var url = "https://jsonplaceholder.typicode.com/posts"; // Ensure this matches the URL used in SendData

        //    // Setup the mock to return expected result
        //    _mockApiClient.Setup(client => client.SendAsync<MyRequestModel>(HttpMethod.Post, url, jsonContent))
        //        .ReturnsAsync(expectedResult);

        //    // Act
        //    var result = await _controller.SendData(requestModel) as OkObjectResult;

        //    // Assert
        //    Assert.IsNotNull(result, "Result should not be null");
        //    Assert.AreEqual(200, result.StatusCode, "Status code should be 200 OK");

        //    var resultValue = result.Value as MyRequestModel;
        //    Assert.IsNotNull(resultValue, "Result value should not be null");
        //    Assert.AreEqual(expectedResult.body, resultValue.body, "Body values should be equal");
        //    Assert.AreEqual(expectedResult.title, resultValue.title, "Title values should be equal");
        //    Assert.AreEqual(expectedResult.userId, resultValue.userId, "UserId values should be equal");
        //}


    }
}
