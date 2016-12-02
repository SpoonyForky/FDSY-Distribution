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
        //   private BeerContext db = new BeerContext();


        private IRepository<Bar> repo;

        public BarsApiController(IRepository<Bar> _repo)
        {
            this.repo = _repo;
        }

        public BarsApiController() : this(new BarRepository())
        {

        }

        /// <summary>
        /// Returns all bars
        /// </summary>
        /// <returns></returns>
        // GET: api/BarsApi
        public ICollection<Bar> GetBars()
        {
            return repo.Get();
        }

        /// <summary>
        /// Returns a Bar based off of the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/BarsApi/5
        [ResponseType(typeof(Bar))]
        public IHttpActionResult GetBar(int id)
        {
            Bar bar = repo.Get(id);
            if (bar == null)
            {
                return NotFound();
            }

            return Ok(bar);
        }


        /// <summary>
        /// Edits an existing bar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bar"></param>
        /// <returns></returns>
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

            try
            {
                repo.Put(bar);
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

        /// <summary>
        /// Creates a new bar
        /// </summary>
        /// <param name="bar"></param>
        /// <returns></returns>
        // POST: api/BarsApi
        [ResponseType(typeof(Bar))]
        public IHttpActionResult PostBar(Bar bar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Post(bar);

            return CreatedAtRoute("DefaultApi", new { id = bar.StoreId }, bar);
        }

        /// <summary>
        /// Deletes a bar based on ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/BarsApi/5
        [ResponseType(typeof(Bar))]
        public IHttpActionResult DeleteBar(int id)
        {
           Bar bar = repo.Get(id);
            if (bar == null)
            {
                return NotFound();
            }

            repo.Delete(id);

            return Ok(bar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BarExists(int id)
        {
            return (repo.Get(id) != null);
        }
    }
}