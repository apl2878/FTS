using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodTrade.Common.Model;

namespace WebAPI2.Models
{
    public class SupplierModel : SupplierComModel
    {
        // For API Specific Implementation

        public List<ProductModel> SupplierProduct { get; set; }
    }
}