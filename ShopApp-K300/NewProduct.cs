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
    public partial class NewProduct : Form
    {
        ShopDb db = new ShopDb();
        public NewProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string productName = txtProduct.Text;
            string price = txtPrice.Text;
            string Amount = txtAmount.Text;
            string category = cmbCategory.Text;
            string size = cmbSize.Text;
            string desc = rcDescription.Text;
            string[] emp = { productName, price, Amount, category, size };
            if (mainExtensions.IsEmpty(emp, string.Empty))
            {
                int catId = db.Categories.First(ct => ct.Name == category).Id;
                int sizeId = db.ProductSizes.First(ct => ct.Size == size).Id;

                db.Products.Add(new Product()
                {
                    ProductName = productName,
                    Price = Convert.ToDouble(price),
                    Amount=Convert.ToInt32(Amount),
                    CategoryId=catId,
                    SizeId= sizeId,
                    Description=desc
                });
                db.SaveChanges();
                MessageBox.Show("Product create succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar>57)&& e.KeyChar!=8)
            {
                e.Handled = true;
            }
        }

        private void NewProduct_Load(object sender, EventArgs e)
        {
            cmbCategory.Items.Add("Selected...");
            cmbCategory.SelectedIndex = 0;
            cmbCategory.Items.AddRange(db.Categories.Select(ct => ct.Name).ToArray());
            cmbSize.Items.AddRange(db.ProductSizes.Select(ct => ct.Size).ToArray());

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCategory.Items.Remove("Selected...");
        }
    }
}
