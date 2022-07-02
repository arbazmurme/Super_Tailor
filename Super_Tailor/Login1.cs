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
    public partial class Login1 : Form
    {
        public Login1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

             if (txtUserName.Text == "arbaz" && txtPass.Text == "143")
             {
                 Home h1 = new Home();
                 this.Hide();
                 h1.Show();
             }
             else
             {
                 if (txtUserName.Text != "arbaz" && txtPass.Text == "143")
                 {
                     MessageBox.Show("User   Name   Is Wrong");
                 }
                 else if (txtPass.Text != "123" && txtUserName.Text == "arbaz")
                 {
                     MessageBox.Show("Password   Is   Wrong");
                 }
                 else
                 {
                     MessageBox.Show("Password   " + "&    " + "User Name    " + "Is Wrong");
                 }
             }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login1_Load(object sender, EventArgs e)
        {

        }       
    }
}
