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
using Vaccine_Webapi;

namespace Vaccine_Webapi.Controllers
{
    public class BarnsController : ApiController
    {
        private ModelContext db = new ModelContext();

        // GET: api/Barns
        public IQueryable<Barn> GetBarn()
        {
            return db.Barn;
        }

        // GET: api/Barns/5
        [ResponseType(typeof(Barn))]
        public IHttpActionResult GetBarn(int id)
        {
            Barn barn = db.Barn.Find(id);
            if (barn == null)
            {
                return NotFound();
            }

            return Ok(barn);
        }

        // PUT: api/Barns/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBarn(int id, Barn barn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != barn.Barn_Id)
            {
                return BadRequest();
            }

            db.Entry(barn).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarnExists(id))
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

        // POST: api/Barns
        [ResponseType(typeof(Barn))]
        public IHttpActionResult PostBarn(Barn barn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Barn.Add(barn);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BarnExists(barn.Barn_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = barn.Barn_Id }, barn);
        }

        // DELETE: api/Barns/5
        [ResponseType(typeof(Barn))]
        public IHttpActionResult DeleteBarn(int id)
        {
            Barn barn = db.Barn.Find(id);
            if (barn == null)
            {
                return NotFound();
            }

            db.Barn.Remove(barn);
            db.SaveChanges();

            return Ok(barn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BarnExists(int id)
        {
            return db.Barn.Count(e => e.Barn_Id == id) > 0;
        }
    }
}