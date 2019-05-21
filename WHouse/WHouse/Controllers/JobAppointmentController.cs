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
            int joborderid;
            int k = 0;
            int siaip;
            int succes;
            int successor;
            CustumerOrder CO = new CustumerOrder();
            Userr us = new Userr();
            JobWorker jbWorker = new JobWorker();
            Job jbs = new Job();
            OrderJob ordjooobs = new OrderJob();
            List<Job> jobs = jbs.SelectJobList();
            
            foreach (var jooob in jobs)
            {
                var obj = db.OrderJobs.Where(a => a.fk_CustumerOrderorderNumer.Equals(merged.id) && a.fk_JobworkNumer.Equals(jooob.workNumer)).FirstOrDefault();
                if (obj == null)
                {
                   joborderid = ordjooobs.InsertOrderJob(jooob.workNumer, merged.id);
                    if (k == 0) { siaip = jbWorker.InsertJobWorker(joborderid, merged.first); succes = us.UpdateWorkerStarus(merged.first); }
                    else if  (k==1) { siaip = jbWorker.InsertJobWorker(joborderid, merged.second); succes = us.UpdateWorkerStarus(merged.second); }
                    else if (k == 2) { siaip = jbWorker.InsertJobWorker(joborderid, merged.third); succes = us.UpdateWorkerStarus(merged.third); }
                    else if (k == 3) { siaip = jbWorker.InsertJobWorker(joborderid, merged.fourth); succes = us.UpdateWorkerStarus(merged.fourth); }
                    else if (k == 4) { siaip = jbWorker.InsertJobWorker(joborderid, merged.fifth); succes = us.UpdateWorkerStarus(merged.fifth); }
                    else if (k == 5) { siaip = jbWorker.InsertJobWorker(joborderid, merged.six); succes = us.UpdateWorkerStarus(merged.six); }
                }
                k++;

            }
            successor = CO.UpdateOrderStatus(merged.id);

            return RedirectToAction("Index", "CustumerOrders", new { area = "Index" });
        }
    }
}