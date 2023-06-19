using ccproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ccproject.Controllers
{
    public class UProductMvcController : Controller
    {
        HttpClient client = new HttpClient();

        public ActionResult Index()

        {

            List<Product> emp_list = new List<Product>();

            client.BaseAddress = new Uri("https://localhost:44344/api/UProductApi");
            var response = client.GetAsync("UProductApi");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Product>>();
                display.Wait();
                emp_list = display.Result;
            }
            return View(emp_list);
        }
      
        public ActionResult Details(int ID)
        {
            Product a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/UProductApi");
            var response = client.GetAsync("UProductApi?ID=" + ID.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Product>();
                display.Wait();
                a = display.Result;
            }

            return View(a);
        }
    }
}