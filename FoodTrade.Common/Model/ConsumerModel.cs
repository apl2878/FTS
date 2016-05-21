using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodTrade.Entity;
using FoodTrade.DAL;

namespace FoodTrade.Common.Model
{
    public class ConsumerComModel : ConsumerEntity
    {
        public static ConsumerComModel MaptoModel(Consumer item)
        {
            if (item != null)
                return new ConsumerComModel()
                {
                    ID = item.ID,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Team = item.Team,
                    Email = item.Email,
                    Contact = item.Contact,
                    Status = item.Status,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    ModifiedBy = item.ModifiedBy,
                    ModifiedDate = item.ModifiedDate
                };
            else
                return default(ConsumerComModel);
        }
        public static ConsumerComModel MaptoModel(ConsumerEntity item)
        {
            if (item != null)
                return new ConsumerComModel()
                {
                    ID = item.ID,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Team = item.Team,
                    Email = item.Email,
                    Contact = item.Contact,
                    Status = item.Status,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    ModifiedBy = item.ModifiedBy,
                    ModifiedDate = item.ModifiedDate
                };
            else
                return default(ConsumerComModel);
        }
        public static ConsumerEntity MaptoEntity(ConsumerComModel item)
        {
            if (item != null)
                return new ConsumerEntity()
                {
                    ID = item.ID,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Team = item.Team,
                    Email = item.Email,
                    Contact = item.Contact,
                    Status = item.Status,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    ModifiedBy = item.ModifiedBy,
                    ModifiedDate = item.ModifiedDate
                };
            else
                return new ConsumerEntity();
        }
    }
}