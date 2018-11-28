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
using ContactCatalog.Models;

namespace ContactCatalog.Controllers
{
    public class EmailAddrsController : ApiController
    {
        private ContactCatalogContext db = new ContactCatalogContext();

        // GET: api/EmailAddrs
        public IQueryable<EmailAddr> GetEmailAddrs()
        {
            return db.EmailAddrs;
        }

        // GET: api/EmailAddrs/5
        [ResponseType(typeof(EmailAddr))]
        public IHttpActionResult GetEmailAddr(string id)
        {
            EmailAddr emailAddr = db.EmailAddrs.Find(id);
            if (emailAddr == null)
            {
                return NotFound();
            }

            return Ok(emailAddr);
        }

        // PUT: api/EmailAddrs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmailAddr(string id, EmailAddr emailAddr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emailAddr.Emails)
            {
                return BadRequest();
            }

            db.Entry(emailAddr).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailAddrExists(id))
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

        // POST: api/EmailAddrs
        [ResponseType(typeof(EmailAddr))]
        public IHttpActionResult PostEmailAddr(EmailAddr emailAddr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmailAddrs.Add(emailAddr);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmailAddrExists(emailAddr.Emails))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = emailAddr.Emails }, emailAddr);
        }

        // DELETE: api/EmailAddrs/5
        [ResponseType(typeof(EmailAddr))]
        public IHttpActionResult DeleteEmailAddr(string id)
        {
            EmailAddr emailAddr = db.EmailAddrs.Find(id);
            if (emailAddr == null)
            {
                return NotFound();
            }

            db.EmailAddrs.Remove(emailAddr);
            db.SaveChanges();

            return Ok(emailAddr);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmailAddrExists(string id)
        {
            return db.EmailAddrs.Count(e => e.Emails == id) > 0;
        }
    }
}