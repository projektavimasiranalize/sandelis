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
        private MydataEntities1 db = new MydataEntities1();
        // GET: JobAppointment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StartJob(int id)
        {
            List<Userr> Workers = SelectFreeWorkers();
            return View(Workers);
        }
        public List<Userr> SelectFreeWorkers()
        {
            string query = "SELECT * FROM userr WHERE userType ='3' and isBusy='2' ";
            //List<Userr> list = db.Userrs.ToList();
            // List<Warehouse> Frees = db.Userrs.SqlQuery(query).ToList();
              List<Userr> list = db.Userrs.Where(a => a.userType == 3 && a.isBusy == 2 ).ToList();
            return list;
        }

    }
}