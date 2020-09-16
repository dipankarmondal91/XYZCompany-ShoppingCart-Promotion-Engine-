using NUnit.Framework;
using XYZCompany.ShoppingCart.Promotion.Data.Repository;

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
    }
}