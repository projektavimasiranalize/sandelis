using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHouse.Models;

namespace WorkerEnvironment.Forms
{
    public partial class BaseForm : Form
    {
        public int workerID { get; }

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
            Timer timer = new Timer();
            timer.Tick += new EventHandler(TimerEvent);

            timer.Interval = 1000;//Viena sekunde
            timer.Start();

            timeLabel.Text = DateTime.Now.ToString("hh:mm");

            using (MydataEntities1 db = new MydataEntities1())
            {
                var obj = db.Userrs.FirstOrDefault(a => a.ID == workerID);


            }
        }

        private void TimerEvent(Object myObject,
            EventArgs myEventArgs)
        {
            timeLabel.Text = DateTime.Now.ToString("hh:mm");
        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
