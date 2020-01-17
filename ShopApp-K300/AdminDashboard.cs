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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void addWorkersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register_Form rg = new Register_Form();
            rg.ShowDialog();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProduct np = new NewProduct();
            np.ShowDialog();
        }
    }
}
