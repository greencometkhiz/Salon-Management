using ccproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ccproject.Controllers
{
    public class CustomerMvcController : Controller
    {
        HttpClient client = new HttpClient();

        public ActionResult Index()

        {

            List<Customer> emp_list = new List<Customer>();

            client.BaseAddress = new Uri("https://localhost:44344/api/CustomerApi");
            var response = client.GetAsync("CustomerApi");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Customer>>();
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
        public ActionResult Create(Customer ad)
        {
            client.BaseAddress = new Uri("https://localhost:44344/api/CustomerApi");
            var response = client.PostAsJsonAsync<Customer>("CustomerApi", ad);
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
            Customer a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/CustomerApi");
            var response = client.GetAsync("CustomerApi?ID=" + ID.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Customer>();
                display.Wait();
                a = display.Result;
            }

            return View(a);
        }
        public ActionResult Edit(int ID)
        {
            Customer a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/CustomerApi");
            var response = client.GetAsync("CustomerApi?ID=" + ID.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Customer>();
                display.Wait();
                a = display.Result;
            }

            return View(a);
        }
        [HttpPost]
        public ActionResult Edit(Customer e)
        {
            client.BaseAddress = new Uri("https://localhost:44344/api/CustomerApi");
            var response = client.PutAsJsonAsync<Customer>("CustomerApi", e);
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
            Customer a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/CustomerApi");
            var response = client.GetAsync("CustomerApi?ID=" + ID.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Customer>();
                display.Wait();
                a = display.Result;
            }

            return View(a);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int ID)
        {
            client.BaseAddress = new Uri("https://localhost:44344/api/CustomerApi");
            var response = client.DeleteAsync("CustomerApi/" + ID.ToString());
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