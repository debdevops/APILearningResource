using SampleDALEF.Models.Customer;
using SampleDALEF.Models.Order;
using SampleDALEF.Repository;

namespace SampleDALEF
{
    /// <summary>
    /// Interface for Unit of Work
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork: IDisposable
    {
        /// <summary>
        /// Gets the customers.
        /// </summary>
        /// <value>
        /// The customers.
        /// </value>
        IRepository<Customer> Customers { get; }
        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
        IRepository<Order> Orders { get; }
        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}
