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
    public class CustomerViewController : Controller
    {
        private MydataEntities1 db = new MydataEntities1();
        // GET: JobAppointment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyOrders()
        {
            Inventory inv = new Inventory();
            OrderProduct ord = new OrderProduct();
            CustumerOrder cus = new CustumerOrder();

            string LoggedInId = Session["ID"].ToString();
            int xd = Int32.Parse(LoggedInId);
            List<CustumerOrder> custumerOrders = cus.SelectByLoggedInID(xd);

            return View(custumerOrders);
        }

    }
}