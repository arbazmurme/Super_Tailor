using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Super_Tailor
{
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }

       


        private void button1_Click(object sender, EventArgs e)
        {
                ReportDocument rd = new ReportDocument();
                SqlConnection con = new SqlConnection(@"Data Source=arbaz-pc;Initial Catalog=arbaz;Integrated Security=True");
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("select * from bill where B_id = '" + textBox1.Text + "'",con);
                DataSet ds = new DataSet();
                adapt.Fill(ds, "bill");
                rd.Load(@"C:\Users\Arbaz\Documents\Visual Studio 2012\Projects\Super_Tailor\Super_Tailor\CrystalReport1.rpt");
                rd.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rd;
                con.Close();
        }
    }
}