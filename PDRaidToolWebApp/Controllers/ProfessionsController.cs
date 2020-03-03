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
    public class ProfessionsController : ApiController
    {
        private ToolEntities db = new ToolEntities();

        // GET: api/Professions
        public IQueryable<Profession> GetProfessions()
        {
            return db.Professions;
        }

        // GET: api/Professions/5
        [ResponseType(typeof(Profession))]
        public IHttpActionResult GetProfession(int id)
        {
            Profession profession = db.Professions.Find(id);
            if (profession == null)
            {
                return NotFound();
            }

            return Ok(profession);
        }

        // PUT: api/Professions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfession(int id, Profession profession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profession.PID)
            {
                return BadRequest();
            }

            db.Entry(profession).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessionExists(id))
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

        // POST: api/Professions
        [ResponseType(typeof(Profession))]
        public IHttpActionResult PostProfession(Profession profession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Professions.Add(profession);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProfessionExists(profession.PID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = profession.PID }, profession);
        }

        // DELETE: api/Professions/5
        [ResponseType(typeof(Profession))]
        public IHttpActionResult DeleteProfession(int id)
        {
            Profession profession = db.Professions.Find(id);
            if (profession == null)
            {
                return NotFound();
            }

            db.Professions.Remove(profession);
            db.SaveChanges();

            return Ok(profession);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfessionExists(int id)
        {
            return db.Professions.Count(e => e.PID == id) > 0;
        }
    }
}