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

    public partial class OrderJob
    {
        private MydataEntities1 db = new MydataEntities1();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderJob()
        {
            this.JobWorkers = new HashSet<JobWorker>();
        }
    
        public Nullable<System.DateTime> start { get; set; }
        public string place { get; set; }
        public Nullable<int> status { get; set; }
        public int id_OrderJob { get; set; }
        public int fk_JobworkNumer { get; set; }
        public int fk_WarehouseAdditionadditionNumer { get; set; }
        public int fk_CustumerOrderorderNumer { get; set; }
    
        public virtual CustumerOrder CustumerOrder { get; set; }
        public virtual Job Job { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobWorker> JobWorkers { get; set; }
        public virtual WarehouseAddition WarehouseAddition { get; set; }
        public virtual Status Status1 { get; set; }


        public int InsertOrderJob(int jobid, int orderid)
        {
            
            OrderJob emp = new OrderJob();
            
            //emp.id_OrderJob = rnd.Next(10, 100)+ rnd.Next(10, 1000)+rnd.Next(10, 10000)+rnd.Next(10, 10000)+rnd.Next(10, 10000)+rnd.Next(10, 50);
            var obj2 = db.OrderJobs.ToList().Last();
            var obj = db.OrderJobs.Where(a => a.id_OrderJob.Equals(emp.id_OrderJob)).FirstOrDefault();
            int idcount = obj2.id_OrderJob+1;
            if (obj == null)
            {
                emp.id_OrderJob = idcount + 1;
                emp.start = DateTime.Now;
                emp.status = 4;
                emp.fk_JobworkNumer = jobid;
                emp.fk_CustumerOrderorderNumer = orderid;
                emp.fk_WarehouseAdditionadditionNumer = 1;
                db.OrderJobs.Add(emp);
                db.SaveChanges();
                return emp.id_OrderJob;
            }
            return 0;
        }
    }
}

