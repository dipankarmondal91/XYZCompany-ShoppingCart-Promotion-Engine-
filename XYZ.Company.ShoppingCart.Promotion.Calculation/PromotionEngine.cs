using System;
using System.Collections.Generic;
using System.Text;
using XYZ.Company.ShoppingCart.Promotion.Calculation.promotionstrategy;
using XYZCompany.ShoppingCart.Promotion.Data.Repository;

namespace XYZ.Company.ShoppingCart.Promotion.Calculation
{
    public class PromotionEngine
    {
        private readonly IQuery _query;
        public PromotionEngine( IQuery query)
        {
            _query = query;
        }

        public double CalculateTotalOrder(List<Cart> cartItems)
        {
            double result = 0;

            var cartWithPromotion = AllocatePromotions(cartItems);

            // quantity promotion
            IPromotionStrategy qunatityPromotion = new QuantityPromotion(_query);
            result += qunatityPromotion.ApplyPromotion(cartWithPromotion);

            // quantity promotion
            IPromotionStrategy comboPromotion = new ComboPromotion(_query);
            result += comboPromotion.ApplyPromotion(cartWithPromotion);

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
