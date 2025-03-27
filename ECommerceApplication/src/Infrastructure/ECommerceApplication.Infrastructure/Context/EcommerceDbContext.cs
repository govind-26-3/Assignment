using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Domain;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Infrastructure.Context
{
    internal class EcommerceDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

    }
}
