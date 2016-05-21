using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodTrade.Entity;
using FoodTrade.DAL;

namespace FoodTrade.Common.Model
{
    public class SupplierProductComModel : SupplierProductEntity
    {
        public static SupplierProductComModel MaptoModel(SupplierProduct item)
        {
            if (item != null)
                return new SupplierProductComModel()
                {
                    ID = item.ID,
                    SupplierID = item.SupplierID,
                    ProductID = item.ProductID,
                    Stock = item.Stock,
                    SRP = item.SRP,
                    Status = item.Status,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    ModifiedBy = item.ModifiedBy,
                    ModifiedDate = item.ModifiedDate
                };
            else
                return default(SupplierProductComModel);
        }
        public static SupplierProductComModel MaptoModel(SupplierProductEntity item)
        {
            if (item != null)
                return new SupplierProductComModel()
                {
                    ID = item.ID,
                    SupplierID = item.SupplierID,
                    ProductID = item.ProductID,
                    Stock = item.Stock,
                    SRP = item.SRP,
                    Status = item.Status,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    ModifiedBy = item.ModifiedBy,
                    ModifiedDate = item.ModifiedDate
                };
            else
                return default(SupplierProductComModel);
        }
        public static SupplierProductEntity MaptoEntity(SupplierProductComModel item)
        {
            if (item != null)
                return new SupplierProductEntity()
                {
                    ID = item.ID,
                    SupplierID = item.SupplierID,
                    ProductID = item.ProductID,
                    Stock = item.Stock,
                    SRP = item.SRP,
                    Status = item.Status,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    ModifiedBy = item.ModifiedBy,
                    ModifiedDate = item.ModifiedDate
                };
            else
                return new SupplierProductEntity();
        }

    }
}