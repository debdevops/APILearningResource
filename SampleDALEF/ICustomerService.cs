using SampleDALEF.Models.Customer;

namespace SampleDALEF
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Gets all customers asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        /// <summary>
        /// Gets the customer by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Customer> GetCustomerByIdAsync(int id);
        /// <summary>
        /// Adds the customer asynchronous.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        Task<Customer> AddCustomerAsync(Customer customer);
        /// <summary>
        /// Updates the customer asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        Task<Customer> UpdateCustomerAsync(int id, Customer customer);
        /// <summary>
        /// Deletes the customer asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<bool> DeleteCustomerAsync(int id);
    }
}
