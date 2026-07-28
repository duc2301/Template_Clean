using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DbContexts
{
    public class ProductSaleDbContext : DbContext
    {
        protected ProductSaleDbContext()
        {
        }

        public ProductSaleDbContext(DbContextOptions<ProductSaleDbContext> options, IConfiguration configuration) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }

    }
}
