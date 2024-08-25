using APIClient;
using MathAPI.Controllers;
using MathAPI.Interface;
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
        //private Mock<IAPIHttpClient> _mockApiClient;
        private ConsumeAPIController _controller;
        private Mock<IConsumeAPI> _mockConsumeAPI;

        [TestInitialize]
        public void Setup()
        {
           // _mockApiClient = new Mock<IAPIHttpClient>();
            _mockConsumeAPI = new Mock<IConsumeAPI>();
            _controller = new ConsumeAPIController(_mockConsumeAPI.Object);
        }

        [TestMethod]
        public async Task GeteData_ReturnsOkResult_WithExpectedData()
        {
            // Arrange
            var url = "https://example.com/api/resource";
            var expectedResult = new { Id = 1, Name = "Test" };
            var responseString = JsonSerializer.Serialize(expectedResult);

            _mockConsumeAPI.Setup(client => client.GetDataAsync<object>(url))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.GeteData(url) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            var resultValue = result.Value;
            Assert.AreEqual(responseString, JsonSerializer.Serialize(resultValue));
        }

        [TestMethod]
        public async Task SendData_ReturnsOkResult_WithExpectedResponse()
        {
            // Arrange
            var requestModel = new MyRequestModel { body = "test", title = "test", userId = 1 };
            var expectedResult = new MyResponseModel { body = "test", title = "test", userId = 1, id=101 };

            _mockConsumeAPI.Setup(client => client.SendDataAsync<MyResponseModel>(
                HttpMethod.Post,
                It.IsAny<string>(),
                It.IsAny<HttpContent>()))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.SendData(requestModel) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result, "Expected OkObjectResult but got null.");
            Assert.AreEqual(200, result.StatusCode);

            var resultValue = result.Value as MyResponseModel;
            Assert.IsNotNull(resultValue, "Expected MyRequestModel result but got null.");
            Assert.AreEqual(expectedResult.body, resultValue.body);
            Assert.AreEqual(expectedResult.title, resultValue.title);
            Assert.AreEqual(expectedResult.userId, resultValue.userId);
        }
    }
}
