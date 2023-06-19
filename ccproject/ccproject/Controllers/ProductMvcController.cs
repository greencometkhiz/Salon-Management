using ccproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ccproject.Controllers
{
    public class ProductMvcController : Controller
    {
        HttpClient client = new HttpClient();

        public ActionResult Index()

        {

            List<Product> emp_list = new List<Product>();

            client.BaseAddress = new Uri("https://localhost:44344/api/ProductApi");
            var response = client.GetAsync("ProductApi");
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
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product ad)
        {
            client.BaseAddress = new Uri("https://localhost:44344/api/ProductApi");
            var response = client.PostAsJsonAsync<Product>("ProductApi", ad);
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
            Product a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/ProductApi");
            var response = client.GetAsync("ProductApi?ID=" + ID.ToString());
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
        public ActionResult Edit(int ID)
        {
            Product a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/ProductApi");
            var response = client.GetAsync("ProductApi?ID=" + ID.ToString());
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
        [HttpPost]
        public ActionResult Edit(Product e)
        {
            client.BaseAddress = new Uri("https://localhost:44344/api/ProductApi");
            var response = client.PutAsJsonAsync<Product>("ProductApi", e);
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
            Product a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/ProductApi");
            var response = client.GetAsync("ProductApi?ID=" + ID.ToString());
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
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int ID)
        {
            client.BaseAddress = new Uri("https://localhost:44344/api/ProductApi");
            var response = client.DeleteAsync("ProductApi/" + ID.ToString());
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