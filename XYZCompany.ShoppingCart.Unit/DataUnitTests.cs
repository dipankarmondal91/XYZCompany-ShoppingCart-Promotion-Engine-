using NUnit.Framework;
using XYZCompany.ShoppingCart.Promotion.Data.Repository;
using XYZCompany.ShoppingCart.Promotion.Data.types;

namespace Tests
{
    public class DataUnitTests
    {
        private IQuery query;
        [SetUp]
        public void Setup()
        {
            query = new Query();
        }

        [Test]
        public void GetSkuList()
        {
            var result = query.GetSkus();
            Assert.AreEqual('A', result[0].Id);
            CollectionAssert.AllItemsAreNotNull(result);
        }

        
        [Test]
        public void GetPromotionCriterias()
        {
            var result = query.GetPromotion();
            CollectionAssert.AllItemsAreNotNull(result.Criterias);
        }
        [Test]
        public void GetQualityPromotionRules()
        {
            var result = query.GetQuantityPromotionRules();
            Assert.AreEqual(130, result['A'].PromotionAmount);
            
        }
        [Test]
        public void GetComboPromotionRules()
        {
            var result = query.GetComboPromotionRule();
            Assert.AreEqual(30, result.PromotionAmount);

        }
        [Test]
        public void GetPromotionPairs()
        {
            var result = query.GetSkuPromotionPairs();
            Assert.AreEqual(PromotionTypes.Quantity, result['A']);

        }
    }
}