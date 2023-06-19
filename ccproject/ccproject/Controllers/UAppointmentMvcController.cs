using ccproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ccproject.Controllers
{
    public class UAppointmentMvcController : Controller
    {
        HttpClient client = new HttpClient();

        public ActionResult Index()

        {

            List<Appointment> emp_list = new List<Appointment>();

            client.BaseAddress = new Uri("https://localhost:44344/api/UAppointmentApi");
            var response = client.GetAsync("UAppointmentApi");
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
       
        public ActionResult Details(int ID)
        {
            Appointment a = null;
            client.BaseAddress = new Uri("https://localhost:44344/api/UAppointmentApi");
            var response = client.GetAsync("UAppointmentApi?ID=" + ID.ToString());
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
       
      
       
    }
}