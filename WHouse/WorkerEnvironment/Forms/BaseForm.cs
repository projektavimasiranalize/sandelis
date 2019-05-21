using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHouse.Models;

namespace WorkerEnvironment.Forms
{
    public partial class BaseForm : Form
    {
        public int workerID { get; }
        private DateTime time { get; set; }
        private OrderJob currentJob { get; set; }

        private Timer clockTimer = new Timer();
        private Timer activeJobTimer = new Timer();
        private Timer jobTotalTimer = new Timer();

        private long diffTicks;

        private bool timerHasBeenStarted = false;

        public BaseForm(int ID)
        {
            InitializeComponent();

            workerID = ID;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            clockTimer.Tick += new EventHandler(TimerEvent);

            clockTimer.Interval = 1000;//Viena sekunde
            clockTimer.Start();

            timeLabel.Text = DateTime.Now.ToString("hh:mm");
            taskLabel.Visible = false;

            LoadCurrentJob();
        }

        private void LoadCurrentJob()
        {
            using (MydataEntities1 db = new MydataEntities1())
            {
                var worker = db.Userrs.FirstOrDefault(a => a.ID == workerID);

                var jobs = db.JobWorkers.Where(a => a.fk_UserID == worker.ID).ToList();

                currentJob = null;

                foreach (var item in jobs)
                {
                    var jobInList =
                        db.OrderJobs.FirstOrDefault(a => a.status == 1 && a.fk_JobworkNumer == item.id_JobWorker);

                    if (jobInList == null) continue;

                    currentJob = jobInList;
                    break;
                }

                if (currentJob == null)
                {
                    noTasksLabel.Text = "Šiuo metu neturite priskirtų darbų, galite pailsėti :)";

                    if (timerHasBeenStarted) return;

                    activeJobTimer.Tick += new EventHandler(CheckForActiveJobs);
                    activeJobTimer.Interval = 1000;
                    activeJobTimer.Start();

                    ToogleJobInfo(false);

                    timerHasBeenStarted = !timerHasBeenStarted;
                }
                else
                {
                    playSimpleSound();

                    ToogleJobInfo(true);
                    taskPlaceLabel.Text = "Sandėlys " + currentJob.place;

                    jobTotalTimer.Tick += new EventHandler(UpdateTotalJobTime);
                    jobTotalTimer.Interval = 1000;
                    jobTotalTimer.Start();

                    activeJobTimer.Stop();
                }
            }
        }

        private void ToogleJobInfo(bool toogle)
        {
            finishButton.Visible = toogle;
            placeDescLabel.Visible = toogle;
            taskPlaceLabel.Visible = toogle;

            noTasksLabel.Visible = !toogle;
        }

        private void TimerEvent(Object myObject,
            EventArgs myEventArgs)
        {
            timeLabel.Text = DateTime.Now.ToString("hh:mm");
        }

        private void CheckForActiveJobs(Object myObject,
            EventArgs myEventArgs)
        {
            LoadCurrentJob();
        }

        private void UpdateTotalJobTime(Object myObject,
            EventArgs myEventArgs)
        {
            taskLabel.Visible = true;

            DateTime jobStartTime = DateTime.Parse(currentJob.start.ToString());

            diffTicks = (DateTime.Now - jobStartTime).Ticks;
            taskLabel.Text = FormatToTime(diffTicks);
        }

        private string FormatToTime(long ticks)
        {
            TimeSpan span = new TimeSpan(diffTicks);

            return String.Format("{0:00}:{1:00}:{2:00}", span.Hours, span.Minutes % 60, span.Seconds % 3600);
        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            UpdateDatabase("UPDATE OrderJob SET status = '" + 2 + "' WHERE id_OrderJob ='" + currentJob.id_OrderJob + "'");
            UpdateDatabase("UPDATE Userr SET isBusy = '" + 1 + "' WHERE ID ='" + workerID + "'");

            activeJobTimer.Stop();
            jobTotalTimer.Stop();
            clockTimer.Stop();

            MessageBox.Show("Jūs užbaigėte paskirtą užduotį per " + FormatToTime(diffTicks),"Užduoties pabaiga");

            BaseForm form = new BaseForm(workerID);
            form.Show();
            Close();
        }

        private void UpdateDatabase(string query)
        {
            SqlConnection connection = new SqlConnection(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\PROJECTS\Analize\sandelis\WHouse\WHouse\App_Data\Mydata.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            sda.SelectCommand.ExecuteNonQuery();
            connection.Close();
        }

        private void taskPlaceLabel_Click(object sender, EventArgs e)
        {

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Close();

            form.Show();

            clockTimer.Stop();
            activeJobTimer.Stop();
            jobTotalTimer.Stop();
        }

        private void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            simpleSound.Play();
        }
    }
}
