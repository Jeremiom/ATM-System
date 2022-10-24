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
    public partial class fastcash : Form
    {
        public fastcash()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\ProjectModels;Initial Catalog=model;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        string Acc = Login.AccNumber;
        int bal;
        private void getBalance()
        {
            Con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(" select Balance from AccountTbl where AccNum='" + Acc + "'", Con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            withdrwAmt.Text = "Balance: $" + dt.Rows[0][0].ToString();
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(bal<20)
            {
                MessageBox.Show("Insufficient Funds");
            }
            else
            {

                int newBalance = bal - 20;
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
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void fastcash_Load(object sender, EventArgs e)
        {
            getBalance();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bal < 50)
            {
                MessageBox.Show("Insufficient Funds");
            }
            else
            {

                int newBalance = bal - 50;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance =" + newBalance + " where Accnum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successful Withdrawl");
                    Con.Close();
                    addtransaction1();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (bal < 100)
            {
                MessageBox.Show("Insufficient Funds");
            }
            else
            {

                int newBalance = bal - 100;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance =" + newBalance + " where Accnum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successful Withdrawl");
                    Con.Close();
                    addtransaction2();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bal < 1000)
            {
                MessageBox.Show("Insufficient Funds");
            }
            else
            {

                int newBalance = bal - 1000;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance =" + newBalance + " where Accnum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successful Withdrawl");
                    Con.Close();
                    addtransaction3();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (bal < 2000)
            {
                MessageBox.Show("Insufficient Funds");
            }
            else
            {

                int newBalance = bal - 2000;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance =" + newBalance + " where Accnum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successful Withdrawl");
                    Con.Close();
                    addtransaction4();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bal < 5000)
            {
                MessageBox.Show("Insufficient Funds");
            }
            else
            {

                int newBalance = bal - 5000;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance =" +newBalance+ " where Accnum='" +Acc+ "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successful Withdrawl");
                    Con.Close();
                    addtransaction5();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        //int amt20=20,amt50=50,amt100=100,amt1000=1000,amt2000=2000,amt5000=5000;
        private void addtransaction()
        {
            string TrType = "fastcash";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" +Acc+ "','" +TrType+ "',"+20+ ",'" +DateTime.Today.Date.ToString()+ "')";
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
        private void addtransaction1()
        {
            string TrType = "fastcash";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" +Acc+ "','" +TrType+ "',"+50+",'" +DateTime.Today.Date.ToString()+ "')";
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
        private void addtransaction2()
        {
            string TrType = "fastcash";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" +Acc+ "','" +TrType+ "'," +100+ ",'" +DateTime.Today.Date.ToString()+ "')";
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
        private void addtransaction3()
        {
            string TrType = "fastcash";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" +Acc+ "','" +TrType+ "'," +1000+ ",'" +DateTime.Today.Date.ToString()+ "')";
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
        private void addtransaction4()
        {
            string TrType = "fastcash";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('"+Acc+"','" +TrType+ "'," +2000+ ",'" +DateTime.Today.Date.ToString()+ "')";
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
        private void addtransaction5()
        {
            string TrType = "fastcash";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('"+Acc+"','" +TrType+ "'," +5000+ ",'" +DateTime.Today.Date.ToString()+ "')";
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
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
