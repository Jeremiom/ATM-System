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
    public partial class withdraw : Form
    {
        public withdraw()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\ProjectModels;Initial Catalog=model;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void label4_Click(object sender, EventArgs e)
        {

        }
        string Acc = Login.AccNumber;
        int bal;
        private void getBalance()
        {
            Con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(" select Balance from AccountTbl where AccNum='"+Acc+"'", Con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            balancelbl.Text = "Balance: $" + dt.Rows[0][0].ToString();
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }
        private void withdraw_Load(object sender, EventArgs e)
        {
            getBalance();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int newBalance;
        private void button1_Click(object sender, EventArgs e)
        {
            if(withdrawAmt.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else if(Convert.ToInt32(withdrawAmt.Text) <= 0 )
            {
                MessageBox.Show("Enter a Valid Amount");
            }
            else if (Convert.ToInt32(withdrawAmt.Text) > bal)
            {
                MessageBox.Show("Balance Cannnot be negative");
            }
            else
            {
                try
                {
                    newBalance = bal - Convert.ToInt32(withdrawAmt.Text);
                    try
                    {
                        Con.Open();
                        string query = "update AccountTbl set Balance =" + newBalance + " where Accnum='" + Acc + "'";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successful Withdrawl");
                        Con.Close();
                        addtransaction();
                        Home home = new Home();
                        home.Show();
                        this.Hide();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void addtransaction()
        {
            string TrType = "withdraw";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Acc + "','" + TrType + "'," + withdrawAmt.Text + ",'" + DateTime.Today.Date.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Account Created Successfully");
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
        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }
    }
}
