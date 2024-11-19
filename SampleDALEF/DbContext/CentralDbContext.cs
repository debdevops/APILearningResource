﻿using Microsoft.EntityFrameworkCore;
using SampleDALEF.Models.Customer;
using SampleDALEF.Models.Order;

namespace SampleDALEF.DbContext
{
    /// <summary>
    /// DbConext
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class CentralDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CentralDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public CentralDbContext(DbContextOptions<CentralDbContext> options) :base(options)  { }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        /// <value>
        /// The customers.
        /// </value>
        public DbSet<Customer> Customers { get; set; }
        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// <para>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run. However, it will still run when creating a compiled model.
        /// </para>
        /// <para>
        /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information and
        /// examples.
        /// </para>
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API configurations if needed
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Order>().ToTable("Orders");
        }


    }
}
