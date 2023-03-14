using ClassLibrary1.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
        }

        public DbSet<Company>? Companies { get; set; }

        public DbSet<Tenant>? Tenants { get; set; }

        public DbSet<SaleTransaction> SaleTransactions { get; set; }

        public DbSet<SaleItems> SaleItems { get; set; }

        public DbSet<SaleRequest> SaleRequests { get; set; }

        public DbSet<SaleTransactionDetails> SaleTransactionDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
