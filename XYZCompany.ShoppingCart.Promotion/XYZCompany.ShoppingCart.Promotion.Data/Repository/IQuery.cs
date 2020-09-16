using System;
using System.Collections.Generic;
using System.Text;
using XYZCompany.ShoppingCart.Promotion.Data.Models;

namespace XYZCompany.ShoppingCart.Promotion.Data.Repository
{
    public interface IQuery
    {
        List<Sku> GetSkus();
    }
}
