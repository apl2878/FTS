using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodTrade.Entity;
using FoodTrade.DAL;

namespace FoodTrade.Common.Model
{
    public class ProductComModel : ProductEntity
    {
        public static ProductComModel MaptoModel(Product item)
        {
            if (item != null)
                return new ProductComModel()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Description = item.Description,
                    MSRP = item.MSRP,
                    Status = item.Status,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    ModifiedBy = item.ModifiedBy,
                    ModifiedDate = item.ModifiedDate
                };
            else
                return default(ProductComModel);
        }
        public static ProductComModel MaptoModel(ProductEntity item)
        {
            if (item != null)
                return new ProductComModel()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Description = item.Description,
                    MSRP = item.MSRP,
                    Status = item.Status,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    ModifiedBy = item.ModifiedBy,
                    ModifiedDate = item.ModifiedDate
                };
            else
                return default(ProductComModel);
        }
        public static ProductEntity MaptoEntity(ProductComModel item)
        {
            if (item != null)
                return new ProductEntity()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Description = item.Description,
                    MSRP = item.MSRP,
                    Status = item.Status,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    ModifiedBy = item.ModifiedBy,
                    ModifiedDate = item.ModifiedDate
                };
            else
                return new ProductEntity();
        }

    }
}