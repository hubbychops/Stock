﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }
        
        private void Products_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (Validation())
            {
                SqlConnection con = Connection.GetConnection();
                //Insert Logic
                con.Open();
                bool status = false;
                if (cmbStatus.SelectedIndex == 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }

                var sqlQuery = "";

                if (IfProductsExists(con, txtProductCode.Text))
                {
                    sqlQuery = @"UPDATE [Products] SET [ProductName] = '" + txtProductName.Text + "' ,[ProductStatus] = '" + status + "' " +
                                "WHERE [ProductCode] = '" + txtProductCode.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO [Stock].[dbo].[Products] ([ProductCode] ,[ProductName] ,[ProductStatus]) VALUES
                            ('" + txtProductCode.Text + "', '" + txtProductName.Text + "' , '" + status + "')";
                }
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                //Reading Data
                LoadData();

                ResetRecords(); 
            }


        }

        private bool IfProductsExists(SqlConnection con, string productCode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select 1 From [Products] WHERE [ProductCode] = '" + productCode + "'" , con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public void LoadData()
        {
            SqlConnection con = Connection.GetConnection();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From [Stock].[dbo].[Products]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvProducts.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dgvProducts.Rows.Add();
                dgvProducts.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                dgvProducts.Rows[n].Cells[1].Value = item["ProductName"].ToString();
                if ((bool)item["ProductStatus"])
                {
                    dgvProducts.Rows[n].Cells[2].Value = "Active";
                }
                else
                {
                    dgvProducts.Rows[n].Cells[2].Value = "Deactive";
                }
            }
        }

        private void dgvProducts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnAdd.Text = "Update";
            txtProductCode.Text = dgvProducts.SelectedRows[0].Cells[0].Value.ToString();
            txtProductName.Text = dgvProducts.SelectedRows[0].Cells[1].Value.ToString();
            if(dgvProducts.SelectedRows[0].Cells[2].Value.ToString() == "Active")
            {
                cmbStatus.SelectedIndex = 0;
            }
            else
            {
                cmbStatus.SelectedIndex = 1;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Validation())
                {
                    SqlConnection con = Connection.GetConnection(); ;
                    var sqlQuery = "";

                    if (IfProductsExists(con, txtProductCode.Text))
                    {
                        con.Open();
                        sqlQuery = @"DELETE FROM [Products] WHERE [ProductCode] = '" + txtProductCode.Text + "'";
                        SqlCommand cmd = new SqlCommand(sqlQuery, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("No record found with that product code");
                    }
                    LoadData();
                    ResetRecords();
                }
            }
        }

        private void ResetRecords()
        {
            txtProductCode.Clear();
            txtProductName.Clear();
            cmbStatus.SelectedIndex = -1;
            btnAdd.Text = "Add";
            txtProductCode.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetRecords();
        }

        private bool Validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(txtProductCode.Text))
            {
                //in design added errorProvider1
                errorProvider1.Clear();
                errorProvider1.SetError(txtProductCode, "Product Code Required");
            }
            else if (string.IsNullOrEmpty(txtProductName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtProductName, "Product Name Required");
            }
            else if (cmbStatus.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cmbStatus, "Select Status");
            }
            else
            {
                result = true;
            }           
            /*if elseif elseif else replaced
             if(!string.IsNullOrEmpty(txtProductCode.Text) && !string.IsNullOrEmpty(txtProductName.Text) && cmbStatus.Selectedindex > -1)
            {
                result = true
            }
                return result;
             */
            return result;
        }
    }
}
