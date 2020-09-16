using System;
using System.Collections.Generic;
using System.Text;
using XYZCompany.ShoppingCart.Promotion.Data.Models;

namespace XYZ.Company.ShoppingCart.Promotion.Calculation.promotionstrategy
{
    public class ComboPromotion : IPromotionStrategy
    {
        public ComboPromotionRule comboPromotionRule { get; set; }

        public ComboPromotion(List<char> combos, Sku sku, double promotionAmount)
        {
            Combos = combos;
            Sku = sku;
            PromotionAmount = promotionAmount;
        }
        public double ApplyPromotion(List<Cart> checkoutContent, int index)
        {
            //if(checkoutContent.Count -1 == index)
            //{
            //    return Sku.Price;
            //}
            //else
            //{
            var cartItem = checkoutContent[index];
            var nextComboItem = Combos.Find(x => x != Sku.Id);
            var nextComboIndex = checkoutContent.FindIndex(index, x => x.SkuId == nextComboItem);

            if (nextComboItem == -1)
            {
                return Sku.Price * cartItem.Quantity;
            }
            else
            {
                return 0;
            }

            //}


        }
    }
}
