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
    public class JobWorkersController : Controller
    {
        private MydataEntities1 db = new MydataEntities1();

        // GET: JobWorkers
        public ActionResult Index()
        {
            var jobWorkers = db.JobWorkers.Include(j => j.Userr).Include(j => j.OrderJob);
            return View(jobWorkers.ToList());
        }

        // GET: JobWorkers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobWorker jobWorker = db.JobWorkers.Find(id);
            if (jobWorker == null)
            {
                return HttpNotFound();
            }
            return View(jobWorker);
        }

        // GET: JobWorkers/Create
        public ActionResult Create()
        {
            ViewBag.fk_UserID = new SelectList(db.Userrs, "ID", "name");
            ViewBag.fk_OrderJobid_OrderJob = new SelectList(db.OrderJobs, "id_OrderJob", "place");
            return View();
        }

        // POST: JobWorkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "posision,id_JobWorker,fk_OrderJobid_OrderJob,fk_UserID")] JobWorker jobWorker)
        {
            if (ModelState.IsValid)
            {
                db.JobWorkers.Add(jobWorker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_UserID = new SelectList(db.Userrs, "ID", "name", jobWorker.fk_UserID);
            ViewBag.fk_OrderJobid_OrderJob = new SelectList(db.OrderJobs, "id_OrderJob", "place", jobWorker.fk_OrderJobid_OrderJob);
            return View(jobWorker);
        }

        // GET: JobWorkers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobWorker jobWorker = db.JobWorkers.Find(id);
            if (jobWorker == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_UserID = new SelectList(db.Userrs, "ID", "name", jobWorker.fk_UserID);
            ViewBag.fk_OrderJobid_OrderJob = new SelectList(db.OrderJobs, "id_OrderJob", "place", jobWorker.fk_OrderJobid_OrderJob);
            return View(jobWorker);
        }

        // POST: JobWorkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "posision,id_JobWorker,fk_OrderJobid_OrderJob,fk_UserID")] JobWorker jobWorker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobWorker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_UserID = new SelectList(db.Userrs, "ID", "name", jobWorker.fk_UserID);
            ViewBag.fk_OrderJobid_OrderJob = new SelectList(db.OrderJobs, "id_OrderJob", "place", jobWorker.fk_OrderJobid_OrderJob);
            return View(jobWorker);
        }

        // GET: JobWorkers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobWorker jobWorker = db.JobWorkers.Find(id);
            if (jobWorker == null)
            {
                return HttpNotFound();
            }
            return View(jobWorker);
        }

        // POST: JobWorkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobWorker jobWorker = db.JobWorkers.Find(id);
            db.JobWorkers.Remove(jobWorker);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
