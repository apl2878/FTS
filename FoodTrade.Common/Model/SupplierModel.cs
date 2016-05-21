using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodTrade.Entity;
using FoodTrade.DAL;

namespace FoodTrade.Common.Model
{
    public class SupplierComModel : SupplierEntity
    {
        public static SupplierComModel MaptoModel(Supplier item)
        {
            if (item != null)
                return new SupplierComModel()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Address = item.Address,
                    Email = item.Email,
                    Contact = item.Contact,
                    Status = item.Status,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    ModifiedBy = item.ModifiedBy,
                    ModifiedDate = item.ModifiedDate
                };
            else
                return default(SupplierComModel);
        }
        public static SupplierComModel MaptoModel(SupplierEntity item)
        {
            if (item != null)
                return new SupplierComModel()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Address = item.Address,
                    Email = item.Email,
                    Contact = item.Contact,
                    Status = item.Status,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    ModifiedBy = item.ModifiedBy,
                    ModifiedDate = item.ModifiedDate
                };
            else
                return default(SupplierComModel);
        }
        public static SupplierEntity MaptoEntity(SupplierComModel item)
        {
            if (item != null)
                return new SupplierEntity()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Address = item.Address,
                    Email = item.Email,
                    Contact = item.Contact,
                    Status = item.Status,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    ModifiedBy = item.ModifiedBy,
                    ModifiedDate = item.ModifiedDate
                };
            else
                return new SupplierEntity();
        }
    }
}