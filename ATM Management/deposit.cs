using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Management
{
    public partial class deposit : Form
    {
        public deposit()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\ProjectModels;Initial Catalog=model;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        string Acc = Login.AccNumber;
        private void  addtransaction()
        {
            string TrType = "deposit";
            try{
                Con.Open();
                string query = "insert into TransactionTbl values('"+Acc+"','"+TrType+"',"+depositAmt.Text+",'"+DateTime.Today.Date.ToString()+"')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Account Created Successfully");
                Con.Close();
                Login log = new Login();
                log.Show();
                this.Hide();
            }catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(depositAmt.Text == "" || Convert.ToInt32(depositAmt.Text) <=0 )
            {
                MessageBox.Show("Enter The Amount To Deposit");
            }
            else
            {

                newBalance = oldBalance + Convert.ToInt32(depositAmt.Text);
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance ="+newBalance+" where Accnum='"+Acc+"'";                    
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successful Deposit");
                    Con.Close();
                    addtransaction();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();

        }
        int oldBalance, newBalance;
        private void getBalance()
        {
            Con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(" select Balance from AccountTbl where AccNum='"+Acc+"'",Con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            oldBalance = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }

        private void deposit_Load(object sender, EventArgs e)
        {
            getBalance();
        }
    }
}
