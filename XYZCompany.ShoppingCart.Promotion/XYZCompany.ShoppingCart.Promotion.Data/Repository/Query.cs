using System;
using System.Collections.Generic;
using System.Text;
using XYZCompany.ShoppingCart.Promotion.Data.Models;

namespace XYZCompany.ShoppingCart.Promotion.Data.Repository
{
    public class Query : IQuery
    {
        public List<Sku> GetSkus()
        {
            var skuList = new List<Sku>();

            skuList.Add(new Sku()
            {
                Id = 'A',
                Price = 50
            });

            skuList.Add(new Sku()
            {
                Id = 'B',
                Price = 30
            });

            skuList.Add(new Sku()
            {
                Id = 'C',
                Price = 20
            });

            skuList.Add(new Sku()
            {
                Id = 'D',
                Price = 15
            });

            return skuList;
        }
    }
}
