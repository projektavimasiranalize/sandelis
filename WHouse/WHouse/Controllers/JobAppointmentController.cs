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
            List<Userr> Workers = us.SelectFreeWorker();

            Merged merged = new Merged();
            merged.wrokers = Workers;
            merged.jWorker = new List<JobWorker>();
            merged.orJobs = new List<OrderJob>();
            merged.id = id;

            return View("JobApointment", merged);
        }


        [HttpPost]
        public ActionResult AppointJobsAndWorkers(Merged merged)
        {
            int[] joborderid= new int[50];
            int k = 0;
            int countall = 0;
            Job jbs = new Job();
            OrderJob ordjooobs = new OrderJob();
            List<Job> jobs = jbs.SelectJobList();
            foreach (var jooob in jobs)
            {
                var obj = db.OrderJobs.Where(a => a.fk_CustumerOrderorderNumer.Equals(merged.id) && a.fk_JobworkNumer.Equals(jooob.workNumer)).FirstOrDefault();
                if (obj == null)
                {
                   joborderid[k] = ordjooobs.InsertOrderJob(jooob.workNumer, merged.id);
                    k++;
                }
                countall++;
            }
            return View();
        }
    }
}