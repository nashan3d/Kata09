using Kata09.Core.Context;
using Kata09.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kata09.Infrastructure.Data
{
    public class PriceSchemeDbContext : DbContext ,IPriceSchemeDbContext

    {
        public DbSet<Product> Products { get; set; }

        public DbSet<PriceRule> PriceRules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Initial Catalog=PriceSchemeDB;Trusted_Connection=True;");
        }
    }
}

