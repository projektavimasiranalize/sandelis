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

        private void inputButton_Click(object sender, EventArgs e)
        {
            LoadingScreenToogle();
            using (MydataEntities1 db = new MydataEntities1())
            {
                var obj = db.Userrs.Where(a => a.username.Equals(usernameInput.Text) && a.password.Equals(passwordInput.Text)).FirstOrDefault();
                if (obj != null)
                {
                    LoadingScreenToogle();
                    if (obj.userType != 3)
                        MessageBox.Show("Turite būti sandėlio darbuotojas, kad galėtumėte prisijungti.","Klaida");
                    else
                    {
                        BaseForm form = new BaseForm(obj.ID);
                        form.Show();
                        Hide();
                    }
                }
                else
                {
                    LoadingScreenToogle();

                    MessageBox.Show("Įvedėte neteisingą prisijungimo vardą arba slaptažodį.","Klaida");
                    usernameInput.Text = "";
                    passwordInput.Text = "";
                }
            }
        }

        private void LoadingScreenToogle()
        {
            loadingScreen.Visible = !loadingScreen.Visible;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadingScreen.Visible = false;
        }

        private void passwordInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
