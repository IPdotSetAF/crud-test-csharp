using Entities.Configurations;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer>? Contributors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ConfigureCompositeKeys();
            //builder.ConfigureOnDeleteCascade();
            ////builder.DisableOnDeleteCascade();

            builder.ApplyConfiguration(new CustomerConfiguration());

            //builder.SeedTestData();

            base.OnModelCreating(builder);
        }
    }
}
