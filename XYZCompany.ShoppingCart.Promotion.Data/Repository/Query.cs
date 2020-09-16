using System;
using System.Collections.Generic;
using System.Text;
using XYZCompany.ShoppingCart.Promotion.Data.Models;
using XYZCompany.ShoppingCart.Promotion.Data.types;

namespace XYZCompany.ShoppingCart.Promotion.Data.Repository
{
    public class Query : IQuery
    {
        public ComboPromotionRule GetComboPromotionRule()
        {
            return new ComboPromotionRule()
            {
                Combos = new List<char>() { 'C', 'D' },
                PromotionAmount = 30
            };
        }

        public Models.Promotion GetPromotion()
        {
            var promotion = new Models.Promotion();

            promotion.Criterias = new List<string>(){ "3 of A's for 130", "2 of B's for 45", "C & D for 30"};

            return promotion;
        }

        public Dictionary<char, QuantityPromotionRule> GetQuantityPromotionRules()
        {
            var rule = new Dictionary<char, QuantityPromotionRule>();

            rule.Add('A', new QuantityPromotionRule()
            {
                PromotionAmount = 130,
                PromotionQuatity = 3
            });
            rule.Add('B', new QuantityPromotionRule()
            {
                PromotionAmount = 45,
                PromotionQuatity = 2
            });

            return rule;
        }

        public Dictionary<char, PromotionTypes> GetSkuPromotionPairs()
        {
            var promotionPairs = new Dictionary<char, PromotionTypes>();

            promotionPairs.Add('A', PromotionTypes.Quantity);
            promotionPairs.Add('B', PromotionTypes.Quantity);
            promotionPairs.Add('C', PromotionTypes.Combo);
            promotionPairs.Add('D', PromotionTypes.Combo);

            return promotionPairs;
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
