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
            Userr us = new Userr();
            OrderProduct op = new OrderProduct();
            Job jbs = new Job();


            List<Userr> Workers = us.SelectFreeWorker();
            List<OrderProduct> products = op.SelectProductsByOrder(id);
            List<Job> jobs = jbs.SelectJobList();

            Merged merged = new Merged();
            merged.wrokers = Workers;
            merged.works = jobs;



            return View("JobApointment",merged);
        }

    }
}