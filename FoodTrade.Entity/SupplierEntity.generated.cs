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

namespace FoodTrade.Entity
{
	public partial class SupplierEntity
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string Contact { get; set; }
		public bool Status { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public string ModifiedBy { get; set; }
		public Nullable<DateTime> ModifiedDate { get; set; }

		public virtual ICollection<SupplierProductEntity> SupplierProducts { get; set; }
	}
}
