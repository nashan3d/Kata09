using Kata09.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata09.Core
{
    public interface IPriceManager
    {
        //Task<decimal> CalculatePriceForOneProduct(ProductDto product);

        Task<decimal> CalculatePriceForAllProdcuts(List<ProductDto> products);
    }
}
