using ccproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ccproject.Controllers
{
    public class UServiceMvcController : Controller
    {
        HttpClient client = new HttpClient();

        public ActionResult Index()

        {

            List<Service> emp_list = new List<Service>();

            client.BaseAddress = new Uri("https://localhost:44344/api/UServiceApi");
            var response = client.GetAsync("UServiceApi");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Service>>();
                display.Wait();
                emp_list = display.Result;
            }
            return View(emp_list);
        }
       
       
        public ActionResult Details(int ID)
        {
            Service a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/UServiceApi");
            var response = client.GetAsync("UServiceApi?ID=" + ID.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Service>();
                display.Wait();
                a = display.Result;
            }

            return View(a);
        }
       
    }
}