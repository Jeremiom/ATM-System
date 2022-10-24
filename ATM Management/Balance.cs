using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Management
{
    public partial class Balance : Form
    {
        public Balance()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\ProjectModels;Initial Catalog=model;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private void getBalance()
        {
            Con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(" select Balance from AccountTbl where AccNum='"+AccNumlbl.Text+"'", Con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Balancelbl.Text= "$"+dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void label5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Balance_Load(object sender, EventArgs e)
        {
            AccNumlbl.Text = Home.AccNumber;
            getBalance();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Balancelbl_Click(object sender, EventArgs e)
        {

        }

        private void AccNumlbl_Click(object sender, EventArgs e)
        {

        }
    }
}
