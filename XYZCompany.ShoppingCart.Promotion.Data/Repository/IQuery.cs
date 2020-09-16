using System;
using System.Collections.Generic;
using System.Text;
using XYZCompany.ShoppingCart.Promotion.Data;
using XYZCompany.ShoppingCart.Promotion.Data.Models;

namespace XYZCompany.ShoppingCart.Promotion.Data.Repository
{
    public interface IQuery
    {
        List<Models.Sku> GetSkus();
        Models.Promotion GetPromotion();

        Dictionary<char, QuantityPromotionRule> GetQuantityPromotionRules();
        ComboPromotionRule GetComboPromotionRules();
    }
}
