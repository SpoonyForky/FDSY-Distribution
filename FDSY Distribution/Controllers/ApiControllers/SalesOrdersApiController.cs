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
using FDSY_Distribution.Models;
using FDSY_Distribution.Models.Repositories;

namespace FDSY_Distribution.Controllers.ApiControllers
{
    public class SalesOrdersApiController : ApiController
    {
        // private BeerContext db = new BeerContext();


        private IRepository<SalesOrder> repo;

        public SalesOrdersApiController(IRepository<SalesOrder> _repo)
        {
            this.repo = _repo;
        }

        public SalesOrdersApiController() : this(new SalesOrderRepository())
        {

        }


        // GET: api/SalesOrdersApi
        public ICollection<SalesOrder> GetSalesOrders()
        {
            return repo.Get();
        }

        // GET: api/SalesOrdersApi/5
        [ResponseType(typeof(SalesOrder))]
        public IHttpActionResult GetSalesOrder(int id)
        {
            SalesOrder salesOrder = repo.Get(id);
            if (salesOrder == null)
            {
                return NotFound();
            }

            return Ok(salesOrder);
        }

        // PUT: api/SalesOrdersApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSalesOrder(int id, SalesOrder salesOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salesOrder.SalesOrderID)
            {
                return BadRequest();
            }


            try
            {
                repo.Put(salesOrder);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SalesOrdersApi
        [ResponseType(typeof(SalesOrder))]
        public IHttpActionResult PostSalesOrder(SalesOrder salesOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Post(salesOrder);

            return CreatedAtRoute("DefaultApi", new { id = salesOrder.SalesOrderID }, salesOrder);
        }

        // DELETE: api/SalesOrdersApi/5
        [ResponseType(typeof(SalesOrder))]
        public IHttpActionResult DeleteSalesOrder(int id)
        {
            SalesOrder salesOrder = repo.Get(id);
            if (salesOrder == null)
            {
                return NotFound();
            }

            repo.Delete(id);

            return Ok(salesOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                    //    db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesOrderExists(int id)
        {
            return (repo.Get(id) != null);
        }
    }
}