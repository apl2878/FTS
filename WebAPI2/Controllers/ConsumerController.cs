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
using FoodTrade.Entity;
using FoodTrade.Common.Model;

namespace WebAPI2.Controllers
{
    public class ConsumerController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: api/Consumer
        public HttpResponseMessage GetConsumerComModels()
        {
            var data = BusinessFacade.Consumer.GetAll().Select(o => ConsumerComModel.MaptoModel(o));
            if (data != null)
                return Request.CreateResponse(HttpStatusCode.OK, data);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // GET: api/Consumer/5
        [ResponseType(typeof(ConsumerComModel))]
        public HttpResponseMessage GetConsumerComModel(int id)
        {
            ConsumerComModel Consumer = ConsumerComModel.MaptoModel(BusinessFacade.Consumer.Get(id));
            if (Consumer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Consumer);
        }

        // PUT: api/Consumer/5
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutConsumerComModel(int id, ConsumerComModel data)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (id != data.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var tempdata = ConsumerComModel.MaptoEntity(data);
            tempdata.ModifiedBy = "user";
            tempdata.ModifiedDate = DateTime.Today;

            try
            {
                BusinessFacade.Consumer.Update(tempdata);
            }
            catch(Exception ex)
            {
                throw(ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST: api/Consumer
        [ResponseType(typeof(ConsumerComModel))]
        public HttpResponseMessage PostConsumerComModel(ConsumerComModel data)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var tempdata = ConsumerComModel.MaptoEntity(data);
            tempdata.CreatedBy = "user";
            tempdata.CreatedDate = DateTime.Today;
            BusinessFacade.Consumer.Create(tempdata);

            return Request.CreateResponse(HttpStatusCode.OK, tempdata.ID);
        }

        // DELETE: api/Consumer/5
        [ResponseType(typeof(ConsumerComModel))]
        public HttpResponseMessage DeleteConsumerComModel(int id)
        {
            BusinessFacade.Consumer.Delete(id);
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

        private bool ConsumerComModelExists(int id)
        {
            return db.Consumers.Count(e => e.ID == id) > 0;
        }
    }
}