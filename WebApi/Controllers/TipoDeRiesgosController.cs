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
    public class TipoDeRiesgosController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/TipoDeRiesgos
        public IQueryable<TipoDeRiesgo> GetTipoDeRiesgo()
        {
            return db.TipoDeRiesgo;
        }

        // GET: api/TipoDeRiesgos/5
        [ResponseType(typeof(TipoDeRiesgo))]
        public IHttpActionResult GetTipoDeRiesgo(int id)
        {
            TipoDeRiesgo tipoDeRiesgo = db.TipoDeRiesgo.Find(id);
            if (tipoDeRiesgo == null)
            {
                return NotFound();
            }

            return Ok(tipoDeRiesgo);
        }

        // PUT: api/TipoDeRiesgos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoDeRiesgo(int id, TipoDeRiesgo tipoDeRiesgo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoDeRiesgo.IDRiesgo)
            {
                return BadRequest();
            }

            db.Entry(tipoDeRiesgo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDeRiesgoExists(id))
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

        // POST: api/TipoDeRiesgos
        [ResponseType(typeof(TipoDeRiesgo))]
        public IHttpActionResult PostTipoDeRiesgo(TipoDeRiesgo tipoDeRiesgo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoDeRiesgo.Add(tipoDeRiesgo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoDeRiesgo.IDRiesgo }, tipoDeRiesgo);
        }

        // DELETE: api/TipoDeRiesgos/5
        [ResponseType(typeof(TipoDeRiesgo))]
        public IHttpActionResult DeleteTipoDeRiesgo(int id)
        {
            TipoDeRiesgo tipoDeRiesgo = db.TipoDeRiesgo.Find(id);
            if (tipoDeRiesgo == null)
            {
                return NotFound();
            }

            db.TipoDeRiesgo.Remove(tipoDeRiesgo);
            db.SaveChanges();

            return Ok(tipoDeRiesgo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoDeRiesgoExists(int id)
        {
            return db.TipoDeRiesgo.Count(e => e.IDRiesgo == id) > 0;
        }
    }
}