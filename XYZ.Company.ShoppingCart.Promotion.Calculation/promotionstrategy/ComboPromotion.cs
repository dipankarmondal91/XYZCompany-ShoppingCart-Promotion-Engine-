using System;
using System.Collections.Generic;
using System.Text;
using XYZCompany.ShoppingCart.Promotion.Data.Models;
using XYZCompany.ShoppingCart.Promotion.Data.Repository;

namespace XYZ.Company.ShoppingCart.Promotion.Calculation.promotionstrategy
{
    public class ComboPromotion : IPromotionStrategy
    {
        private IQuery _query;

        public ComboPromotion(IQuery query)
        {
            _query = query;
        }
        public double ApplyPromotion(List<CartWithPromotionType> checkoutContent)
        {
            double result = 0;
            var qualifiedItems = checkoutContent.FindAll(x => x.promotionType == XYZCompany.ShoppingCart.Promotion.Data.types.PromotionTypes.Combo);
            var rule = _query.GetComboPromotionRule();
            var productList =_query.GetSkus();
            var comboFirstItemList = qualifiedItems.FindAll(x => x.cart.SkuId == rule.Combos[0]);
            var comboFirstItemCount = CountTotalQuantity(comboFirstItemList);
            var comboSecondItemList = qualifiedItems.FindAll(x => x.cart.SkuId == rule.Combos[1]);
            var comboSecondItemCount = CountTotalQuantity(comboSecondItemList);


            if (comboFirstItemCount == comboSecondItemCount)
            {
                result = comboFirstItemCount * rule.PromotionAmount;
            }else if(comboFirstItemCount < comboSecondItemCount)
            {
                result = (comboFirstItemCount * rule.PromotionAmount)
                    + ((comboSecondItemCount - comboFirstItemCount)) * (productList.Find(x => x.Id == rule.Combos[1]).Price);
            } else
            {
                result = (comboSecondItemCount * rule.PromotionAmount)
                    + ((comboFirstItemCount - comboSecondItemCount)) * (productList.Find(x => x.Id == rule.Combos[0]).Price);
            }


            return result;
        }
        private int CountTotalQuantity(List<CartWithPromotionType> comboCart)
        {
            int sum = 0;

            foreach (var item in comboCart)
            {
                sum += item.cart.Quantity;
            }

            return sum;
        }
    }
}
