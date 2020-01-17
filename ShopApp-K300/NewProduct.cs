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
        public NewProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string productName = txtProduct.Text;
            string price = txtPrice.Text;
            string Amount = txtAmount.Text;

            NewProduct np = new NewProduct();
            np.
        }
    }
}
