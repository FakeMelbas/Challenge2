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
    public class TreatmentVIEWsController : ApiController
    {
        private Challenge2Entities db = new Challenge2Entities();

        // GET: api/TreatmentVIEWs
        public IQueryable<TreatmentVIEW> GetTreatmentVIEWs()
        {
            return db.TreatmentVIEWs;
        }

        // GET: api/TreatmentVIEWs/5
        [ResponseType(typeof(TreatmentVIEW))]
        public async Task<IHttpActionResult> GetTreatmentVIEW(string id)
        {
            TreatmentVIEW treatmentVIEW = await db.TreatmentVIEWs.FirstOrDefaultAsync(T => T.treatmentID == id);
            if (treatmentVIEW == null)
            {
                return NotFound();
            }

            return Ok(treatmentVIEW);
        }

        // PUT: api/TreatmentVIEWs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTreatmentVIEW(string id, TreatmentVIEW treatmentVIEW)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != treatmentVIEW.treatmentID)
            {
                return BadRequest();
            }

            db.Entry(treatmentVIEW).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreatmentVIEWExists(id))
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

        // POST: api/TreatmentVIEWs
        [ResponseType(typeof(TreatmentVIEW))]
        public async Task<IHttpActionResult> PostTreatmentVIEW(TreatmentVIEW treatmentVIEW)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TreatmentVIEWs.Add(treatmentVIEW);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TreatmentVIEWExists(treatmentVIEW.treatmentID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = treatmentVIEW.treatmentID }, treatmentVIEW);
        }

        // DELETE: api/TreatmentVIEWs/5
        [ResponseType(typeof(TreatmentVIEW))]
        public async Task<IHttpActionResult> DeleteTreatmentVIEW(string id)
        {
            TreatmentVIEW treatmentVIEW = await db.TreatmentVIEWs.FindAsync(id);
            if (treatmentVIEW == null)
            {
                return NotFound();
            }

            db.TreatmentVIEWs.Remove(treatmentVIEW);
            await db.SaveChangesAsync();

            return Ok(treatmentVIEW);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TreatmentVIEWExists(string id)
        {
            return db.TreatmentVIEWs.Count(e => e.treatmentID == id) > 0;
        }
    }
}