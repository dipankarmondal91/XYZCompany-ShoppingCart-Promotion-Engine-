using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using XYZ.Company.ShoppingCart.Promotion.Calculation;
using XYZ.Company.ShoppingCart.Promotion.Calculation.promotionstrategy;
using XYZCompany.ShoppingCart.Promotion.Data.Repository;
using XYZCompany.ShoppingCart.Promotion.Data.types;

namespace XYZCompany.ShoppingCart.Unit
{
    public class PromotionStrategyTest
    {
        private IPromotionStrategy promotionStrategy;
        private Promotion.Data.Repository.IQuery query;
        [SetUp]
        public void Setup()
        {
            //  promotionStrategy = new Query();
            query = new Query();
        }

        [Test]
        public void GetQuntityStrategyResult()
        {
            

            var cartList = new List<CartWithPromotionType>();
            cartList.Add(new CartWithPromotionType()
            {
                cart = new Cart()
                {
                    Quantity = 5,
                    SkuId = 'A'
                },
                promotionType = PromotionTypes.Quantity
            });
            promotionStrategy = new QuantityPromotion(query);
            var result = promotionStrategy.ApplyPromotion(cartList);
            Assert.AreEqual(230, result);
        }
        [Test]
        public void GetQuntityStrategyResultForOneItem()
        {
            var cartList = new List<CartWithPromotionType>();
            cartList.Add(new CartWithPromotionType()
            {
                cart = new Cart()
                {
                    Quantity = 1,
                    SkuId = 'A'
                },
                promotionType = PromotionTypes.Quantity
            });
            promotionStrategy = new QuantityPromotion(query);
            var result = promotionStrategy.ApplyPromotion(cartList);
            Assert.AreEqual(50, result);
        }
        [Test]
        public void GetComboStrategyResultOnlyFirtOfCombo()
        {
            var cartList = new List<CartWithPromotionType>();
            cartList.Add(new CartWithPromotionType()
            {
                cart = new Cart()
                {
                    Quantity = 1,
                    SkuId = 'C'
                },
                promotionType = PromotionTypes.Combo
            });
            promotionStrategy = new ComboPromotion(query);

           
            var result = promotionStrategy.ApplyPromotion(cartList);
            Assert.AreEqual(20, result);
        }
    }
}
