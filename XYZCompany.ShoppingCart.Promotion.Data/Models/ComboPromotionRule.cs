using System;
using System.Collections.Generic;
using System.Text;
using XYZCompany.ShoppingCart.Promotion.Data.types;

namespace XYZCompany.ShoppingCart.Promotion.Data.Models
{
    public class ComboPromotionRule
    {
        public List<char> Combos { get; set; }
        public double PromotionAmount { get; set; }

        public PromotionTypes PromotionType { get; set; }

    }
}
