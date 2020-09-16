using System;
using System.Collections.Generic;
using System.Text;
using XYZ.Company.ShoppingCart.Promotion.Calculation.promotionstrategy;
using XYZCompany.ShoppingCart.Promotion.Data.Repository;

namespace XYZ.Company.ShoppingCart.Promotion.Calculation
{
    public class PromotionEngine
    {
        private readonly IPromotionStrategy _promotionStrategy;
        private readonly IQuery _query;
        public PromotionEngine(IPromotionStrategy promotionStrategy, IQuery query)
        {
            _promotionStrategy = promotionStrategy;
            _query = query;
        }

        public double CalculateTotalOrder(List<Cart> cartItems)
        {
            var result = 0;

            var cartWithPromotion = AllocatePromotions(cartItems);



            return result;
        }

        private List<CartWithPromotionType> AllocatePromotions(List<Cart> cartItems)
        {
            var cartWithPromotionType = new List<CartWithPromotionType>();

            var promotionPairs = _query.GetSkuPromotionPairs();

            foreach (var item in cartItems)
            {
                cartWithPromotionType.Add(new CartWithPromotionType()
                {
                    cart = item,
                    promotionType = promotionPairs[item.SkuId]
                });
            }

            return cartWithPromotionType;
        }
    }

}
