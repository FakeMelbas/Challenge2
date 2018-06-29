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
    public class PetVIEWsController : ApiController
    {
        private Challenge2Entities db = new Challenge2Entities();

        // GET: api/PetVIEWs
        public IQueryable<PetVIEW> GetPetVIEWs()
        {
            return db.PetVIEWs;
        }

        // GET: api/PetVIEWs/5
        [ResponseType(typeof(PetVIEW))]
        public async Task<IHttpActionResult> GetPetVIEW(string id)
        {
            PetVIEW petVIEW = await db.PetVIEWs.FirstOrDefaultAsync(P => P.PetID == id);
            if (petVIEW == null)
            {
                return NotFound();
            }

            return Ok(petVIEW);
        }

        // PUT: api/PetVIEWs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPetVIEW(string id, PetVIEW petVIEW)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != petVIEW.PetID)
            {
                return BadRequest();
            }

            db.Entry(petVIEW).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetVIEWExists(id))
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

        // POST: api/PetVIEWs
        [ResponseType(typeof(PetVIEW))]
        public async Task<IHttpActionResult> PostPetVIEW(PetVIEW petVIEW)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PetVIEWs.Add(petVIEW);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PetVIEWExists(petVIEW.PetID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = petVIEW.PetID }, petVIEW);
        }

        // DELETE: api/PetVIEWs/5
        [ResponseType(typeof(PetVIEW))]
        public async Task<IHttpActionResult> DeletePetVIEW(string id)
        {
            PetVIEW petVIEW = await db.PetVIEWs.FindAsync(id);
            if (petVIEW == null)
            {
                return NotFound();
            }

            db.PetVIEWs.Remove(petVIEW);
            await db.SaveChangesAsync();

            return Ok(petVIEW);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetVIEWExists(string id)
        {
            return db.PetVIEWs.Count(e => e.PetID == id) > 0;
        }
    }
}