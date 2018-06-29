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
using VetServiceAPI2.Models;

namespace VetServiceAPI2.Controllers
{
    public class OwnerVIEWsController : ApiController
    {
        private Challenge2Entities db = new Challenge2Entities();

        // GET: api/OwnerVIEWs
        public IQueryable<OwnerVIEW> GetOwnerVIEWs()
        {
            return db.OwnerVIEWs;
        }

        // GET: api/OwnerVIEWs/5
        [ResponseType(typeof(OwnerVIEW))]
        public async Task<IHttpActionResult> GetOwnerVIEW(int id)
        {
            OwnerVIEW ownerVIEW = await db.OwnerVIEWs.FirstOrDefaultAsync(O => O.OwnerID == id);
            if (ownerVIEW == null)
            {
                return NotFound();
            }

            return Ok(ownerVIEW);
        }

        // PUT: api/OwnerVIEWs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOwnerVIEW(int id, OwnerVIEW ownerVIEW)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ownerVIEW.OwnerID)
            {
                return BadRequest();
            }

            db.Entry(ownerVIEW).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerVIEWExists(id))
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

        // POST: api/OwnerVIEWs
        [ResponseType(typeof(OwnerVIEW))]
        public async Task<IHttpActionResult> PostOwnerVIEW(OwnerVIEW ownerVIEW)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OwnerVIEWs.Add(ownerVIEW);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OwnerVIEWExists(ownerVIEW.OwnerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ownerVIEW.OwnerID }, ownerVIEW);
        }

        // DELETE: api/OwnerVIEWs/5
        [ResponseType(typeof(OwnerVIEW))]
        public async Task<IHttpActionResult> DeleteOwnerVIEW(int id)
        {
            OwnerVIEW ownerVIEW = await db.OwnerVIEWs.FindAsync(id);
            if (ownerVIEW == null)
            {
                return NotFound();
            }

            db.OwnerVIEWs.Remove(ownerVIEW);
            await db.SaveChangesAsync();

            return Ok(ownerVIEW);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OwnerVIEWExists(int id)
        {
            return db.OwnerVIEWs.Count(e => e.OwnerID == id) > 0;
        }
    }
}