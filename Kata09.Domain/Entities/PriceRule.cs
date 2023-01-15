using Kata09.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata09.Domain.Entities
{
    public class PriceRule
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int DiscountUnitQty { get; set; }

        public decimal DiscountUnitPrice { get; set; }

        public int MinimumDiscountUnitQty { get; set; }

        public string RuleDescription { get; set; }

        public DateTime ApplicableDateStart { get; set; }

        public DateTime ApplicableDateEnd { get; set; }

        public DiscountType DiscountType { get; set; }

        public virtual Product Product { get; set; }
    }
}
