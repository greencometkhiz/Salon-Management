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
    public class AppointmentApiController : ApiController
    {
        ccobjEntities2 db = new ccobjEntities2();
        [HttpGet]

        public IHttpActionResult GetEmployees()
        {

            List<Appointment> list = db.Appointments.ToList();
            return Ok(list);
        }
        [HttpGet]

        public IHttpActionResult GetEmployeebyID(int ID)
        {

            var ad = db.Appointments.Where(model => model.Aid == ID).FirstOrDefault();
            return Ok(ad);
        }
        [HttpPost]

        public IHttpActionResult EmpInsert(Appointment e)
        {

            db.Appointments.Add(e);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]

        public IHttpActionResult EmpUpdate(Appointment e)
        {
            //db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            var ad = db.Appointments.Where(model => model.Aid == e.Aid).FirstOrDefault();
            if (ad != null)
            {
                ad.Aid = e.Aid;
                ad.Date = e.Date;
                ad.Time = e.Time;
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
            var ad = db.Appointments.Where(model => model.Aid == ID).FirstOrDefault();
            db.Entry(ad).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}