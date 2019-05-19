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
    public class OrderJobsController : Controller
    {
        private MydataEntities1 db = new MydataEntities1();

        // GET: OrderJobs
        public ActionResult Index()
        {
            var orderJobs = db.OrderJobs.Include(o => o.CustumerOrder).Include(o => o.Job).Include(o => o.WarehouseAddition).Include(o => o.Status1);
            return View(orderJobs.ToList());
        }

        // GET: OrderJobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderJob orderJob = db.OrderJobs.Find(id);
            if (orderJob == null)
            {
                return HttpNotFound();
            }
            return View(orderJob);
        }

        // GET: OrderJobs/Create
        public ActionResult Create()
        {
            ViewBag.fk_CustumerOrderorderNumer = new SelectList(db.CustumerOrders, "orderNumer", "orderNumer");
            ViewBag.fk_JobworkNumer = new SelectList(db.Jobs, "workNumer", "name");
            ViewBag.fk_WarehouseAdditionadditionNumer = new SelectList(db.WarehouseAdditions, "additionNumer", "additionNumer");
            ViewBag.status = new SelectList(db.Status, "id_Status", "name");
            return View();
        }

        // POST: OrderJobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "start,place,status,id_OrderJob,fk_JobworkNumer,fk_WarehouseAdditionadditionNumer,fk_CustumerOrderorderNumer")] OrderJob orderJob)
        {
            if (ModelState.IsValid)
            {
                db.OrderJobs.Add(orderJob);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_CustumerOrderorderNumer = new SelectList(db.CustumerOrders, "orderNumer", "orderNumer", orderJob.fk_CustumerOrderorderNumer);
            ViewBag.fk_JobworkNumer = new SelectList(db.Jobs, "workNumer", "name", orderJob.fk_JobworkNumer);
            ViewBag.fk_WarehouseAdditionadditionNumer = new SelectList(db.WarehouseAdditions, "additionNumer", "additionNumer", orderJob.fk_WarehouseAdditionadditionNumer);
            ViewBag.status = new SelectList(db.Status, "id_Status", "name", orderJob.status);
            return View(orderJob);
        }

        // GET: OrderJobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderJob orderJob = db.OrderJobs.Find(id);
            if (orderJob == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_CustumerOrderorderNumer = new SelectList(db.CustumerOrders, "orderNumer", "orderNumer", orderJob.fk_CustumerOrderorderNumer);
            ViewBag.fk_JobworkNumer = new SelectList(db.Jobs, "workNumer", "name", orderJob.fk_JobworkNumer);
            ViewBag.fk_WarehouseAdditionadditionNumer = new SelectList(db.WarehouseAdditions, "additionNumer", "additionNumer", orderJob.fk_WarehouseAdditionadditionNumer);
            ViewBag.status = new SelectList(db.Status, "id_Status", "name", orderJob.status);
            return View(orderJob);
        }

        // POST: OrderJobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "start,place,status,id_OrderJob,fk_JobworkNumer,fk_WarehouseAdditionadditionNumer,fk_CustumerOrderorderNumer")] OrderJob orderJob)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderJob).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_CustumerOrderorderNumer = new SelectList(db.CustumerOrders, "orderNumer", "orderNumer", orderJob.fk_CustumerOrderorderNumer);
            ViewBag.fk_JobworkNumer = new SelectList(db.Jobs, "workNumer", "name", orderJob.fk_JobworkNumer);
            ViewBag.fk_WarehouseAdditionadditionNumer = new SelectList(db.WarehouseAdditions, "additionNumer", "additionNumer", orderJob.fk_WarehouseAdditionadditionNumer);
            ViewBag.status = new SelectList(db.Status, "id_Status", "name", orderJob.status);
            return View(orderJob);
        }

        // GET: OrderJobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderJob orderJob = db.OrderJobs.Find(id);
            if (orderJob == null)
            {
                return HttpNotFound();
            }
            return View(orderJob);
        }

        // POST: OrderJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderJob orderJob = db.OrderJobs.Find(id);
            db.OrderJobs.Remove(orderJob);
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
