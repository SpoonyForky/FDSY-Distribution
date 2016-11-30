﻿using System;
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
    public class BreweriesApiController : ApiController
    {
        private BeerContext db = new BeerContext();

        /// <summary>
        /// GET's Brewaries
        /// </summary>
        /// <returns></returns>
        // GET: api/BreweriesApi
        public IQueryable<Brewery> GetBreweries()
        {
            return db.Breweries;
        }

        /// <summary>
        /// GET's a Brewary based off of the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/BreweriesApi/5
        [ResponseType(typeof(Brewery))]
        public IHttpActionResult GetBrewery(int id)
        {
            Brewery brewery = db.Breweries.Find(id);
            if (brewery == null)
            {
                return NotFound();
            }

            return Ok(brewery);
        }

        /// <summary>
        /// PUT's a Brewary
        /// </summary>
        /// <param name="id"></param>
        /// <param name="brewery"></param>
        /// <returns></returns>
        // PUT: api/BreweriesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBrewery(int id, Brewery brewery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brewery.BreweryId)
            {
                return BadRequest();
            }

            db.Entry(brewery).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreweryExists(id))
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
        /// POST's a new Brewary
        /// </summary>
        /// <param name="brewery"></param>
        /// <returns></returns>
        // POST: api/BreweriesApi
        [ResponseType(typeof(Brewery))]
        public IHttpActionResult PostBrewery(Brewery brewery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Breweries.Add(brewery);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = brewery.BreweryId }, brewery);
        }


        /// <summary>
        /// DELETE's a Brewarie based off of the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/BreweriesApi/5
        [ResponseType(typeof(Brewery))]
        public IHttpActionResult DeleteBrewery(int id)
        {
            Brewery brewery = db.Breweries.Find(id);
            if (brewery == null)
            {
                return NotFound();
            }

            db.Breweries.Remove(brewery);
            db.SaveChanges();

            return Ok(brewery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BreweryExists(int id)
        {
            return db.Breweries.Count(e => e.BreweryId == id) > 0;
        }
    }
}