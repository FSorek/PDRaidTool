using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
using System.Web.Http.Description;
using PDRaidToolDataAccessLayer.Models;

namespace PDRaidToolWebApp.Controllers
{

    public class RolesController : ApiController
    {
        private ToolEntities db = new ToolEntities();

        // GET: api/Rolesh
        public IQueryable<Role> GetRoles()
        {
            return db.Roles;
        }

        // GET: api/Roles/5
        
        [ResponseType(typeof(Role))]
        public IHttpActionResult GetRole(int id)
        {
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // PUT: api/Roles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRole(int id, Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != role.RID)
            {
                return BadRequest();
            }

            db.Entry(role).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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

        // POST: api/Roles
        [ResponseType(typeof(Role))]
        public IHttpActionResult PostRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Roles.Add(role);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RoleExists(role.RID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = role.RID }, role);
        }

        // DELETE: api/Roles/5
        [ResponseType(typeof(Role))]
        public IHttpActionResult DeleteRole(int id)
        {
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return NotFound();
            }

            db.Roles.Remove(role);
            db.SaveChanges();

            return Ok(role);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoleExists(int id)
        {
            return db.Roles.Count(e => e.RID == id) > 0;
        }
    }
}