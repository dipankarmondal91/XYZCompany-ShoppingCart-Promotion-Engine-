using System;
using System.Collections.Generic;
using System.Text;
using XYZCompany.ShoppingCart.Promotion.Data.Models;
using XYZCompany.ShoppingCart.Promotion.Data.Repository;

namespace XYZ.Company.ShoppingCart.Promotion.Calculation.promotionstrategy
{
    public class ComboPromotion : IPromotionStrategy
    {
      //  private ComboPromotionRule ComboPromotionRule { get; set; }
        private IQuery _query;

        public ComboPromotion(IQuery query)
        {
           // ComboPromotionRule = comboPromotionRule;
            _query = query;
        }
        public double ApplyPromotion(List<CartWithPromotionType> checkoutContent)
        {
            double result = 0;
            var qualifiedItems = checkoutContent.FindAll(x => x.promotionType == XYZCompany.ShoppingCart.Promotion.Data.types.PromotionTypes.Combo);
            var rule = _query.GetComboPromotionRules();
            var productList =_query.GetSkus();
            var comboFirstItemCount = qualifiedItems.FindAll(x => x.cart.SkuId == rule.Combos[0]).Count;
            var comboSecondItemCount = qualifiedItems.FindAll(x => x.cart.SkuId == rule.Combos[1]).Count;

            
            if(comboFirstItemCount == comboSecondItemCount)
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
    }
}
