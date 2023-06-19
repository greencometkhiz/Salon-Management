using ccproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ccproject.Controllers
{
    public class UPaymentMvcController : Controller
    {
        HttpClient client = new HttpClient();

        public ActionResult Index()

        {

            List<Payment> emp_list = new List<Payment>();

            client.BaseAddress = new Uri("https://localhost:44344/api/UPaymentApi");
            var response = client.GetAsync("UPaymentApi");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Payment>>();
                display.Wait();
                emp_list = display.Result;
            }
            return View(emp_list);
        }
     

        
        public ActionResult Details(int ID)
        {
            Payment a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/UPaymentApi");
            var response = client.GetAsync("UPaymentApi?ID=" + ID.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Payment>();
                display.Wait();
                a = display.Result;
            }

            return View(a);
        }
    }
}