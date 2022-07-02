using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Super_Tailor
{
    public partial class Add_Product : Super_Tailor.Home
    {
        private SqlConnection con = new SqlConnection(@"Data Source=arbaz-pc;Initial Catalog=arbaz;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        public Add_Product()
        {
            InitializeComponent();
            DisplayData1();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            if (txtPId.Text != "" && txtPName.Text != "" && txtPRate.Text != "")
            {
                cmd = new SqlCommand("insert into Product(Prod_id, Product_Name, Product_Price) values(@PID,@Pname,@PPrice)", con);
                con.Open();

                cmd.Parameters.AddWithValue("@PID", txtPId.Text);
                cmd.Parameters.AddWithValue("@Pname", txtPName.Text);
                cmd.Parameters.AddWithValue("@PPrice", txtPRate.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Inserted Successfully");
                DisplayData1();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }

        private void ClearData()
        {
            txtPName.Text = "";
            txtPRate.Text = "";
            txtPId.Text = "";
        }

        private void DisplayData1()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from Product", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Add_Product_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPName.Text != "" && txtPId.Text != "" && txtPRate.Text != "")
            {
                if (txtPId.Text == txtPId.Text)
                {
                    con.Open();
                    cmd = new SqlCommand("update Product set Product_Name = @Product_Name, Product_Price = @Product_Price where Prod_id = @Prod_id ", con);

                    cmd.Parameters.AddWithValue("@Prod_id", txtPId.Text);
                    cmd.Parameters.AddWithValue("@Product_Name", txtPName.Text);
                    cmd.Parameters.AddWithValue("@Product_Price", txtPRate.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully");
                    con.Close();
                    DisplayData1();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("You Not update Prodact ID");
                }
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtPId.ReadOnly = true;
            txtPId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtPName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtPRate.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtPName.Text != "" && txtPId.Text != "" && txtPRate.Text != "")
            {
                cmd = new SqlCommand("delete Product where Prod_id = @Prod_id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Prod_id", txtPId.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully!");
                con.Close();
                DisplayData1();
                ClearData();
            }

            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void txtPId_TextChanged(object sender, EventArgs e) { PIIsValid(txtPId.Text); }
        public bool PIIsValid(string n)
        {
            Regex check1 = new Regex(@"^[0-9]{0,10}$");
            bool valid = false;
            valid = check1.IsMatch(n);
            if (valid == true)
            {
                return valid;
            }

            else
            {
                MessageBox.Show("Invalid Cloth Id. numeric only");
                txtPId.Focus();
                return valid;
            }
        }

        private void txtPName_TextChanged(object sender, EventArgs e) { ClothIsValid(txtPName.Text); }
        public bool ClothIsValid(string n)
        {
            Regex check = new Regex("^[a-z -']+$");
            bool valid = false;
            valid = check.IsMatch(n);
            if (valid == true)
            {
                return false;
            }
            else if (txtPName.Text == "")
            {
                return valid;
            }
            else
            {
                MessageBox.Show("Invalid Cloth name");
                txtPName.Focus();
                return valid;
            }

        }

        private void txtPRate_TextChanged(object sender, EventArgs e) { PRIsValid(txtPRate.Text);  }
        public bool PRIsValid(string n)
        {
            Regex check1 = new Regex(@"^[0-9]{0,10}$");
            bool valid = false;
            valid = check1.IsMatch(n);
            if (valid == true)
            {
                return valid;
            }

            else
            {
                MessageBox.Show("Invalid Cloth Rate");
                txtPRate.Focus();
                return valid;
            }
        }

    }
}