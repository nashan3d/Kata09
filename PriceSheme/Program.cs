using Kata09.Core;
using Kata09.Core.BusinessLOgic;
using Kata09.Core.Context;
using Kata09.Core.Dtos;
using Kata09.Infrastructure.Data;

namespace PriceSheme
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            IPriceSchemeDbContext _dbContext = new PriceSchemeDbContext();
            IPriceManager priceManager = new PriceManager(_dbContext);

            string productList = "AADCACCA"; //245

            var productsInTransaction = productList.Select(x => new ProductDto
            {
                Name = x.ToString(),
            }).ToList();
            
            var totalBilledAmount = await priceManager.CalculatePriceForAllProdcuts(productsInTransaction);

            Console.WriteLine("Total bill", totalBilledAmount);

            Console.ReadLine();
        }
    }
}