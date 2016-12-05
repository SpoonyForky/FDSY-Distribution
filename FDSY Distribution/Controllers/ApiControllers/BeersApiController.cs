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
    /// <summary>
    /// Controller that facilitates actions on Beer Objects
    /// </summary>
    public class BeersApiController : ApiController
    {
        private IRepository<Beer> repo;

        public BeersApiController(IRepository<Beer> _repo)
        {
            this.repo = _repo;
        }

        public BeersApiController() : this(new BeerRepository())
        {

        }
        /// <summary>
        /// Gets all beers
        /// </summary>
        /// <returns>All beers</returns>
        // GET: api/BeersApi
        public ICollection<Beer> GetBeers()
        {
            return repo.Get();
        }

        /// <summary>
        /// Returns a Beer based on the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/BeersApi/5
        [ResponseType(typeof(Beer))]
        public IHttpActionResult GetBeer(int id)
        {
            Beer beer = repo.Get(id);
            if (beer == null)
            {
                return NotFound();
            }

            return Ok(beer);
        }

        /// <summary>
        /// Edits an existing Beer
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


            try
            {
                repo.Put(beer);
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
        /// Creates a new beer
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

            repo.Post(beer);

            return CreatedAtRoute("DefaultApi", new { id = beer.BeerId }, beer);
        }

        /// <summary>
        /// Deletes a Beer based on the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/BeersApi/5
        [ResponseType(typeof(Beer))]
        public IHttpActionResult DeleteBeer(int id)
        {
            Beer beer = repo.Get(id);
            if (beer == null)
            {
                return NotFound();
            }

            repo.Delete(id);

            return Ok(beer);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }
        private bool BeerExists(int id)
        {
            return (repo.Get(id) != null); ;
        }
    }
}