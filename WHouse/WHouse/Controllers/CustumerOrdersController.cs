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
    public class CustumerOrdersController : Controller
    {
        private MydataEntities1 db = new MydataEntities1();


        // GET: CustumerOrders
        public ActionResult Index()
        {
            var custumerOrders = db.CustumerOrders.Include(c => c.OrderConfirm).Include(c => c.Status1).Include(c => c.Userr);
            return View(custumerOrders.ToList());
        }

        public ActionResult ToList()
        {
            var custumerOrders = db.CustumerOrders.Include(c => c.OrderConfirm).Include(c => c.Status1).Include(c => c.Userr);
            return View(custumerOrders.ToList());
        }

        // GET: CustumerOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustumerOrder custumerOrder = db.CustumerOrders.Find(id);
            if (custumerOrder == null)
            {
                return HttpNotFound();
            }
            return View(custumerOrder);
        }

        // GET: CustumerOrders/Create
        public ActionResult Create()
        {
            ViewBag.confirm = new SelectList(db.OrderConfirms, "id_OrderConfirm", "name");
            ViewBag.status = new SelectList(db.Status, "id_Status", "name");
            ViewBag.fk_UserID = new SelectList(db.Userrs, "ID", "name");
            return View();
        }

        // POST: CustumerOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderNumer,date,confirm,status,fk_UserID")] CustumerOrder custumerOrder)
        {
            if (ModelState.IsValid)
            {
                db.CustumerOrders.Add(custumerOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.confirm = new SelectList(db.OrderConfirms, "id_OrderConfirm", "name", custumerOrder.confirm);
            ViewBag.status = new SelectList(db.Status, "id_Status", "name", custumerOrder.status);
            ViewBag.fk_UserID = new SelectList(db.Userrs, "ID", "name", custumerOrder.fk_UserID);
            return View(custumerOrder);
        }

        // GET: CustumerOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustumerOrder custumerOrder = db.CustumerOrders.Find(id);
            if (custumerOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.confirm = new SelectList(db.OrderConfirms, "id_OrderConfirm", "name", custumerOrder.confirm);
            ViewBag.status = new SelectList(db.Status, "id_Status", "name", custumerOrder.status);
            ViewBag.fk_UserID = new SelectList(db.Userrs, "ID", "name", custumerOrder.fk_UserID);
            return View(custumerOrder);
        }

        // POST: CustumerOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderNumer,date,confirm,status,fk_UserID")] CustumerOrder custumerOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(custumerOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.confirm = new SelectList(db.OrderConfirms, "id_OrderConfirm", "name", custumerOrder.confirm);
            ViewBag.status = new SelectList(db.Status, "id_Status", "name", custumerOrder.status);
            ViewBag.fk_UserID = new SelectList(db.Userrs, "ID", "name", custumerOrder.fk_UserID);
            return View(custumerOrder);
        }

        // GET: CustumerOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustumerOrder custumerOrder = db.CustumerOrders.Find(id);
            if (custumerOrder == null)
            {
                return HttpNotFound();
            }
            return View(custumerOrder);
        }

        // POST: CustumerOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustumerOrder custumerOrder = db.CustumerOrders.Find(id);
            db.CustumerOrders.Remove(custumerOrder);
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
