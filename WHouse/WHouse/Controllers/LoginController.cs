using System;
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
                using (MydataEntities db = new MydataEntities())
                {
                    var UserN = objUser.username;
                    var UserP= objUser.password;
                    var obj = db.Userrs.Where(a => a.username.Equals(UserN) && a.password.Equals(UserP)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["ID"] = obj.ID.ToString();
                        Session["username"] = obj.username.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objUser);
        }

                //    [ID] INT NOT NULL,
                //[name] VARCHAR(255) NULL,
                //[surname] VARCHAR(255) NULL,
                //[phone]
                //    INT NULL,
                //[userType] INT NULL,
                //[username] VARCHAR(255) NULL,
                //[password] VARCHAR(255) NULL,

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
    }
}