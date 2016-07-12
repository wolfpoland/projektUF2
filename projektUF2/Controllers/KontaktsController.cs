using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using projektUF2.Models;

namespace projektUF2.Controllers
{
    public class KontaktsController : ApiController
    {
        private projektUF2Context db = new projektUF2Context();

        // GET: api/Kontakts
        public IQueryable<Kontakt> GetKontakts()
        {
            return db.Kontakts;
        }

        // GET: api/Kontakts/5
        [ResponseType(typeof(Kontakt))]
        public async Task<IHttpActionResult> GetKontakt(int id)
        {
            Kontakt kontakt = await db.Kontakts.FindAsync(id);
            if (kontakt == null)
            {
                return NotFound();
            }

            return Ok(kontakt);
        }

        // PUT: api/Kontakts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKontakt(int id, Kontakt kontakt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kontakt.Id)
            {
                return BadRequest();
            }

            db.Entry(kontakt).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KontaktExists(id))
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

        // POST: api/Kontakts
        [ResponseType(typeof(Kontakt))]
        public async Task<IHttpActionResult> PostKontakt(Kontakt kontakt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kontakts.Add(kontakt);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = kontakt.Id }, kontakt);
        }

        // DELETE: api/Kontakts/5
        [ResponseType(typeof(Kontakt))]
        public async Task<IHttpActionResult> DeleteKontakt(int id)
        {
            Kontakt kontakt = await db.Kontakts.FindAsync(id);
            if (kontakt == null)
            {
                return NotFound();
            }

            db.Kontakts.Remove(kontakt);
            await db.SaveChangesAsync();

            return Ok(kontakt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KontaktExists(int id)
        {
            return db.Kontakts.Count(e => e.Id == id) > 0;
        }
    }
}