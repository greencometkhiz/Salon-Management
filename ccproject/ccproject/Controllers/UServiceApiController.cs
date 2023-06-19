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
    public class UServiceApiController : ApiController
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
        

        
    }
}