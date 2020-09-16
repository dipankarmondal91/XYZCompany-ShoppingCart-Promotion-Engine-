using System;
using System.Collections.Generic;
using System.Text;
using XYZCompany.ShoppingCart.Promotion.Data.Models;

namespace XYZ.Company.ShoppingCart.Promotion.Calculation.promotionstrategy
{
    public interface IPromotionStrategy
    {
        double ApplyPromotion(List<Cart> checkoutContent, int index);
    }
}
