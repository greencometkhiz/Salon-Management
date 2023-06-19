using ccproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ccproject.Controllers
{
    public class PaymentMvcController : Controller
    {
        HttpClient client = new HttpClient();

        public ActionResult Index()

        {

            List<Payment> emp_list = new List<Payment>();

            client.BaseAddress = new Uri("https://localhost:44344/api/PaymentApi");
            var response = client.GetAsync("PaymentApi");
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
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Payment ad)
        {
            client.BaseAddress = new Uri("https://localhost:44344/api/PaymentApi");
            var response = client.PostAsJsonAsync<Payment>("PaymentApi", ad);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Create");
        }
        public ActionResult Details(int ID)
        {
            Payment a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/PaymentApi");
            var response = client.GetAsync("PaymentApi?ID=" + ID.ToString());
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
        public ActionResult Edit(int ID)
        {
            Payment a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/PaymentApi");
            var response = client.GetAsync("PaymentApi?ID=" + ID.ToString());
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
        [HttpPost]
        public ActionResult Edit(Payment e)
        {
            client.BaseAddress = new Uri("https://localhost:44344/api/PaymentApi");
            var response = client.PutAsJsonAsync<Payment>("PaymentApi", e);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Edit");
        }
        public ActionResult Delete(int ID)
        {
            Payment a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/PaymentApi");
            var response = client.GetAsync("PaymentApi?ID=" + ID.ToString());
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
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int ID)
        {
            client.BaseAddress = new Uri("https://localhost:44344/api/PaymentApi");
            var response = client.DeleteAsync("PaymentApi/" + ID.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Delete");


        }
    }
}