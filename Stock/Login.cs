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

namespace Stock
{
    public partial class Login : Form
    {
        public Login()
        {
            /*Before going any further must make sure that not only
             is windows forms app chosen but 
            Windows Forms App (.net Framework)
            Also need to ask IT to download and install
            CrystalreportViewer from: https://www.tektutorialshub.com/crystal-reports/download-crystal-reports-for-visual-studio-2019/
           */
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPassword.Clear();
            txtName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //TO-DO: check login user name and password
            SqlConnection con = Connection.GetConnection();
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT *
                FROM[Stock].[dbo].[Login] Where UserName='"+ txtName.Text +"' and Password = '"+ txtPassword.Text +"' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                this.Hide();
                StockMain main = new StockMain();
                main.Show();
            }
            else 
            {
                MessageBox.Show("Invalid Username or Password..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnClear_Click(sender, e);
            }
        }
    }
}