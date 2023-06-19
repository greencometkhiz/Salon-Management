using ccproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace ccproject.Controllers
{
    public class CrudApiController : ApiController
    {
        ccobjEntities2 db = new ccobjEntities2();
        [HttpGet]

        public IHttpActionResult GetEmployees()
        {

            List<Service> list = db.Services.ToList();
            return Ok(list);
        }
        [HttpGet]

        public IHttpActionResult GetEmployeebyID(int ID)
        {

            var ad = db.Services.Where(model => model.Sid == ID).FirstOrDefault();
            return Ok(ad);
        }
        [HttpPost]

        public IHttpActionResult EmpInsert(Service e)
        {

            db.Services.Add(e);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]

        public IHttpActionResult EmpUpdate(Service e)
        {
            //db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            var ad = db.Services.Where(model => model.Sid == e.Sid).FirstOrDefault();
            if (ad != null)
            {
                ad.Sid = e.Sid;
                ad.Description = e.Description;
                ad.Duration = e.Duration;
                ad.Cost = e.Cost;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpDelete]

        public IHttpActionResult EmpDelete(int ID)
        {
            var ad = db.Services.Where(model => model.Sid == ID).FirstOrDefault();
            db.Entry(ad).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}