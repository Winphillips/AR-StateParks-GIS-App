using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using arsp.Models;

namespace arsp.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // Enable logging for debugging purposes
            this.Database.SetCommandTimeout(150);
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Create a LoggerFactory for logging SQL queries
            var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

            // Use LoggerFactory to set the logging for this context
            optionsBuilder.UseLoggerFactory(loggerFactory);

            // Set the query tracking behavior here
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Visitors> Visitors { get; set; }
    }
}