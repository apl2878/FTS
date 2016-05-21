
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FoodTrade.DAL
{
	public partial class DatabaseContext : DbContext
	{
		public DatabaseContext() : base("name=DatabaseContext")
		{
		}

		protected override void OnModelCreating(DbModelBuilder mb)
		{
			mb.Conventions.Remove<PluralizingTableNameConvention>();
		}

		public DbSet<Consumer> Consumers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<SupplierProduct> SupplierProducts { get; set; }
    }
}
