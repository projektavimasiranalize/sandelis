using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WHouse.Models;

namespace WHouse.Controllers
{
    public class WarehouseController : Controller
    {
        // GET: Warehouse
        public ActionResult Index()
        {
            MydataEntities db = new MydataEntities();
            //List<Warehouse> list = db.Warehouses.ToList();
            //List<Warehouse> lis = list.Select(x => new Warehouse
            //{
            //    adress = x.adress,
            //    capacity = x.capacity,
            //    id_Warehouse = x.id_Warehouse
            //}
            //).ToList();
            //Warehouse wares = new Warehouse();

            return View();

        }

        [HttpPost]
        public ActionResult SaveRecord(Warehouse model)
        {
            try
            {
                MydataEntities db = new MydataEntities();

                List<Warehouse> list = db.Warehouses.ToList();

                ViewBag.DepartmentList = new SelectList(list, "DepartmentId", "DepartmentName");

                Warehouse emp = new Warehouse();
                emp.adress = model.adress;
                emp.capacity = model.capacity;
                emp.id_Warehouse = model.id_Warehouse;
                db.Warehouses.Add(emp);
                db.SaveChanges();
                int latestEmpId = emp.id_Warehouse;
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}