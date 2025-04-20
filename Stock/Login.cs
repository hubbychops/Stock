using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
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

        private void lilPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label1.Visible = false;
            var username = txtName.Text;
            //generation of a random 8 digit password through the use of GUID
            var newPassword = Guid.NewGuid().ToString().Substring(0, 8);
            if (string.IsNullOrEmpty(username))
            {
                label1.Text = "Please enter a user name";
                label1.Visible = true;
                return;
            }

            var con = Connection.GetConnection();
            var sda = new SqlDataAdapter(@"Select * From [Stock].[dbo].[Login] Where Username = '" + username + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count < 0)
            {
                label1.Text = "Invalid user name";
                return;
            }
            var email = dt.Rows[0]["email"].ToString();

            var cmd = new SqlCommand("Update [Stock].[dbo].[Login] Set Password = @Password where username = @username",
                con);
            cmd.Parameters.AddWithValue("@Password", newPassword);
            cmd.Parameters.AddWithValue("@username", username);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            var SMTPClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("dvanoverdijk5@gmail.com", "brwp nvbm froz iony")

            };
            var mailFrom = new MailAddress("dvanoverdijk5@gmail.com");
            var mailTo = new MailAddress(email);
            try
            {
                var mailMessage = new MailMessage(mailFrom, mailTo);
                mailMessage.Subject = "Password Reset";
                mailMessage.Body = $"Your new password is {newPassword}";
                SMTPClient.Send(mailMessage);
                label1.Text = "Password reset email send";
                label1.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                label1.Text = "An error occurred";
                label1.Visible = true;
            }
        }
    
    }
}