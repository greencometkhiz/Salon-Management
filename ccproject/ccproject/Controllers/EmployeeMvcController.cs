using ccproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ccproject.Controllers
{
    public class EmployeeMvcController : Controller
    {
        HttpClient client = new HttpClient();

        public ActionResult Index()

        {

            List<Employee> emp_list = new List<Employee>();

            client.BaseAddress = new Uri("https://localhost:44344/api/EmployeeApi");
            var response = client.GetAsync("EmployeeApi");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Employee>>();
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
        public ActionResult Create(Employee ad)
        {
            client.BaseAddress = new Uri("https://localhost:44344/api/EmployeeApi");
            var response = client.PostAsJsonAsync<Employee>("EmployeeApi", ad);
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
            Employee a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/EmployeeApi");
            var response = client.GetAsync("EmployeeApi?ID=" + ID.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                a = display.Result;
            }

            return View(a);
        }
        public ActionResult Edit(int ID)
        {
            Employee a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/EmployeeApi");
            var response = client.GetAsync("EmployeeApi?ID=" + ID.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                a = display.Result;
            }

            return View(a);
        }
        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            client.BaseAddress = new Uri("https://localhost:44344/api/EmployeeApi");
            var response = client.PutAsJsonAsync<Employee>("EmployeeApi", e);
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
            Employee a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/EmployeeApi");
            var response = client.GetAsync("EmployeeApi?ID=" + ID.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                a = display.Result;
            }

            return View(a);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int ID)
        {
            client.BaseAddress = new Uri("https://localhost:44344/api/EmployeeApi");
            var response = client.DeleteAsync("EmployeeApi/" + ID.ToString());
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