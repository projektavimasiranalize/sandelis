//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using WHouse.Models;

    public partial class OrderProduct
    {
        private MydataEntities1 db = new MydataEntities1();


        public Nullable<int> amount { get; set; }
        public int id_OrderProduct { get; set; }
        public int fk_CustumerOrderorderNumer { get; set; }
        public int fk_Inventoryproduct_numer { get; set; }
        public string name { get; set; }
        public virtual CustumerOrder CustumerOrder { get; set; }
        public virtual Inventory Inventory { get; set; }



        public List<OrderProduct> SelectProductsByOrder(int id)
        {
            List<OrderProduct> list = db.OrderProducts.Where(a => a.fk_CustumerOrderorderNumer == id).ToList();
            return list;


        }
    }
}
