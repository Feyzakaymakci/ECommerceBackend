using ECommerceBackend.Domain.Entities;
using ECommerceBackend.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Persistence.Contexts
{
    public class ECommerceDbContext:DbContext
    {
      public ECommerceDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customer { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.Entries<BaseEntity>();
            return base.SaveChangesAsync(cancellationToken);
        } 
        //Repository gidip bak hangi savechanges olduğuna.

    }
}
