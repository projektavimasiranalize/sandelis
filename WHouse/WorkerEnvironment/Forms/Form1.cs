using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHouse.Models;
using WorkerEnvironment.Forms;

namespace WorkerEnvironment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void inputButton_Click(object sender, EventArgs e)
        {
            using (MydataEntities1 db = new MydataEntities1())
            {
                var obj = db.Userrs.Where(a => a.username.Equals(usernameInput.Text) && a.password.Equals(passwordInput.Text)).FirstOrDefault();
                if (obj != null)
                {
                    if (obj.userType != 3)
                        MessageBox.Show("You must be a worker to log in");
                    else
                    {
                        BaseForm form = new BaseForm(obj.ID);
                        this.Hide();
                        form.Show();
                    }
                }
                else
                    MessageBox.Show("You have entered wrong username or password");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
