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
using FoodTrade.BLL;
using FoodTrade.DAL;
using FoodTrade.Common.Model;

namespace WebAPI2.Controllers
{
    public class ProductController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Product
        public HttpResponseMessage GetProductEntities()
        {
            var data = BusinessFacade.Product.GetAll().Select(o => ProductComModel.MaptoModel(o));

            if (data != null)
                return Request.CreateResponse(HttpStatusCode.OK, data);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // GET: api/Product/5
        [ResponseType(typeof(ProductComModel))]
        public HttpResponseMessage GetProductModel(int id)
        {
            ProductComModel productModel = ProductComModel.MaptoModel(BusinessFacade.Product.Get(id));
            if (productModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, productModel);
        }

        // PUT: api/Product/5
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutProductModel(int id, ProductComModel data)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (id != data.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var tempdata = ProductComModel.MaptoEntity(data);
            tempdata.ModifiedBy = "user";
            tempdata.ModifiedDate = DateTime.Today;

            try
            {
                BusinessFacade.Product.Update(tempdata);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelExists(id))
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

        // POST: api/Product
        [ResponseType(typeof(ProductComModel))]
        public HttpResponseMessage PostProductModel(ProductComModel data)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var tempdata = ProductComModel.MaptoEntity(data);
            tempdata.CreatedBy = "user";
            tempdata.CreatedDate = DateTime.Today;
            BusinessFacade.Product.Create(tempdata);

            return Request.CreateResponse(HttpStatusCode.OK, tempdata.ID);
        }

        // DELETE: api/Product/5
        [ResponseType(typeof(ProductComModel))]
        public HttpResponseMessage DeleteProductModel(int id)
        {
            try
            {
                BusinessFacade.Product.Delete(id);
            }
            catch(Exception ex)
            {
                throw (ex);
            }
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

        private bool ProductModelExists(int id)
        {
            return db.Products.Count(e => e.ID == id) > 0;
        }
    }
}