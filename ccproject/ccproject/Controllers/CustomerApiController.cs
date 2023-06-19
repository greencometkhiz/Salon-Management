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
    public class CustomerApiController : ApiController
    {
        ccobjEntities2 db = new ccobjEntities2();
        [HttpGet]

        public IHttpActionResult GetEmployees()
        {

            List<Customer> list = db.Customers.ToList();
            return Ok(list);
        }
        [HttpGet]

        public IHttpActionResult GetEmployeebyID(int ID)
        {

            var ad = db.Customers.Where(model => model.Cid == ID).FirstOrDefault();
            return Ok(ad);
        }
        [HttpPost]

        public IHttpActionResult EmpInsert(Customer e)
        {

            db.Customers.Add(e);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]

        public IHttpActionResult EmpUpdate(Customer e)
        {
            //db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            var ad = db.Customers.Where(model => model.Cid == e.Cid).FirstOrDefault();
            if (ad != null)
            {
                ad.Cid = e.Cid;
                ad.Name = e.Name;
                ad.Gender = e.Gender;
                ad.Age = e.Age;
                ad.Contact = e.Contact;
                ad.Address = e.Address;
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
            var ad = db.Customers.Where(model => model.Cid == ID).FirstOrDefault();
            db.Entry(ad).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}