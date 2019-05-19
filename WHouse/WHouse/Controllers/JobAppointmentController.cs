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
    public class JobAppointmentController : Controller
    {
        private MydataEntities db = new MydataEntities();
        // GET: JobAppointment

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Start(int id)
        {
            






            var orderProducts = db.OrderProducts.Include(o => o.CustumerOrder).Include(o => o.Inventory);
            return View(orderProducts.ToList());
        }
        public void SelectFreeWorkers()
        {
           // var freeworkers = db.Userrs.Select();
           // return View(inventories.ToList());

        }
    }
}