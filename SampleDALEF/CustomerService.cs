using SampleDALEF.DbContext;
using SampleDALEF.Models.Customer;
using SampleDALEF;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// 
/// </summary>
public class CustomerService : ICustomerService
{
    /// <summary>
    /// The context
    /// </summary>
    private readonly CentralDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerService"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public CustomerService(CentralDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets all customers asynchronous.
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    /// <summary>
    /// Gets the customer by identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    /// <summary>
    /// Adds the customer asynchronous.
    /// </summary>
    /// <param name="customer">The customer.</param>
    /// <returns></returns>
    public async Task<Customer> AddCustomerAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    /// <summary>
    /// Updates the customer asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="customer">The customer.</param>
    /// <returns></returns>
    public async Task<Customer> UpdateCustomerAsync(int id, Customer customer)
    {
        var existingCustomer = await _context.Customers.FindAsync(id);
        if (existingCustomer == null) return null;

        existingCustomer.Name = customer.Name;
        existingCustomer.Email = customer.Email;
        // Update other properties as needed

        _context.Customers.Update(existingCustomer);
        await _context.SaveChangesAsync();
        return existingCustomer;
    }

    /// <summary>
    /// Deletes the customer asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return false;

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return true;
    }
}
