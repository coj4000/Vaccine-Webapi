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
    public class KalendersController : ApiController
    {
        private ModelContext db = new ModelContext();

        // GET: api/Kalenders
        public IQueryable<Kalender> GetKalender()
        {
            return db.Kalender;
        }

        // GET: api/Kalenders/5
        [ResponseType(typeof(Kalender))]
        public IHttpActionResult GetKalender(DateTime id)
        {
            Kalender kalender = db.Kalender.Find(id);
            if (kalender == null)
            {
                return NotFound();
            }

            return Ok(kalender);
        }

        // PUT: api/Kalenders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKalender(DateTime id, Kalender kalender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kalender.Dato)
            {
                return BadRequest();
            }

            db.Entry(kalender).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KalenderExists(id))
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

        // POST: api/Kalenders
        [ResponseType(typeof(Kalender))]
        public IHttpActionResult PostKalender(Kalender kalender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kalender.Add(kalender);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KalenderExists(kalender.Dato))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = kalender.Dato }, kalender);
        }

        // DELETE: api/Kalenders/5
        [ResponseType(typeof(Kalender))]
        public IHttpActionResult DeleteKalender(DateTime id)
        {
            Kalender kalender = db.Kalender.Find(id);
            if (kalender == null)
            {
                return NotFound();
            }

            db.Kalender.Remove(kalender);
            db.SaveChanges();

            return Ok(kalender);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KalenderExists(DateTime id)
        {
            return db.Kalender.Count(e => e.Dato == id) > 0;
        }
    }
}