﻿using ccproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ccproject.Controllers
{
    public class LoginController : Controller
    {
        ccobjEntities2 db = new ccobjEntities2();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(user u)
        {
            var user = db.users.Where(model => model.username == u.username && model.password == u.password).FirstOrDefault();
            if (user != null)
            {
                Session["UserId"] = u.Id.ToString();
                Session["Username"] = u.username.ToString();
                TempData["LoginSuccessMessage"] = "<script>alert('Login successfull!')</script>";
                if (u.username == "Admin" && u.password == "123")
                {
                    return RedirectToAction("Admindashboard", "Dashboards");
                }
                else
                {
                    return RedirectToAction("Userdashboard", "Dashboards");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "<script>alert('Username or Password is incorrect!')</script>";
                return View();
            }

        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(user u)
        {
            if (ModelState.IsValid == true)
            {
                db.users.Add(u);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Registered Successfully')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Registeration failed')</script>";
                }
            }
            return View();
        }
    }
}