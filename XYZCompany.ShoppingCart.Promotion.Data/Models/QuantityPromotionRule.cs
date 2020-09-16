using System;
using System.Collections.Generic;
using System.Text;
using XYZCompany.ShoppingCart.Promotion.Data.types;

namespace XYZCompany.ShoppingCart.Promotion.Data.Models
{
    public class QuantityPromotionRule 
    {
        public int PromotionQuatity { get; set; }
        public double PromotionAmount { get; set; }
        public PromotionTypes PromotionType { get; set; }

    }
}
