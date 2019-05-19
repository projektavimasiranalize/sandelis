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
    public class RacksController : Controller
    {
        private MydataEntities db = new MydataEntities();

        // GET: Racks
        public ActionResult Index()
        {
            var racks = db.Racks.Include(r => r.Room);
            return View(racks.ToList());
        }

        // GET: Racks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rack rack = db.Racks.Find(id);
            if (rack == null)
            {
                return HttpNotFound();
            }
            return View(rack);
        }

        // GET: Racks/Create
        public ActionResult Create()
        {
            ViewBag.fk_Roomid_Room = new SelectList(db.Rooms, "id_Room", "name");
            return View();
        }

        // POST: Racks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "adress,id_Rack,fk_Roomid_Room")] Rack rack)
        {
            if (ModelState.IsValid)
            {
                db.Racks.Add(rack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_Roomid_Room = new SelectList(db.Rooms, "id_Room", "name", rack.fk_Roomid_Room);
            return View(rack);
        }

        // GET: Racks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rack rack = db.Racks.Find(id);
            if (rack == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_Roomid_Room = new SelectList(db.Rooms, "id_Room", "name", rack.fk_Roomid_Room);
            return View(rack);
        }

        // POST: Racks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "adress,id_Rack,fk_Roomid_Room")] Rack rack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_Roomid_Room = new SelectList(db.Rooms, "id_Room", "name", rack.fk_Roomid_Room);
            return View(rack);
        }

        // GET: Racks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rack rack = db.Racks.Find(id);
            if (rack == null)
            {
                return HttpNotFound();
            }
            return View(rack);
        }

        // POST: Racks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rack rack = db.Racks.Find(id);
            db.Racks.Remove(rack);
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
