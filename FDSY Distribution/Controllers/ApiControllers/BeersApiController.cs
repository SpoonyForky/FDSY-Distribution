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
    public class BeersApiController : ApiController
    {
        private BeerContext db = new BeerContext();

        /// <summary>
        /// Get's a new Beer
        /// </summary>
        /// <returns></returns>
        // GET: api/BeersApi
        public IQueryable<Beer> GetBeers()
        {
            return db.Beers;
        }

        /// <summary>
        /// Return's a Beer based on the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/BeersApi/5
        [ResponseType(typeof(Beer))]
        public IHttpActionResult GetBeer(int id)
        {
            Beer beer = db.Beers.Find(id);
            if (beer == null)
            {
                return NotFound();
            }

            return Ok(beer);
        }

        /// <summary>
        /// PUTs a Beer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="beer"></param>
        /// <returns></returns>
        // PUT: api/BeersApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBeer(int id, Beer beer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != beer.BeerId)
            {
                return BadRequest();
            }

            db.Entry(beer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeerExists(id))
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

        /// <summary>
        /// POST's a beer
        /// </summary>
        /// <param name="beer"></param>
        /// <returns></returns>
        // POST: api/BeersApi
        [ResponseType(typeof(Beer))]
        public IHttpActionResult PostBeer(Beer beer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Beers.Add(beer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = beer.BeerId }, beer);
        }

        /// <summary>
        /// Delete's a Beer based on the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/BeersApi/5
        [ResponseType(typeof(Beer))]
        public IHttpActionResult DeleteBeer(int id)
        {
            Beer beer = db.Beers.Find(id);
            if (beer == null)
            {
                return NotFound();
            }

            db.Beers.Remove(beer);
            db.SaveChanges();

            return Ok(beer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BeerExists(int id)
        {
            return db.Beers.Count(e => e.BeerId == id) > 0;
        }
    }
}