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
using System.Data.Linq;
using System.Linq;
using FoodTrade.Entity;
using FoodTrade.DAL;

namespace FoodTrade.BLL.Component
{
	public partial class ProductBLL
	{
		public void Create(ProductEntity item)
		{
			using (var context = new DatabaseContext())
			{
				var e = new Product();
				e.Name = item.Name;
				e.Description = item.Description;
				e.MSRP = item.MSRP;
				e.Status = item.Status;
				e.CreatedBy = item.CreatedBy;
				e.CreatedDate = item.CreatedDate;
				e.ModifiedBy = item.ModifiedBy;
				e.ModifiedDate = item.ModifiedDate;
				context.Products.Add(e);
				context.SaveChanges();

				item.ID = e.ID;
			}
		}

		public void Update(ProductEntity item)
		{
			using (var context = new DatabaseContext())
			{
				var e = context.Products.SingleOrDefault(o => o.ID == item.ID);

				if (e != null)
				{
					e.Name = item.Name;
					e.Description = item.Description;
					e.MSRP = item.MSRP;
					e.Status = item.Status;
					e.CreatedBy = item.CreatedBy;
					e.CreatedDate = item.CreatedDate;
					e.ModifiedBy = item.ModifiedBy;
					e.ModifiedDate = item.ModifiedDate;
					context.SaveChanges();
				}
			}
		}

		public void Delete(int id)
		{
			using (var context = new DatabaseContext())
			{
				var e = context.Products.SingleOrDefault(o => o.ID == id);

				if (e != null)
				{
					context.Products.Remove(e);
					context.SaveChanges();
				}
			}
		}

		public ProductEntity Get(int id)
		{
			using (var context = new DatabaseContext())
			{
				var item = context.Products.SingleOrDefault(o => o.ID == id);

				if (item != null)
				{
					return MapFields(item);
				}

				return null;
			}
		}

		public List<ProductEntity> GetAll()
		{
			using (var context = new DatabaseContext())
			{
				var items = context.Products.Where(o => 1 == 1);
				var models = new List<ProductEntity>();

				foreach (var item in items)
				{
					models.Add(MapFields(item));
				}

				return models;
			}
		}

		public static ProductEntity MapFields(Product item)
		{
			return new ProductEntity
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
		}

	}
}
