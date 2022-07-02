using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Super_Tailor
{
    public partial class GenBilling : Super_Tailor.Home
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=arbaz-pc;Initial Catalog=arbaz;Integrated Security=True");
        string id;
        string sname;
        SqlDataReader reader;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public GenBilling()
        {
            InitializeComponent();
            CBSelect();
            PBSelect();
            DisplayData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select Cust_id from Consumer where Name =  '" + comboBox1.Text + "';";
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
               {
                  id = reader.GetInt32(0).ToString();
                  txtName.Text = id;
               }
             conn.Close();
         }

        public void CBSelect()
        {
            string sql = "select * from Consumer";
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
                        {
                            sname = reader.GetString(1);
                            comboBox1.Items.Add(sname);
                        }
                    conn.Close(); 
        }

        

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql1 = "select Product_Price from Product where Prod_id =  '" + comboBox2.Text + "';";
            conn.Open();
            cmd = new SqlCommand(sql1, conn);
            reader = cmd.ExecuteReader();
            if      (reader.Read()) txtPP.Text = Convert.ToString(reader["Product_Price"]);
            else    MessageBox.Show("Now Data Found");
                
            conn.Close();
        }



        private void PBSelect()
        {
            string sql = "select * from Product";
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string id1 = reader.GetInt32(0).ToString();
                comboBox2.Items.Add(id1);
            }
            conn.Close();
        }



        private void GenBilling_Load(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void txtTA_TextChanged(object sender, EventArgs e) { }
        private void txtName_TextChanged_1(object sender, EventArgs e) { }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && txtName.Text != "" && comboBox2.Text != "" && txtPP.Text != "" && comboQty.Text != "")
           {
               cmd = new SqlCommand("insert into bill(Cust_name,Cust_id,Prod_id,Prod_Price,DD,ED,Qty,TA) values(@Cust_name, @Cust_id, @Prod_id, @Prod_Price, @DD, @ED, @Qty, @TA)", conn);
               conn.Open();

               cmd.Parameters.AddWithValue("@Cust_name", comboBox1.Text);
               cmd.Parameters.AddWithValue("@Cust_id", txtName.Text);
               cmd.Parameters.AddWithValue("@Prod_id", comboBox2.Text);
               cmd.Parameters.AddWithValue("@Prod_Price", txtPP.Text);
               cmd.Parameters.AddWithValue("@DD", DateTime.Parse(DD.Text));
               cmd.Parameters.AddWithValue("@ED", DateTime.Parse(ED.Text));
               cmd.Parameters.AddWithValue("@Qty", comboQty.Text);
               cmd.Parameters.AddWithValue("@TA", txtTA.Text);
               cmd.ExecuteNonQuery();
               conn.Close();
                DisplayData();
                MessageBox.Show("Record Inserted Successfully");
               
           }
           else
           {
               MessageBox.Show("Please Provide Details!");
           }
        }

        private void Total_Amount()
        {
            try
            {
                int first = Convert.ToInt32(txtPP.Text);
                int second = Convert.ToInt32(comboQty.Text);
                txtTA.Text = (first * second).ToString();
            }
            catch (Exception )
            {

                MessageBox.Show("plzz.. Select Cloth Id");
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (BID > 0)
            {
                cmd = new SqlCommand("update bill set Cust_name=@Cust_name,    Cust_id=@Cust_id,   Prod_id=@Prod_id,  Prod_Price=@Prod_Price,   DD=@DD,   ED=@ED,   Qty=@Qty,  TA=@TA   where B_id = @BID", conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@Cust_name", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Cust_id", txtName.Text);
                cmd.Parameters.AddWithValue("@Prod_id", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Prod_Price", txtPP.Text);
                cmd.Parameters.AddWithValue("@DD", DateTime.Parse(DD.Text));
                cmd.Parameters.AddWithValue("@ED", DateTime.Parse(ED.Text));
                cmd.Parameters.AddWithValue("@Qty", comboQty.Text);
                cmd.Parameters.AddWithValue("@TA", txtTA.Text);
                cmd.Parameters.AddWithValue("@BID", BID);
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Update Successfully!");
                conn.Close();
                DisplayData();
                ClearData();
            }

            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }


        private void DisplayData()
        {
            conn.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from bill", conn);
            adapt.Fill(dt);
            dataGridView3.DataSource = dt;
            conn.Close();
        }

        private void ClearData()
        {
            comboBox1.Text = "";
            txtName.Text = "";
            comboBox2.Text = "";
            txtPP.Text = "";
            DD.Text = "";
            ED.Text = "";
            comboQty.Text = "";
            txtTA.Text = "";
            BID = 0;
        }
        int BID = 0;
        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                BID = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells[0].Value);
                comboBox1.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
                txtName.Text = dataGridView3.SelectedRows[0].Cells[2].Value.ToString();
                comboBox2.Text = dataGridView3.SelectedRows[0].Cells[3].Value.ToString();
                txtPP.Text = dataGridView3.SelectedRows[0].Cells[4].Value.ToString();
                DD.Text = dataGridView3.SelectedRows[0].Cells[5].Value.ToString();
                ED.Text = dataGridView3.SelectedRows[0].Cells[6].Value.ToString();
                comboQty.Text = dataGridView3.SelectedRows[0].Cells[7].Value.ToString();
                txtTA.Text = dataGridView3.SelectedRows[0].Cells[8].Value.ToString(); 
            }
            catch (Exception)
            {
                MessageBox.Show("fild is empty");
            }
            
        }

        private void comboQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Total_Amount();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Print p1 = new Print();
            p1.Show();
        }
    }
}
