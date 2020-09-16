using System;
using System.Collections.Generic;
using System.Text;
using XYZCompany.ShoppingCart.Promotion.Data.Models;

namespace XYZCompany.ShoppingCart.Promotion.Data.Repository
{
    public class Query : IQuery
    {
        public Models.Promotion GetPromotion()
        {
            var promotion = new Models.Promotion();

            promotion.Criterias = new List<string>(){ "3 of A's for 130", "2 of B's for 45", "C & D for 30"};

            return promotion;
        }

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
