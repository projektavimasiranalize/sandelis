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
    public class OrderProductsController : Controller
    {
        private MydataEntities1 db = new MydataEntities1();

        // GET: OrderProducts
        public ActionResult Index()
        {
            var orderProducts = db.OrderProducts.Include(o => o.CustumerOrder).Include(o => o.Inventory);
            return View(orderProducts.ToList());
        }

        public ActionResult OrderList()
        {
            var orderProducts = db.OrderProducts.Include(o => o.CustumerOrder).Include(o => o.Inventory);
            return View(orderProducts.ToList());
        }

        // GET: OrderProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderProduct orderProduct = db.OrderProducts.Find(id);
            if (orderProduct == null)
            {
                return HttpNotFound();
            }
            return View(orderProduct);
        }

        // GET: OrderProducts/Create
        public ActionResult Create()
        {
            ViewBag.fk_CustumerOrderorderNumer = new SelectList(db.CustumerOrders, "orderNumer", "orderNumer");
            ViewBag.fk_Inventoryproduct_numer = new SelectList(db.Inventories, "product_numer", "productName");
            return View();
        }

        // POST: OrderProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "amount,id_OrderProduct,fk_CustumerOrderorderNumer,fk_Inventoryproduct_numer")] OrderProduct orderProduct)
        {
            if (ModelState.IsValid)
            {
                db.OrderProducts.Add(orderProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_CustumerOrderorderNumer = new SelectList(db.CustumerOrders, "orderNumer", "orderNumer", orderProduct.fk_CustumerOrderorderNumer);
            ViewBag.fk_Inventoryproduct_numer = new SelectList(db.Inventories, "product_numer", "productName", orderProduct.fk_Inventoryproduct_numer);
            return View(orderProduct);
        }

        // GET: OrderProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderProduct orderProduct = db.OrderProducts.Find(id);
            if (orderProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_CustumerOrderorderNumer = new SelectList(db.CustumerOrders, "orderNumer", "orderNumer", orderProduct.fk_CustumerOrderorderNumer);
            ViewBag.fk_Inventoryproduct_numer = new SelectList(db.Inventories, "product_numer", "productName", orderProduct.fk_Inventoryproduct_numer);
            return View(orderProduct);
        }

        // POST: OrderProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "amount,id_OrderProduct,fk_CustumerOrderorderNumer,fk_Inventoryproduct_numer")] OrderProduct orderProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_CustumerOrderorderNumer = new SelectList(db.CustumerOrders, "orderNumer", "orderNumer", orderProduct.fk_CustumerOrderorderNumer);
            ViewBag.fk_Inventoryproduct_numer = new SelectList(db.Inventories, "product_numer", "productName", orderProduct.fk_Inventoryproduct_numer);
            return View(orderProduct);
        }

        // GET: OrderProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderProduct orderProduct = db.OrderProducts.Find(id);
            if (orderProduct == null)
            {
                return HttpNotFound();
            }
            return View(orderProduct);
        }

        // POST: OrderProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderProduct orderProduct = db.OrderProducts.Find(id);
            db.OrderProducts.Remove(orderProduct);
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
