
namespace Stock
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lilPassword = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(112, 40);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(196, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "admin";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(112, 79);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '#';
            this.txtPassword.Size = new System.Drawing.Size(196, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "admin@123";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(41, 44);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(66, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "User Name :";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(44, 79);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(59, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password :";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(112, 135);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(73, 33);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(235, 135);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(71, 33);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lilPassword
            // 
            this.lilPassword.AutoSize = true;
            this.lilPassword.Location = new System.Drawing.Point(215, 107);
            this.lilPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lilPassword.Name = "lilPassword";
            this.lilPassword.Size = new System.Drawing.Size(92, 13);
            this.lilPassword.TabIndex = 6;
            this.lilPassword.TabStop = true;
            this.lilPassword.Text = "Forgot Password?";
            this.lilPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lilPassword_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 7;
            // 
            // Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 214);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lilPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtName);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                                      Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel lilPassword;
        private System.Windows.Forms.Label label1;
    }
}