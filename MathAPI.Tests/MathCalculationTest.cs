using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using MathAPI.Controllers;
using MathAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MathAPI.Tests
{
    [TestClass]
    public class MathControllerTests
    {
        private Mock<IMathCalculations> _mockMathCalculations;
        private MathController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockMathCalculations = new Mock<IMathCalculations>();
            _controller = new MathController(_mockMathCalculations.Object);
        }

        [TestMethod]
        public async Task Add_Returns_OkResult_With_CorrectSum()
        {
            // Arrange
            int x = 3, y = 4;
            _mockMathCalculations.Setup(mc => mc.AddIntegerAsync(x, y)).ReturnsAsync(x + y);

            // Act
            var result = await _controller.Add(x, y);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(x + y, okResult.Value);
        }

        [TestMethod]
        public async Task Subtraction_Returns_OkResult_With_CorrectDifference()
        {
            // Arrange
            int x = 10, y = 4;
            _mockMathCalculations.Setup(mc => mc.SubtarctionAsync(x, y)).ReturnsAsync(x - y);

            // Act
            var result = await _controller.Substraction(x, y);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(x - y, okResult.Value);
        }

        [TestMethod]
        public async Task Multiplication_Returns_OkResult_With_CorrectProduct()
        {
            // Arrange
            int x = 3, y = 4;
            _mockMathCalculations.Setup(mc => mc.MultiplicationAsync(x, y)).ReturnsAsync(x * y);

            // Act
            var result = await _controller.Multiplication(x, y);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(x * y, okResult.Value);
        }

        [TestMethod]
        public async Task Divide_Returns_OkResult_With_CorrectQuotient()
        {
            // Arrange
            int x = 8, y = 2;
            _mockMathCalculations.Setup(mc => mc.DivideAsync(x, y)).ReturnsAsync(x / y);

            // Act
            var result = await _controller.Divide(x, y);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(x / y, okResult.Value);
        }

        //[TestMethod]
        //public async Task Divide_Returns_BadRequest_On_DivideByZero()
        //{
        //    // Arrange
        //    int x = 8, y = 0;
        //    _mockMathCalculations.Setup(mc => mc.DivideAsync(x, y))
        //        .ThrowsAsync(new DivideByZeroException());

        //    // Act
        //    var result = await _controller.Divide(x, y);

        //    // Assert
        //    var badRequestResult = result as BadRequestObjectResult;
        //    Assert.IsNotNull(badRequestResult);
        //    Assert.AreEqual("Attempted to divide by zero.", badRequestResult.Value);
        //}
    }
}
