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
    public class InventoriesController : Controller
    {
        private MydataEntities1 db = new MydataEntities1();

        // GET: Inventories
        public ActionResult Index()
        {
            var inventories = db.Inventories.Include(i => i.Rack);
            return View(inventories.ToList());
        }

        public ActionResult MakeAnOrder()
        {
            var inventories = db.Inventories.Include(i => i.Rack);
            return View(inventories.ToList());
        }

        // GET: Inventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventories/Create
        public ActionResult Create()
        {
            ViewBag.fk_Rackid_Rack = new SelectList(db.Racks, "id_Rack", "adress");
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "product_numer,productName,adress,fk_Rackid_Rack")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Inventories.Add(inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_Rackid_Rack = new SelectList(db.Racks, "id_Rack", "adress", inventory.fk_Rackid_Rack);
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_Rackid_Rack = new SelectList(db.Racks, "id_Rack", "adress", inventory.fk_Rackid_Rack);
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_numer,productName,adress,fk_Rackid_Rack")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_Rackid_Rack = new SelectList(db.Racks, "id_Rack", "adress", inventory.fk_Rackid_Rack);
            return View(inventory);
        }

        public ActionResult Make2(int id)
        {//, int count
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //int testas = count;

            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }


            //Naujas produktas, kuris bus priskiriamas uzsakymui.
            OrderProduct order = new OrderProduct();

            var obj = db.OrderProducts.ToList().Last();
            int idcount = obj.id_OrderProduct + 1;

                       
            string LoggedInId = Session["ID"].ToString();
            int xd = Int32.Parse(LoggedInId);
            Userr userr = db.Userrs.Find(xd);

            //CustumerOrder custumerOrder1 = db.CustumerOrders.Find(xd);
            //if (custumerOrder1 == null)
            //{
            //    CustumerOrder custumerOrder2 = new CustumerOrder();
            //    custumerOrder2.fk_UserID = xd;

            //}
            //else
            //{
            //    custumerOrder2 =  custumerOrder1();
            //}

            


            CustumerOrder custumerOrder = db.CustumerOrders.Find(xd);


            order.id_OrderProduct = idcount;
            order.name = inventory.productName;
            order.fk_Inventoryproduct_numer = id;
            order.fk_CustumerOrderorderNumer = custumerOrder.orderNumer;
            custumerOrder.fk_UserID = xd;

            db.OrderProducts.Add(order);
            db.SaveChanges();
            return View();
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
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
