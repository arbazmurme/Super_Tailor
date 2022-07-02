using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace Super_Tailor
{

    public partial class Add_Customer : Super_Tailor.Home
    {
        private SqlConnection con = new SqlConnection( @"Data Source=arbaz-pc;Initial Catalog=arbaz;Integrated Security=True");
      //  con.ConnectionString =";
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int ID = 0;

        public Add_Customer()
        {
            InitializeComponent();
            DisplayData();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
                    
                        if (txtFName.Text != "" && txtMobile.Text != "" && txtEmail.Text != "" && txtAdd.Text != "")
                        {
                            if (EmailIsValid(txtEmail.Text) == false)
                            {
                                MessageBox.Show("Invalid Email ID");
                            }
                            else
                            {
                                cmd = new SqlCommand("insert into Consumer(Name,Mobile,Email,Address) values(@Name,@Mobile,@Email,@Address)", con);
                                con.Open();

                                cmd.Parameters.AddWithValue("@Name", txtFName.Text);
                                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                                cmd.Parameters.AddWithValue("@Address", txtAdd.Text);
                                cmd.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Record Inserted Successfully");
                                DisplayData();
                                ClearData(); 
                            }
                        }
                   
            
            else
            {
                     MessageBox.Show("Please Provide Details!");
            }
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from Consumer", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void ClearData()
        {
            txtFName.Text ="";
            txtMobile.Text ="";
            txtEmail.Text ="";
            txtAdd.Text = "";
            ID = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("delete Consumer where Cust_id = @Cust_id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Cust_id", ID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully!");
                con.Close();
                DisplayData();
                ClearData();
            }

            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ID > 0)
                {
                cmd = new SqlCommand("update Consumer set Name = @Name, Mobile = @Mobile, Email = @Email, Address = @Address where Cust_id = @id", con);
                con.Open();

                cmd.Parameters.AddWithValue("@Name", txtFName.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Address", txtAdd.Text);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                
                con.Close();
                DisplayData();
                ClearData();
                }
            else
            {
              MessageBox.Show("Please Select Record to Update");
            }  
        }

       private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            txtFName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtMobile.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtAdd.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

       private void Add_Customer_Load(object sender, EventArgs e) { }
       private void txtEmail_TextChanged(object sender, EventArgs e) {  }
       private void txtFName_TextChanged(object sender, EventArgs e) { NameIsValid(txtFName.Text); }
       private void txtMobile_TextChanged(object sender, EventArgs e) { NumIsValid(txtMobile.Text); }


        public bool NameIsValid(string n)
        {
            Regex check = new Regex("^[a-z -']+$");
            bool valid = false;
            valid = check.IsMatch(n);
            if (valid == true)
            {
                return false;
            }
            else if (txtFName.Text=="")
            {
                return valid;
            }
            else
            {
                MessageBox.Show("Invalid full name");
                txtFName.Focus();
                return valid;
            }
        }

        public bool NumIsValid(string n)
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
                MessageBox.Show("Invalid mobile number");
                txtMobile.Focus(); 
                return valid;
            }
        }


        public bool EmailIsValid(string n)
        {
            /*Regular Expressions for email id*/
            Regex check1 = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            bool valid = false;
            valid = check1.IsMatch(n);
            if (valid == true)
            {
                return true;
            }

            else
            {
                txtEmail.Focus();
                return false;
            }
        }

    }
}
 