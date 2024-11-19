using Microsoft.AspNetCore.Mvc;
using SampleDALEF.Models.Customer;
using SampleDALEF;

namespace MathAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdCustomer = await _customerService.AddCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.Id }, createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedCustomer = await _customerService.UpdateCustomerAsync(id, customer);
            if (updatedCustomer == null) return NotFound();
            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var isDeleted = await _customerService.DeleteCustomerAsync(id);
            if (!isDeleted) return NotFound();
            return NoContent();
        }
    }

}
