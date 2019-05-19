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
    public class UserrsController : Controller
    {
        private MydataEntities db = new MydataEntities();

        // GET: Userrs
        public ActionResult Index()
        {
            return View(db.Userrs.ToList());
        }

        // GET: Userrs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userr userr = db.Userrs.Find(id);
            if (userr == null)
            {
                return HttpNotFound();
            }
            return View(userr);
        }

        // GET: Userrs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Userrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,surname,phone,userType")] Userr userr)
        {
            if (ModelState.IsValid)
            {
                db.Userrs.Add(userr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userr);
        }

        // GET: Userrs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userr userr = db.Userrs.Find(id);
            if (userr == null)
            {
                return HttpNotFound();
            }
            return View(userr);
        }

        // POST: Userrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,surname,phone,userType")] Userr userr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userr);
        }

        // GET: Userrs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userr userr = db.Userrs.Find(id);
            if (userr == null)
            {
                return HttpNotFound();
            }
            return View(userr);
        }

        // POST: Userrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Userr userr = db.Userrs.Find(id);
            db.Userrs.Remove(userr);
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
