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
    public partial class Register_Form : Form
    {
        ShopDb db;
        public Register_Form()
        {
            db = new ShopDb();
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullname = txtFullname.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string password = txtPassword.Text;
            string confirmpas = txtConfirm.Text;
            string[] myempty = { fullname, email, password, confirmpas };

            if(mainExtensions.IsEmpty(myempty,""))
            {
                if (password == confirmpas)
                {
                    //Worker newWorker = new Worker();
                    //newWorker.Fullname = fullname;
                    //newWorker.Email = email;
                    //newWorker.Password = password;
                    //newWorker.Phone = phone;
                    db.Workers.Add(new Worker()
                    {
                        Fullname = fullname,
                        Email = email,
                        Password = password,
                        Phone = phone
                });
                        
                    
                    db.SaveChanges();
                    MessageBox.Show("Worker create succesfully");

                }
                else
                {
                    lblError.Text = "Password and confirm password must be write";
                    lblError.Visible = true;
                }
            }
            else
            {

            }
        }

        
    }
}
