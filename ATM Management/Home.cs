using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Management
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        public static string AccNumber;
        private void Home_Load(object sender, EventArgs e)
        {
            AccNumTbl.Text = "Account Number: " + Login.AccNumber;
            AccNumber = Login.AccNumber;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Balance bal = new Balance();
            this.Hide();
            bal.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            changePin change = new changePin();
            this.Hide();
            change.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deposit depo = new deposit();
            depo.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            withdraw withdrw = new withdraw();
            withdrw.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fastcash withdrw = new fastcash();
            withdrw.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            statement state = new statement();
            state.Show();
            this.Hide();
        }
    }
}
