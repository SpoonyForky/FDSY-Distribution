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

namespace FDSY_Distribution.Controllers.ApiControllers
{
    public class BarsApiController : ApiController
    {
        private BeerContext db = new BeerContext();

        // GET: api/BarsApi
        public IQueryable<Bar> GetBars()
        {
            return db.Bars;
        }

        // GET: api/BarsApi/5
        [ResponseType(typeof(Bar))]
        public IHttpActionResult GetBar(int id)
        {
            Bar bar = db.Bars.Find(id);
            if (bar == null)
            {
                return NotFound();
            }

            return Ok(bar);
        }

        // PUT: api/BarsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBar(int id, Bar bar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bar.StoreId)
            {
                return BadRequest();
            }

            db.Entry(bar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarExists(id))
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

        // POST: api/BarsApi
        [ResponseType(typeof(Bar))]
        public IHttpActionResult PostBar(Bar bar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bars.Add(bar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bar.StoreId }, bar);
        }

        // DELETE: api/BarsApi/5
        [ResponseType(typeof(Bar))]
        public IHttpActionResult DeleteBar(int id)
        {
            Bar bar = db.Bars.Find(id);
            if (bar == null)
            {
                return NotFound();
            }

            db.Bars.Remove(bar);
            db.SaveChanges();

            return Ok(bar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BarExists(int id)
        {
            return db.Bars.Count(e => e.StoreId == id) > 0;
        }
    }
}