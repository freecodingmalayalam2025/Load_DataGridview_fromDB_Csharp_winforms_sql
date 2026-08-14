using Microsoft.Data.SqlClient;
using System.Data;

namespace WinFormsApp_datagridview
{
    public partial class Form1 : Form
    {
        string strcon = "Data Source=LAPTOP-R9MRDLN3\\SQLEXPRESS;Initial Catalog=FreeCodingDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
        SqlConnection con;
        public Form1()
        {
            InitializeComponent();
        }


        private void LoadCustomer()
        {
            try
            {
                using (con = new SqlConnection(strcon))
                {
                    con.Open();
                    // string strqry = "select Id as CustId, FirstName as [First Name],LastName as [Last Name],Phone from customer";
                    string strqry = "select Id , FirstName ,LastName  from customer";
                    SqlDataAdapter sda = new SqlDataAdapter(strqry, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = dt;
                    //dgv.Columns[0].Visible = false;
                }
                    

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCustomer();
        }
    }
}
