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
    public class ProductToAddsController : Controller
    {
        private MydataEntities1 db = new MydataEntities1();

        // GET: ProductToAdds
        public ActionResult Index()
        {
            var productToAdds = db.ProductToAdds.Include(p => p.Inventory).Include(p => p.WarehouseAddition);
            return View(productToAdds.ToList());
        }

        // GET: ProductToAdds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductToAdd productToAdd = db.ProductToAdds.Find(id);
            if (productToAdd == null)
            {
                return HttpNotFound();
            }
            return View(productToAdd);
        }

        // GET: ProductToAdds/Create
        public ActionResult Create()
        {
            ViewBag.fk_Inventoryproduct_numer = new SelectList(db.Inventories, "product_numer", "productName");
            ViewBag.fk_WarehouseAdditionadditionNumer = new SelectList(db.WarehouseAdditions, "additionNumer", "additionNumer");
            return View();
        }

        // POST: ProductToAdds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "amount,id_ProductToAdd,fk_Inventoryproduct_numer,fk_WarehouseAdditionadditionNumer")] ProductToAdd productToAdd)
        {
            if (ModelState.IsValid)
            {
                db.ProductToAdds.Add(productToAdd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_Inventoryproduct_numer = new SelectList(db.Inventories, "product_numer", "productName", productToAdd.fk_Inventoryproduct_numer);
            ViewBag.fk_WarehouseAdditionadditionNumer = new SelectList(db.WarehouseAdditions, "additionNumer", "additionNumer", productToAdd.fk_WarehouseAdditionadditionNumer);
            return View(productToAdd);
        }

        // GET: ProductToAdds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductToAdd productToAdd = db.ProductToAdds.Find(id);
            if (productToAdd == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_Inventoryproduct_numer = new SelectList(db.Inventories, "product_numer", "productName", productToAdd.fk_Inventoryproduct_numer);
            ViewBag.fk_WarehouseAdditionadditionNumer = new SelectList(db.WarehouseAdditions, "additionNumer", "additionNumer", productToAdd.fk_WarehouseAdditionadditionNumer);
            return View(productToAdd);
        }

        // POST: ProductToAdds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "amount,id_ProductToAdd,fk_Inventoryproduct_numer,fk_WarehouseAdditionadditionNumer")] ProductToAdd productToAdd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productToAdd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_Inventoryproduct_numer = new SelectList(db.Inventories, "product_numer", "productName", productToAdd.fk_Inventoryproduct_numer);
            ViewBag.fk_WarehouseAdditionadditionNumer = new SelectList(db.WarehouseAdditions, "additionNumer", "additionNumer", productToAdd.fk_WarehouseAdditionadditionNumer);
            return View(productToAdd);
        }

        // GET: ProductToAdds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductToAdd productToAdd = db.ProductToAdds.Find(id);
            if (productToAdd == null)
            {
                return HttpNotFound();
            }
            return View(productToAdd);
        }

        // POST: ProductToAdds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductToAdd productToAdd = db.ProductToAdds.Find(id);
            db.ProductToAdds.Remove(productToAdd);
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
