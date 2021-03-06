//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Sonic.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrade.DAL
{
	[Table("SupplierProduct")]
	public partial class SupplierProduct
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public int SupplierID { get; set; }
		public int ProductID { get; set; }
		public int Stock { get; set; }
		public decimal SRP { get; set; }
		public bool Status { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public string ModifiedBy { get; set; }
		public Nullable<DateTime> ModifiedDate { get; set; }

		[ForeignKey("ProductID")]
		public virtual Product Product { get; set; }
		[ForeignKey("SupplierID")]
		public virtual Supplier Supplier { get; set; }
	}
}
