using Kata09.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata09.Core
{
    public interface IProductPrice
    {
        Task<PriceRule> GetRulesForOneProductAsync(string productName);

        Task<decimal> GetProductPrice(string productName);
    }
}
