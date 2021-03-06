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
    using System.Data.SqlClient;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using WHouse.Models;

    public partial class Userr
    {

        private MydataEntities1 db = new MydataEntities1();

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
        public string username { get; set; }
        public string password { get; set; }
        public Nullable<int> isBusy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustumerOrder> CustumerOrders { get; set; }
        public virtual IsBusy IsBusy1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobWorker> JobWorkers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseAddition> WarehouseAdditions { get; set; }



        public List<Userr> SelectFreeWorker()
        {
            //Prie� salyga isBusy yra 2 kas rei�kia kad yra laisvas
            List<Userr> list = db.Userrs.Where(a => a.userType == 3 && a.isBusy == 2).ToList();
            return list;
        }


        public int UpdateWorkerStarus(int user)
        {
            // Po salyga jau kei�iasi � 1 ir parodoma, pagal enumeratori�, kad tampa u�imtas.2
            string query="UPDATE Userr SET isBusy = '" + 1 + "' WHERE ID ='" + user + "'";
            SqlConnection connection = new SqlConnection(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aurimas\Desktop\sandelis\sandelis\WHouse\WHouse\App_Data\Mydata.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            sda.SelectCommand.ExecuteNonQuery();
            connection.Close();


            return 0;

        }
    }
}
