using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodTrade.BLL;
using FoodTrade.Entity;
using FoodTrade.Common;

namespace WebAPI2.Models
{
    public class StockModel
    {
        public int ID { get; set; }
        public string ProdName { get; set; }
        public string SupName { get; set; }
        public int ProdID { get; set; }
        public int SupID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CratedDate { get; set; }
        public static StockModel MapModel(SupplierProductEntity item)
        {
            if (item != null)
                return new StockModel()
                {
                    ID = item.ID,
                    ProdID = item.ProductID,
                    SupID = item.SupplierID,
                    ProdName = item.ProductName,
                    SupName = item.SupplierName,
                    Quantity = item.Stock,
                    Price = item.SRP,
                    Status = item.Status,
                    CreatedBy = item.CreatedBy,
                    CratedDate = item.CreatedDate,
                };
            else
                return new StockModel();
        }
        public static SupplierProductEntity MapEntity(StockModel item)
        {
            if (item != null)
                return new SupplierProductEntity()
                {
                    ID = item.ID,
                    SupplierID = item.SupID,
                    ProductID = item.ProdID,
                    Stock = item.Quantity,
                    SRP = item.Price,
                    Status = item.Status,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CratedDate,
                };
            else
                return new SupplierProductEntity();
        }
        public static List<StockModel> GetStocks(int ID=0)
        {
            return BusinessFacade.SupplierProduct
                .GetStocks(ID)
                .Select(o => MapModel(o)).ToList();   
        }
    }
}