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
using WebAPI2.Models;

namespace WebAPI2.Controllers
{
    public class SupplierProductController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/SupplierProduct
        public HttpResponseMessage GetSupplierProductEntities()
        {
            var data = StockModel.GetStocks();
            if (data != null)
                return Request.CreateResponse(HttpStatusCode.OK, data);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);

        }

        // GET: api/SupplierProduct/5
        [ResponseType(typeof(SupplierProductComModel))]
        public HttpResponseMessage GetSupplierProductComModel(int id)
        {
            StockModel SupplierProduct = StockModel.GetStocks(id).SingleOrDefault();
            if (SupplierProduct == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, SupplierProduct);
        }

        // PUT: api/SupplierProduct/5
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutSupplierProductComModel(int id, StockModel data)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (id != data.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var tempdata = StockModel.MapEntity(data);//SupplierProductComModel.MaptoEntity(data);
            tempdata.ModifiedBy = "user";
            tempdata.ModifiedDate = DateTime.Today;

            try
            {
                BusinessFacade.SupplierProduct.Update(tempdata);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierProductComModelExists(id))
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

        // POST: api/SupplierProduct
        [ResponseType(typeof(SupplierProductComModel))]
        public HttpResponseMessage PostSupplierProductComModel(StockModel data)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var tempdata = StockModel.MapEntity(data);//SupplierProductComModel.MaptoEntity(data);
            tempdata.CreatedBy = "user";
            tempdata.CreatedDate = DateTime.Today;
            BusinessFacade.SupplierProduct.Create(tempdata);

            return Request.CreateResponse(HttpStatusCode.OK, tempdata.ID);
        }

        // DELETE: api/SupplierProduct/5
        [ResponseType(typeof(SupplierProductComModel))]
        public HttpResponseMessage DeleteSupplierProductComModel(int id)
        {
            BusinessFacade.SupplierProduct.Delete(id);
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

        private bool SupplierProductComModelExists(int id)
        {
            return db.SupplierProducts.Count(e => e.ID == id) > 0;
        }
    }
}