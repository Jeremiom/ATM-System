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
    public partial class account : Form
    {
        public account()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\ProjectModels;Initial Catalog=model;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void account_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int bal = 0;
            if (AccNametbl.Text == " " || AccNumTbl.Text == "" || FNameTbl.Text == "" || PhoneTbl.Text == "" || AddressTbl.Text == "" || occupationTbl.Text == "" || PinTbl.Text == "")
            {
                MessageBox.Show("Missing Information");
            }else
            {
                try
                {
                    Con.Open();
                    string query = "insert into AccountTbl values('"+AccNumTbl.Text+"','"+AccNametbl.Text+"','"+FNameTbl.Text+"','"+datetbl.Value.Date+"','"+PhoneTbl.Text+"','"+AddressTbl.Text+"','"+educationTbl.SelectedItem.ToString()+"','"+occupationTbl.Text+"',"+PinTbl.Text+","+bal+")";
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Created Successfully");
                    Con.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();


                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }


        private void label13_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
