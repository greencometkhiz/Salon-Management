using ccproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ccproject.Controllers
{
    public class AppointmentMvcController : Controller
    {
        HttpClient client = new HttpClient();

        public ActionResult Index()

        {

            List<Appointment> emp_list = new List<Appointment>();

            client.BaseAddress = new Uri("https://localhost:44344/api/AppointmentApi");
            var response = client.GetAsync("AppointmentApi");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Appointment>>();
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
        public ActionResult Create(Appointment ad)
        {
            client.BaseAddress = new Uri("https://localhost:44344/api/AppointmentApi");
            var response = client.PostAsJsonAsync<Appointment>("AppointmentApi", ad);
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
            Appointment a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/AppointmentApi");
            var response = client.GetAsync("AppointmentApi?ID=" + ID.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Appointment>();
                display.Wait();
                a = display.Result;
            }

            return View(a);
        }
        public ActionResult Edit(int ID)
        {
            Appointment a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/AppointmentApi");
            var response = client.GetAsync("AppointmentApi?ID=" + ID.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Appointment>();
                display.Wait();
                a = display.Result;
            }

            return View(a);
        }
        [HttpPost]
        public ActionResult Edit(Appointment e)
        {
            client.BaseAddress = new Uri("https://localhost:44344/api/AppointmentApi");
            var response = client.PutAsJsonAsync<Appointment>("AppointmentApi", e);
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
            Appointment a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/AppointmentApi");
            var response = client.GetAsync("AppointmentApi?ID=" + ID.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Appointment>();
                display.Wait();
                a = display.Result;
            }

            return View(a);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int ID)
        {
            client.BaseAddress = new Uri("https://localhost:44344/api/AppointmentApi");
            var response = client.DeleteAsync("AppointmentApi/" + ID.ToString());
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