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
    public class WarehouseAdditionsController : Controller
    {
        private MydataEntities1 db = new MydataEntities1();

        // GET: WarehouseAdditions
        public ActionResult Index()
        {
            var warehouseAdditions = db.WarehouseAdditions.Include(w => w.OrderConfirm).Include(w => w.Userr);
            return View(warehouseAdditions.ToList());
        }

        // GET: WarehouseAdditions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseAddition warehouseAddition = db.WarehouseAdditions.Find(id);
            if (warehouseAddition == null)
            {
                return HttpNotFound();
            }
            return View(warehouseAddition);
        }

        // GET: WarehouseAdditions/Create
        public ActionResult Create()
        {
            ViewBag.confirm = new SelectList(db.OrderConfirms, "id_OrderConfirm", "name");
            ViewBag.fk_UserID = new SelectList(db.Userrs, "ID", "name");
            return View();
        }

        // POST: WarehouseAdditions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "additionNumer,confirm,fk_UserID")] WarehouseAddition warehouseAddition)
        {
            if (ModelState.IsValid)
            {
                db.WarehouseAdditions.Add(warehouseAddition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.confirm = new SelectList(db.OrderConfirms, "id_OrderConfirm", "name", warehouseAddition.confirm);
            ViewBag.fk_UserID = new SelectList(db.Userrs, "ID", "name", warehouseAddition.fk_UserID);
            return View(warehouseAddition);
        }

        // GET: WarehouseAdditions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseAddition warehouseAddition = db.WarehouseAdditions.Find(id);
            if (warehouseAddition == null)
            {
                return HttpNotFound();
            }
            ViewBag.confirm = new SelectList(db.OrderConfirms, "id_OrderConfirm", "name", warehouseAddition.confirm);
            ViewBag.fk_UserID = new SelectList(db.Userrs, "ID", "name", warehouseAddition.fk_UserID);
            return View(warehouseAddition);
        }

        // POST: WarehouseAdditions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "additionNumer,confirm,fk_UserID")] WarehouseAddition warehouseAddition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warehouseAddition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.confirm = new SelectList(db.OrderConfirms, "id_OrderConfirm", "name", warehouseAddition.confirm);
            ViewBag.fk_UserID = new SelectList(db.Userrs, "ID", "name", warehouseAddition.fk_UserID);
            return View(warehouseAddition);
        }

        // GET: WarehouseAdditions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseAddition warehouseAddition = db.WarehouseAdditions.Find(id);
            if (warehouseAddition == null)
            {
                return HttpNotFound();
            }
            return View(warehouseAddition);
        }

        // POST: WarehouseAdditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WarehouseAddition warehouseAddition = db.WarehouseAdditions.Find(id);
            db.WarehouseAdditions.Remove(warehouseAddition);
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
