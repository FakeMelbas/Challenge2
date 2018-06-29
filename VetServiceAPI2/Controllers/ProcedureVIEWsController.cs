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
    public class ProcedureVIEWsController : ApiController
    {
        private Challenge2Entities db = new Challenge2Entities();

        // GET: api/ProcedureVIEWs
        public IQueryable<ProcedureVIEW> GetProcedureVIEWs()
        {
            return db.ProcedureVIEWs;
        }

        // GET: api/ProcedureVIEWs/5
        [ResponseType(typeof(ProcedureVIEW))]
        public async Task<IHttpActionResult> GetProcedureVIEW(int id)
        {
            ProcedureVIEW procedureVIEW = await db.ProcedureVIEWs.FirstOrDefaultAsync(PR => PR.procedureID == id);
            if (procedureVIEW == null)
            {
                return NotFound();
            }

            return Ok(procedureVIEW);
        }

        // PUT: api/ProcedureVIEWs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProcedureVIEW(int id, ProcedureVIEW procedureVIEW)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != procedureVIEW.procedureID)
            {
                return BadRequest();
            }

            db.Entry(procedureVIEW).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedureVIEWExists(id))
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

        // POST: api/ProcedureVIEWs
        [ResponseType(typeof(ProcedureVIEW))]
        public async Task<IHttpActionResult> PostProcedureVIEW(ProcedureVIEW procedureVIEW)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProcedureVIEWs.Add(procedureVIEW);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProcedureVIEWExists(procedureVIEW.procedureID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = procedureVIEW.procedureID }, procedureVIEW);
        }

        // DELETE: api/ProcedureVIEWs/5
        [ResponseType(typeof(ProcedureVIEW))]
        public async Task<IHttpActionResult> DeleteProcedureVIEW(int id)
        {
            ProcedureVIEW procedureVIEW = await db.ProcedureVIEWs.FindAsync(id);
            if (procedureVIEW == null)
            {
                return NotFound();
            }

            db.ProcedureVIEWs.Remove(procedureVIEW);
            await db.SaveChangesAsync();

            return Ok(procedureVIEW);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProcedureVIEWExists(int id)
        {
            return db.ProcedureVIEWs.Count(e => e.procedureID == id) > 0;
        }
    }
}