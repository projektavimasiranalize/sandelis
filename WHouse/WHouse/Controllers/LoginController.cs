﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WHouse.Models;

namespace WHouse.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Userr objUser)
        {
            if (ModelState.IsValid)
            {
                using (MydataEntities1 db = new MydataEntities1())
                {
                    var UserN = objUser.username;
                    var UserP= objUser.password;
                    var obj = db.Userrs.Where(a => a.username.Equals(UserN) && a.password.Equals(UserP)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["ID"] = obj.ID.ToString();
                        Session["username"] = obj.username.ToString();
                        Session["userType"] = obj.userType;

                        if (obj.userType == 1)                       
                            return RedirectToAction("UserDashBoard");

                        if (obj.userType == 2)
                            return RedirectToAction("Index", "CustumerOrders", new { area = "Index" });

                        if (obj.userType == 3)
                            return RedirectToAction("WorkerDashBoard");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult AdminDashBoard()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult WorkerDashBoard()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}