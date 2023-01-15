using Kata09.Core.Context;
using Kata09.Core.Dtos;
using Kata09.Domain.Entities;
using Kata09.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata09.Core.BusinessLOgic
{
    public class PriceManager  : IPriceManager, IProductPrice
    {
        private readonly IPriceSchemeDbContext _dbContext;

        public PriceManager(IPriceSchemeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<decimal> CalculatePriceForAllProdcuts(List<ProductDto> products)
        {
            decimal totalPrice = 0;

            var groups = products.GroupBy(x => x.Name);

            foreach (var group in groups)
            {
                totalPrice += await CalculatePriceForOneProduct(group.Key,group.Count());

            }

            return totalPrice;
        }       

        public async Task<PriceRule> GetRulesForOneProductAsync(string productName)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Name == productName);
            var priceRule = _dbContext.PriceRules.Where(x => x.ProductId == product.Id).FirstOrDefault();

            return priceRule;
        }


        public async Task<decimal> GetProductPrice(string productName)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Name == productName);
            return product.UnitPrice;
        }


        private async Task<decimal> CalculatePriceForOneProduct(string productName, int productPurchasedQty)
        {
            decimal calculatedPrice = 0;

            try
            {
                var priceRule = await GetRulesForOneProductAsync(productName);
                var productDefaultPrice = await GetProductPrice(productName);

                if(priceRule!= null)
                {
                    if (productPurchasedQty >= priceRule.MinimumDiscountUnitQty)
                    {
                        switch (priceRule.DiscountType)
                        {
                            case DiscountType.FreeProduct:
                                var maxFreeProductQty = (productPurchasedQty / priceRule.MinimumDiscountUnitQty);
                                calculatedPrice = (productPurchasedQty - maxFreeProductQty*priceRule.DiscountUnitQty) * productDefaultPrice;
                                break;
                            case DiscountType.PriceDiscount:
                                calculatedPrice = priceRule.DiscountUnitPrice * productPurchasedQty;
                                break;
                        }
                    }
                    else
                    {
                        calculatedPrice = productPurchasedQty * productDefaultPrice;
                    }
                }
                else
                {
                    calculatedPrice = productPurchasedQty * productDefaultPrice;
                }                

                return calculatedPrice;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
