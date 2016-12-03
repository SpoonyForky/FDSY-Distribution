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
    public class BreweriesApiController : ApiController
    {
        //  private BeerContext db = new BeerContext();


        private IRepository<Brewery> repo;

        public BreweriesApiController(IRepository<Brewery> _repo)
        {
            this.repo = _repo;
        }

        public BreweriesApiController() : this(new BrewaryRepository())
        {

        }


        /// <summary>
        /// Returns all Breweries
        /// </summary>
        /// <returns></returns>
        // GET: api/BreweriesApi
        public ICollection<Brewery> GetBreweries()
        {
           return repo.Get();
        }

        /// <summary>
        /// Returns a brewery based on ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/BreweriesApi/5
        [ResponseType(typeof(Brewery))]
        public IHttpActionResult GetBrewery(int id)
        {
            Brewery brewery = repo.Get(id);
            if (brewery == null)
            {
                return NotFound();
            }

            return Ok(brewery);
        }

        /// <summary>
        /// Edits an existing brewery with new field values
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


            try
            {
                repo.Put(brewery);
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
        /// Creates a new brewery
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

            repo.Post(brewery);

            return CreatedAtRoute("DefaultApi", new { id = brewery.BreweryId }, brewery);
        }


        /// <summary>
        /// Deletes a brewery based on the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/BreweriesApi/5
        [ResponseType(typeof(Brewery))]
        public IHttpActionResult DeleteBrewery(int id)
        {
            Brewery brewery = repo.Get(id);
            if (brewery == null)
            {
                return NotFound();
            }

            repo.Delete(id);

            return Ok(brewery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BreweryExists(int id)
        {
            return (repo.Get(id) != null);
        }
    }
}