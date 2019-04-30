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
using PDRaidToolDataAccessLayer.Models;

namespace PDRaidToolWebApp.Controllers
{
    public class SpecializationsController : ApiController
    {
        private ToolEntities db = new ToolEntities();

        // GET: api/Specializations
        public IQueryable<Specialization> GetSpecializations()
        {
            return db.Specializations;
        }

        // GET: api/Specializations/5
        [ResponseType(typeof(Specialization))]
        public IHttpActionResult GetSpecialization(int id)
        {
            Specialization specialization = db.Specializations.Find(id);
            if (specialization == null)
            {
                return NotFound();
            }

            return Ok(specialization);
        }

        // PUT: api/Specializations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSpecialization(int id, Specialization specialization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != specialization.SID)
            {
                return BadRequest();
            }

            db.Entry(specialization).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecializationExists(id))
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

        // POST: api/Specializations
        [ResponseType(typeof(Specialization))]
        public IHttpActionResult PostSpecialization(Specialization specialization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Specializations.Add(specialization);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SpecializationExists(specialization.SID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = specialization.SID }, specialization);
        }

        // DELETE: api/Specializations/5
        [ResponseType(typeof(Specialization))]
        public IHttpActionResult DeleteSpecialization(int id)
        {
            Specialization specialization = db.Specializations.Find(id);
            if (specialization == null)
            {
                return NotFound();
            }

            db.Specializations.Remove(specialization);
            db.SaveChanges();

            return Ok(specialization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpecializationExists(int id)
        {
            return db.Specializations.Count(e => e.SID == id) > 0;
        }
    }
}