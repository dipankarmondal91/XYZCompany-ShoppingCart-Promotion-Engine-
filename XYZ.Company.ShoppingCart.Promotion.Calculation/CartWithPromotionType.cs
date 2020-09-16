using System;
using System.Collections.Generic;
using System.Text;
using XYZCompany.ShoppingCart.Promotion.Data.types;

namespace XYZ.Company.ShoppingCart.Promotion.Calculation
{
    public class CartWithPromotionType
    {
        public Cart cart { get; set; }
        public PromotionTypes promotionType { get; set; }
    }
}
