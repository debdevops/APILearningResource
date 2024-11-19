using Microsoft.EntityFrameworkCore;
using SampleDALEF.DbContext;
using SampleDALEF.Models.Customer;
using SampleDALEF.Models.Order;
using SampleDALEF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDALEF
{
    /// <summary>
    /// Unit of work class
    /// </summary>
    /// <seealso cref="SampleDALEF.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {

        /// <summary>
        /// The central database context
        /// </summary>
        private readonly CentralDbContext _centralDbContext;
        /// <summary>
        /// The customer
        /// </summary>
        private Repository<Customer> _customer;
        /// <summary>
        /// The order
        /// </summary>
        private Repository<Order> _order;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="centralDbContext">The central database context.</param>
        public UnitOfWork(CentralDbContext centralDbContext)
        {
            _centralDbContext = centralDbContext;
        }

        /// <summary>
        /// Gets the customers.
        /// </summary>
        /// <value>
        /// The customers.
        /// </value>
        public IRepository<Customer> Customers => _customer ??= new Repository<Customer>(_centralDbContext);
        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
        public IRepository<Order> Orders => _order ??= new Repository<Order>(_centralDbContext);

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await _centralDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _centralDbContext.Dispose();
        }
    }
}
