using ccproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ccproject.Controllers
{

    

    public class DashboardsController : Controller
    {
        ccobjEntities2 _context = new ccobjEntities2();

        public void bager()
        {
            ViewBag.emp = _context.Employees.Count();
            ViewBag.prod = _context.Products.Count();
            ViewBag.cust = _context.Customers.Count();
            ViewBag.pay = _context.Payments.Count();
            ViewBag.serve = _context.Services.Count();
            ViewBag.app = _context.Appointments.Count();

        }
        // GET: Dashboards
        public ActionResult Admindashboard()
        {
            bager();
            return View();
        }
        public ActionResult Userdashboard()
        {
            bager();
            return View();
        }

    }
}