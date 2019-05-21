using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHouse.Models;

namespace WorkerEnvironment.Controllers
{
    public static class JobExecutionController
    {
        public static void UpdateDatabase(string dataSet,string property,int updatedData, string comparison, int IDtoCompare)
        {
            string query = "UPDATE " + dataSet + " SET " + property + " = '" + updatedData + "' WHERE " + comparison +
                           " = '" + IDtoCompare + "'";

            SqlConnection connection = new SqlConnection(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aurimas\Desktop\sandelis\sandelis\WHouse\WHouse\App_Data\Mydata.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            sda.SelectCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static OrderJob GetOrderJob(int workerID)
        {
            using (MydataEntities1 db = new MydataEntities1())
            {
                var worker = db.Userrs.FirstOrDefault(a => a.ID == workerID);

                var jobs = db.JobWorkers.Where(a => a.fk_UserID == worker.ID).ToList();

                OrderJob currentJob = null;

                foreach (var item in jobs)
                {
                    var jobInList =
                        db.OrderJobs.FirstOrDefault(a => a.status == 1 && a.id_OrderJob == item.fk_OrderJobid_OrderJob);

                    if (jobInList == null) continue;

                    currentJob = jobInList;
                    break;
                }

                return currentJob;
            }
        }

        public static Job GetJobDescription(OrderJob currentJob)
        {
            if (currentJob == null)
                return null;
            
            using (MydataEntities1 db = new MydataEntities1())
            {
                return db.Jobs.FirstOrDefault(a => a.workNumer == currentJob.fk_JobworkNumer);
            }
        }
    }
}
