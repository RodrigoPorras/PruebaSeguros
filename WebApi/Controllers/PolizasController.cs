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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class PolizasController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Polizas
        public IQueryable<Poliza> GetPoliza()
        {
            return db.Poliza;
        }

        // GET: api/Polizas/5
        [ResponseType(typeof(Poliza))]
        public IHttpActionResult GetPoliza(int id)
        {
            Poliza poliza = db.Poliza.Find(id);
            if (poliza == null)
            {
                return NotFound();
            }

            return Ok(poliza);
        }

        // PUT: api/Polizas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPoliza(int id, Poliza poliza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poliza.IDPoliza)
            {
                return BadRequest();
            }

            db.Entry(poliza).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolizaExists(id))
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

        // POST: api/Polizas
        [ResponseType(typeof(Poliza))]
        public IHttpActionResult PostPoliza(Poliza poliza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Poliza.Add(poliza);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = poliza.IDPoliza }, poliza);
        }

        // DELETE: api/Polizas/5
        [ResponseType(typeof(Poliza))]
        public IHttpActionResult DeletePoliza(int id)
        {
            Poliza poliza = db.Poliza.Find(id);
            if (poliza == null)
            {
                return NotFound();
            }

            db.Poliza.Remove(poliza);
            db.SaveChanges();

            return Ok(poliza);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PolizaExists(int id)
        {
            return db.Poliza.Count(e => e.IDPoliza == id) > 0;
        }
    }
}