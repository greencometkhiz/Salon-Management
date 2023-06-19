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
    public class ProductApiController : ApiController
    {
        ccobjEntities2 db = new ccobjEntities2();
        [HttpGet]

        public IHttpActionResult GetEmployees()
        {

            List<Product> list = db.Products.ToList();
            return Ok(list);
        }
        [HttpGet]

        public IHttpActionResult GetEmployeebyID(int ID)
        {

            var ad = db.Products.Where(model => model.Pid == ID).FirstOrDefault();
            return Ok(ad);
        }
        [HttpPost]

        public IHttpActionResult EmpInsert(Product e)
        {

            db.Products.Add(e);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]

        public IHttpActionResult EmpUpdate(Product e)
        {
            //db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            var ad = db.Products.Where(model => model.Pid == e.Pid).FirstOrDefault();
            if (ad != null)
            {
                ad.Pid = e.Pid;
                ad.Name = e.Name;
                ad.Cost = e.Cost;
                ad.Quantity = e.Quantity;
                ad.DateofManufacture = e.DateofManufacture;
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
            var ad = db.Products.Where(model => model.Pid == ID).FirstOrDefault();
            db.Entry(ad).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}