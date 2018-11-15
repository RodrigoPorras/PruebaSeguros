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
    public class TipoDeCubrimientosController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/TipoDeCubrimientos
        public IQueryable<TipoDeCubrimiento> GetTipoDeCubrimiento()
        {
            return db.TipoDeCubrimiento;
        }

        // GET: api/TipoDeCubrimientos/5
        [ResponseType(typeof(TipoDeCubrimiento))]
        public IHttpActionResult GetTipoDeCubrimiento(int id)
        {
            TipoDeCubrimiento tipoDeCubrimiento = db.TipoDeCubrimiento.Find(id);
            if (tipoDeCubrimiento == null)
            {
                return NotFound();
            }

            return Ok(tipoDeCubrimiento);
        }

        // PUT: api/TipoDeCubrimientos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoDeCubrimiento(int id, TipoDeCubrimiento tipoDeCubrimiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoDeCubrimiento.IDCubrimiento)
            {
                return BadRequest();
            }

            db.Entry(tipoDeCubrimiento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDeCubrimientoExists(id))
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

        // POST: api/TipoDeCubrimientos
        [ResponseType(typeof(TipoDeCubrimiento))]
        public IHttpActionResult PostTipoDeCubrimiento(TipoDeCubrimiento tipoDeCubrimiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoDeCubrimiento.Add(tipoDeCubrimiento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoDeCubrimiento.IDCubrimiento }, tipoDeCubrimiento);
        }

        // DELETE: api/TipoDeCubrimientos/5
        [ResponseType(typeof(TipoDeCubrimiento))]
        public IHttpActionResult DeleteTipoDeCubrimiento(int id)
        {
            TipoDeCubrimiento tipoDeCubrimiento = db.TipoDeCubrimiento.Find(id);
            if (tipoDeCubrimiento == null)
            {
                return NotFound();
            }

            db.TipoDeCubrimiento.Remove(tipoDeCubrimiento);
            db.SaveChanges();

            return Ok(tipoDeCubrimiento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoDeCubrimientoExists(int id)
        {
            return db.TipoDeCubrimiento.Count(e => e.IDCubrimiento == id) > 0;
        }
    }
}