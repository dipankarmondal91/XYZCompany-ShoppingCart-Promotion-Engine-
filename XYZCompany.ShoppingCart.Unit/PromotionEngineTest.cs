using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using XYZ.Company.ShoppingCart.Promotion.Calculation;
using XYZCompany.ShoppingCart.Promotion.Data.Models;
using XYZCompany.ShoppingCart.Promotion.Data.Repository;
using XYZCompany.ShoppingCart.Promotion.Data.types;

namespace XYZCompany.ShoppingCart.Unit
{
    public class PromotionEngineTest
    {
        private IQuery query;
        private Mock<IQuery> mockQuery;
        private PromotionEngine promotionEngine;
        private DataMocks dataMocks;
        [SetUp]
        public void Setup()
        {
            query = new Query();
            promotionEngine = new PromotionEngine(query);
            mockQuery = new Mock<IQuery>();
            dataMocks = new DataMocks();
        }
        [Test]
        public void CalculateTotalOrderAmount_Mock()
        {
            var cartItmes = new List<Cart>()
            {
                new Cart()
                {
                    Quantity = 1,
                    SkuId = 'A'
                },
                new Cart()
                {
                    Quantity = 1,
                    SkuId = 'B'
                },
                new Cart()
                {
                    Quantity = 1,
                    SkuId = 'C'
                }
            };
            mockQuery.Setup(x => x.GetQuantityPromotionRules()).Returns(dataMocks.GetQuantityPromotionRules());
            mockQuery.Setup(x => x.GetSkus()).Returns(dataMocks.GetSkus());
            mockQuery.Setup(x => x.GetComboPromotionRule()).Returns(dataMocks.GetComboPromotionRule());
            mockQuery.Setup(x => x.GetSkuPromotionPairs()).Returns(dataMocks.GetSkuPromotionPairs());
            var result = new PromotionEngine(mockQuery.Object).CalculateTotalOrderAmount(cartItmes);

            Assert.AreEqual(100, result);

        }
        [Test]
        public void CalculateTotalOrderAmount_Input1()
        {
            var cartItmes = new List<Cart>()
            {
                new Cart()
                {
                    Quantity = 1,
                    SkuId = 'A'
                },
                new Cart()
                {
                    Quantity = 1,
                    SkuId = 'B'
                },
                new Cart()
                {
                    Quantity = 1,
                    SkuId = 'C'
                }
            };

            var result = promotionEngine.CalculateTotalOrderAmount(cartItmes);

            Assert.AreEqual(100, result);
           
        }
        [Test]
        public void CalculateTotalOrderAmount_Input2()
        {
            var cartItmes = new List<Cart>()
            {
                new Cart()
                {
                    Quantity = 5,
                    SkuId = 'A'
                },
                new Cart()
                {
                    Quantity = 5,
                    SkuId = 'B'
                },
                new Cart()
                {
                    Quantity = 1,
                    SkuId = 'C'
                }
            };

            var result = promotionEngine.CalculateTotalOrderAmount(cartItmes);

            Assert.AreEqual(370, result);

        }
        [Test]
        public void CalculateTotalOrderAmount_Input3()
        {
            var cartItmes = new List<Cart>()
            {
                new Cart()
                {
                    Quantity = 3,
                    SkuId = 'A'
                },
                new Cart()
                {
                    Quantity = 5,
                    SkuId = 'B'
                },
                new Cart()
                {
                    Quantity = 1,
                    SkuId = 'C'
                },
                new Cart()
                {
                    Quantity = 1,
                    SkuId = 'D'
                }
            };

            var result = promotionEngine.CalculateTotalOrderAmount(cartItmes);

            Assert.AreEqual(280, result);

        }
        [Test]
        public void CalculateTotalOrderAmount_Input4()
        {
            var cartItmes = new List<Cart>()
            {
                new Cart()
                {
                    Quantity = 3,
                    SkuId = 'C'
                },
                new Cart()
                {
                    Quantity = 5,
                    SkuId = 'D'
                }
            };

            var result = promotionEngine.CalculateTotalOrderAmount(cartItmes);

            Assert.AreEqual(120, result);

        }
    
    }
}
