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
    public class PaymentApiController : ApiController
    {
        ccobjEntities2 db = new ccobjEntities2();
        [HttpGet]

        public IHttpActionResult GetEmployees()
        {

            List<Payment> list = db.Payments.ToList();
            return Ok(list);
        }
        [HttpGet]

        public IHttpActionResult GetEmployeebyID(int ID)
        {

            var ad = db.Payments.Where(model => model.Pid == ID).FirstOrDefault();
            return Ok(ad);
        }
        [HttpPost]

        public IHttpActionResult EmpInsert(Payment e)
        {

            db.Payments.Add(e);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]

        public IHttpActionResult EmpUpdate(Payment e)
        {
            //db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            var ad = db.Payments.Where(model => model.Pid == e.Pid).FirstOrDefault();
            if (ad != null)
            {
                ad.Pid = e.Pid;
                ad.Cid = e.Cid;
                ad.Eid = e.Eid;
                ad.Sid = e.Sid;
                ad.Aid = e.Aid;
                ad.Amount = e.Amount;
                ad.Dateofpayment = e.Dateofpayment;
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
            var ad = db.Payments.Where(model => model.Pid == ID).FirstOrDefault();
            db.Entry(ad).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}