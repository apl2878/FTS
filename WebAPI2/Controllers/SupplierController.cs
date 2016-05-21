using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FoodTrade.DAL;
using FoodTrade.Common.Model;
using FoodTrade.BLL;

namespace WebAPI2.Controllers
{
    public class SupplierController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Supplier
        public HttpResponseMessage GetSupplierEntities()
        {
            var data = BusinessFacade.Supplier.GetAll().Select(o => SupplierComModel.MaptoModel(o));
            if (data != null)
                return Request.CreateResponse(HttpStatusCode.OK, data);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // GET: api/Supplier/5
        [ResponseType(typeof(SupplierComModel))]
        public HttpResponseMessage GetSupplierComModel(int id)
        {
            SupplierComModel supplierModel = SupplierComModel.MaptoModel(BusinessFacade.Supplier.Get(id));
            if (supplierModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, supplierModel);
        }

        // PUT: api/Supplier/5
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutSupplierComModel(int id, SupplierComModel data)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (id != data.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var tempdata = SupplierComModel.MaptoEntity(data);
            tempdata.ModifiedBy = "user";
            tempdata.ModifiedDate = DateTime.Today;

            try
            {
                BusinessFacade.Supplier.Update(tempdata);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierComModelExists(id))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    throw;
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        // POST: api/Supplier
        [ResponseType(typeof(SupplierComModel))]
        public HttpResponseMessage PostSupplierComModel(SupplierComModel data)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var tempdata = SupplierComModel.MaptoEntity(data);
            tempdata.CreatedBy = "user";
            tempdata.CreatedDate = DateTime.Today;
            BusinessFacade.Supplier.Create(tempdata);

            return Request.CreateResponse(HttpStatusCode.OK, tempdata.ID);

        }

        // DELETE: api/Supplier/5
        [ResponseType(typeof(SupplierComModel))]
        public HttpResponseMessage DeleteSupplierComModel(int id)
        {
            BusinessFacade.Supplier.Delete(id);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupplierComModelExists(int id)
        {
            return db.Suppliers.Count(e => e.ID == id) > 0;
        }
    }
}