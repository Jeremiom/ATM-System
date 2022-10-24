using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATM_Management
{
    public partial class changePin : Form
    {
        public changePin()
        {
            InitializeComponent();
        }
        string Acc = Login.AccNumber;
        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\ProjectModels;Initial Catalog=model;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void label5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (pinlbl.Text == "" || conflbl.Text == "")
            {
                MessageBox.Show("Enter The Amount To Deposit");
            }
            else if(conflbl.Text != pinlbl.Text)
            {
                MessageBox.Show("Pin1 and Pin2 are different");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set PIN ="+pinlbl.Text+" where Accnum='"+Acc+"'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successful Deposit");
                    Con.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void conflbl_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
