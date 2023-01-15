using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kata09.Core.Extensions
{
    public static class PriceCalculationExtension
    {
        public static int FindProductCountInTheTransaction(this string productName,List<string> productList)
        {
             return productList.Where(x => x == productName).Count();
        }


    }
}
