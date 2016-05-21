
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using FoodTrade.Entity;
using FoodTrade.DAL;

namespace FoodTrade.BLL.Component
{
	public partial class SupplierProductBLL
	{
        public List<SupplierProductEntity> GetStocks(int ID = 0)
        {
            using (var context = new DatabaseContext())
            {
                return  (from sp in context.SupplierProducts
                        join sup in context.Suppliers on sp.SupplierID equals sup.ID
                        join prd in context.Products on sp.ProductID equals prd.ID
                        where sp.Status && (sp.ID== ID || ID==0)
                         orderby sup.Name, prd.Name
                        select new SupplierProductEntity() {
                            ID=sp.ID,
                            SupplierID=sp.SupplierID,
                            ProductID=sp.ProductID,
                            Stock=sp.Stock,
                            SRP=sp.SRP,
                            ProductName=prd.Name,
                            SupplierName=sup.Name,
                            Status = sp.Status,
                            CreatedBy=sp.CreatedBy,
                            CreatedDate=sp.CreatedDate,
                        }).ToList();
            }
        }
    }
}
