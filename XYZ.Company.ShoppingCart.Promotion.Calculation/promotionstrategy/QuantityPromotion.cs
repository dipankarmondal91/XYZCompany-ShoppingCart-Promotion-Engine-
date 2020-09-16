using System;
using System.Collections.Generic;
using System.Text;
using XYZCompany.ShoppingCart.Promotion.Data.Models;

namespace XYZ.Company.ShoppingCart.Promotion.Calculation.promotionstrategy
{
    public class QuantityPromotion : IPromotionStrategy
    {
        public int PromotionQuatity { get; set; }

        public Sku Sku { get; set; }

        public double PromotionAmount { get; set; }


        public QuantityPromotion(int promotionQuatity, Sku sku, double promotionAmount)
        {
            PromotionQuatity = promotionQuatity;
            Sku = sku;
            PromotionAmount = promotionAmount;
        }
        public double ApplyPromotion(List<Cart> checkoutContent, int index)
        {
            double result = 0;

            var cartItem = checkoutContent[index];

            result = ((cartItem.Quantity / PromotionQuatity) * PromotionAmount) + ((cartItem.Quantity % PromotionQuatity) * Sku.Price);

            return result;
        }
    }
}
