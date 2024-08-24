using MathAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MathAPI.Controllers
{
    public class MathController : ControllerBase
    {
        private readonly IMathCalculations _mathCalculations;
        public MathController(IMathCalculations mathCalculation) 
        {
                _mathCalculations = mathCalculation;
        }

        [HttpGet]
        [ActionName("AddNumbers")]
        [Route("Add")]
        public async Task<IActionResult> Add(int x, int y)
        {
            var result = await _mathCalculations.AddIntegerAsync(x, y);
            return Ok(result);
        }

        [HttpGet]
        [ActionName("AddNumbers")]
        [Route("Substraction")]
        public async Task<IActionResult> Substraction(int x, int y)
        {
            var result = await _mathCalculations.SubtarctionAsync(x, y);
            return Ok(result);
        }

        [HttpGet]
        [ActionName("Multiplication")]
        [Route("Multiplication")]
        public async Task<IActionResult> Multiplication(int x, int y)
        {
            var result = await _mathCalculations.MultiplicationAsync(x, y);
            return Ok(result);
        }

        [HttpGet]
        [ActionName("Divide")]
        [Route("Divide")]
        public async Task<IActionResult> Divide(int x, int y)
        {
            try
            {
                var result = await _mathCalculations.DivideAsync(x, y);
                return Ok(result);
            }
            catch (DivideByZeroException)
            {
                return BadRequest("Cannot divide by zero.");
            }
            
        }
    }
}
