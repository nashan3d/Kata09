using Kata09.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata09.Core.Context
{
    public interface IPriceSchemeDbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<PriceRule> PriceRules { get; set; }
    }
}
