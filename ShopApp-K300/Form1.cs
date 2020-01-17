using ShopApp_K300.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp_K300
{
    public partial class Form1 : Form
    {

        ShopDb db = new ShopDb();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnLogin.Location = new Point((this.ClientSize.Width - lblWelocome.Size.Width) / 2, this.ClientSize.Height - 100);
            lblWelocome.Text = "Welcome to Nestle";
            lblWelocome.Location = new Point((this.ClientSize.Width - lblWelocome.Size.Width) / 2, 50);
            
        }
        public void LoginDashboard()
        {
            
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                if (email != "" && password != "")
                {
                    Admin selectAdmin = db.Admins.FirstOrDefault(adm => adm.Email == email && adm.Password == password);
                    if (selectAdmin != null)
                    {
                        if (selectAdmin.Password == password)
                        {
                            lblError.Visible = false;
                            AdminDashboard adm = new AdminDashboard();
                            adm.ShowDialog();
                        }
                    }
                    Worker selecedWorker = db.Workers.FirstOrDefault(wr => wr.Email == email);
                    if (selecedWorker != null)
                    {
                        lblError.Visible = false;
                        if (selecedWorker.Password == password)
                        {
                            WorkerDashboard wrk = new WorkerDashboard();
                            wrk.ShowDialog();
                        }
                        else
                        {
                            lblError.Text = "Password doesn't correct";
                            lblError.Visible = true;
                        }
                    }
                    else
                    {
                        lblError.Text = "Email dosen't correct";
                        lblError.Visible = true;
                    }


                }
                else
                {
                    lblError.Text = "Please fill the all";
                    lblError.Visible = true;
                }
            }
        
    private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginDashboard();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                LoginDashboard();
            }
        }
    }
}
