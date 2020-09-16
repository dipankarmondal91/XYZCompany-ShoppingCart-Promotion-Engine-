using System;
using System.Collections.Generic;
using System.Text;
using XYZCompany.ShoppingCart.Promotion.Data.Models;
using XYZCompany.ShoppingCart.Promotion.Data.Repository;

namespace XYZ.Company.ShoppingCart.Promotion.Calculation.promotionstrategy
{
    public class QuantityPromotion : IPromotionStrategy
    {
        private IQuery _query;


        public QuantityPromotion(IQuery query)
        {
            _query = query;
        }
        public double ApplyPromotion(List<CartWithPromotionType> checkoutContent)
        {
            double result = 0;
            var qualifiedItems = checkoutContent.FindAll(x => x.promotionType == XYZCompany.ShoppingCart.Promotion.Data.types.PromotionTypes.Quantity);
            var rules = _query.GetQuantityPromotionRules();
            var productList = _query.GetSkus();

            foreach (var item in qualifiedItems)
            {
                var ruleForItem = rules[item.cart.SkuId];
                result += ((item.cart.Quantity / ruleForItem.PromotionQuatity) * ruleForItem.PromotionAmount) +
                    ((item.cart.Quantity % ruleForItem.PromotionQuatity) * productList.Find(x => x.Id == item.cart.SkuId).Price);

            }


            return result;
        }
    }
}
