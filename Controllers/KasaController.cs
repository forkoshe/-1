using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication16.Models;

namespace WebApplication16.Controllers
{
    public class KasaController : ApiController
    {
        public KasaDBase1Entities db = new KasaDBase1Entities();
        public IHttpActionResult Get(int Id)
        {
            try
            {
                Kasa result = db.Kasa.Find(Id);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch(Exception error)
            {
                return InternalServerError(error);
            }

        }
        public IHttpActionResult Post([FromBody] Kasa kasa)
        {
            try
            {
                db.Kasa.Add(kasa);
                db.SaveChanges();
                return Ok(kasa);
            }
            catch (Exception error)
            {
                return InternalServerError(error);
            }
        }
        public IHttpActionResult Delete(int Id)
        {
            try
            {
                Kasa result = db.Kasa.Find(Id);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    db.Kasa.Remove(result);
                    db.SaveChanges();
                    return Ok();

                }

            }
            catch (Exception error)
            {
                return InternalServerError(error);
            }
        }
        public IHttpActionResult Patch([FromBody] Kasa kasa)
        {
            try
            {
                db.Entry(kasa).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Ok(kasa);

            }
            catch (Exception error)
            {
                return InternalServerError(error);
            }
        }
    }
}
