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
    
    public partial class Userr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Userr()
        {
            this.CustumerOrders = new HashSet<CustumerOrder>();
            this.JobWorkers = new HashSet<JobWorker>();
            this.WarehouseAdditions = new HashSet<WarehouseAddition>();
        }
    
        public int ID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public Nullable<int> phone { get; set; }
        public Nullable<int> userType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustumerOrder> CustumerOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobWorker> JobWorkers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseAddition> WarehouseAdditions { get; set; }
    }
}
