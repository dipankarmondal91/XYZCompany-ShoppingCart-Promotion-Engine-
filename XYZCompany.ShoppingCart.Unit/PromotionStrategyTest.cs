using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using XYZ.Company.ShoppingCart.Promotion.Calculation;
using XYZ.Company.ShoppingCart.Promotion.Calculation.promotionstrategy;

namespace XYZCompany.ShoppingCart.Unit
{
    public class PromotionStrategyTest
    {
        private IPromotionStrategy promotionStrategy;
        [SetUp]
        public void Setup()
        {
           //  promotionStrategy = new Query();
        }

        [Test]
        public void GetQuntityStrategyResult()
        {
            promotionStrategy = new QuantityPromotion(3, new Promotion.Data.Models.Sku() { Id = 'A', Price = 50 }, 150);

            var cartList = new List<Cart>();
            cartList.Add(new Cart()
            {
                Quantity = 5,
                SkuId = 'A'
            });
            var result = promotionStrategy.ApplyPromotion(cartList, 0);
            Assert.AreEqual(250, result);
        }
        [Test]
        public void GetQuntityStrategyResultForOneItem()
        {
            promotionStrategy = new QuantityPromotion(3, new Promotion.Data.Models.Sku() { Id = 'A', Price = 50 }, 150);

            var cartList = new List<Cart>();
            cartList.Add(new Cart()
            {
                Quantity = 1,
                SkuId = 'A'
            });
            var result = promotionStrategy.ApplyPromotion(cartList, 0);
            Assert.AreEqual(50, result);
        }
        [Test]
        public void GetComboStrategyResultOnlyFirtOfCombo()
        {
            promotionStrategy = new ComboPromotion(new List<char>() { 'C', 'D' }, new Promotion.Data.Models.Sku() { Id = 'C', Price = 50 }, 60);

            var cartList = new List<Cart>();
            cartList.Add(new Cart()
            {
                Quantity = 1,
                SkuId = 'C'
            });
            var result = promotionStrategy.ApplyPromotion(cartList, 0);
            Assert.AreEqual(250, result);
        }
    }
}
