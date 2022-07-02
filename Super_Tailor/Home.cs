using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Tailor
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void exitSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        } 


        private void addCustomerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Add_Customer ac1 = new Add_Customer();
            ac1.Show();
            this.Hide();
        }

        

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Product ap1 = new Add_Product();
            this.Hide();
            ap1.Show();
        }

        private void generateBillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenBilling g1 = new GenBilling();
            g1.Show();
            this.Hide();
        }
      
           
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void Home_Load(object sender, EventArgs e) { }
        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void ubbutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To know about me, Yoou will be redireced to Facebook account..!!!!!!!!!!!");
            System.Diagnostics.Process.Start("https://www.facebook.com/arbaz.murme");
        }

        private void eixtSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
