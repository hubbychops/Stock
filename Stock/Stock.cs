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
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            this.ActiveControl = dateTimePicker1;
            cmbStatus.SelectedIndex = 0;
            LoadData();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtProductCode.Focus();
            }
        }

        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(txtProductCode.Text.Length > 0)
                {
                    txtProductName.Focus();
                }
                else
                {
                    txtProductCode.Focus();
                }
            }
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtProductName.Text.Length > 0)
                {
                    txtQuantity.Focus();
                }
                else
                {
                    txtProductName.Focus();
                }
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtQuantity.Text.Length > 0)
                {
                    cmbStatus.Focus();
                }
                else
                {
                    txtQuantity.Focus();
                }
            }
        }

        private void cmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(cmbStatus.SelectedIndex != -1)
                {
                    btnAdd.Focus();
                }
                else
                {
                    cmbStatus.Focus();
                }
            }
        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
            
        }
        private void ResetRecords()
        {
            dateTimePicker1.Value = DateTime.Now;
            txtProductCode.Clear();
            txtProductName.Clear();
            txtQuantity.Clear();
            cmbStatus.SelectedIndex = -1;
            btnAdd.Text = "Add";
            dateTimePicker1.Focus();

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
            else if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtQuantity, "A Quantity is Required");
            }
            else if (cmbStatus.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cmbStatus, "Select Status");
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            /*This has been copied from Products.cs with code added for the quantity box             */
            return result;
        }
        private bool IfProductsExists(SqlConnection con, string productCode)
        {
            /*This entire function comes from Products.cs as well 
             * so what about making separate class?
             I made initially the error of not replacing the table [Products] with [Stock] (see below in add btn click)*/

            SqlDataAdapter sda = new SqlDataAdapter("Select 1 From [Stock] WHERE [ProductCode] = '" + productCode + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {//taken  and amended for the sqfrom Products.cs and amended the SQL
            if (Validation())
            {
                SqlConnection con = Connection.GetConnection();
                
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
                    //updated here from Product.cs to use the Stock Table and not Products
                    //but because I did not originally did this in "IfProductsExists" did never do an update
                    sqlQuery = @"UPDATE [Stock] SET [ProductName] = '" + txtProductName.Text + "',[Quantity] = '" + txtQuantity.Text + "',[ProductStatus] = '" + status + "' " +
                                "WHERE [ProductCode] = '" + txtProductCode.Text + "'";
                    //Above only updating 3 fields
                    //you should never update the productcode and the transaction date
                    //Can do less fields than columns in table but must be in correct order/named and expected valuetype
                }
                else
                {
                    sqlQuery = @"INSERT INTO Stock ([ProductCode] ,[ProductName],[TransDate] ,[Quantity],[ProductStatus]) VALUES
                            ('" + txtProductCode.Text + "', '" + txtProductName.Text + "' , '"+ dateTimePicker1.Value.ToString("dd/MM/yyyy hh:mm:ss") +"','" + txtQuantity.Text + "' ,'" + status + "')";
                }
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                //Reading Data
                LoadData(); //removed temporarily
                MessageBox.Show("Record Saved Successfully");
                ResetRecords();
            }


        }
        public void LoadData()
        {
            SqlConnection con = Connection.GetConnection();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From [Stock].[dbo].[Stock]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvStock.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dgvStock.Rows.Add();
                dgvStock.Rows[n].Cells["dgSno"].Value = n + 1;
                dgvStock.Rows[n].Cells["dgProCode"].Value = item["ProductCode"].ToString();
                dgvStock.Rows[n].Cells["dgProName"].Value = item["ProductName"].ToString();
                dgvStock.Rows[n].Cells["dgQuantity"].Value = float.Parse(item["Quantity"].ToString());
                dgvStock.Rows[n].Cells["dgDate"].Value = Convert.ToDateTime(item["TransDate"].ToString()).ToString("dd/MM/yyyy hh:mm:ss");
                //could also do
                //dgvStock.Rows[n].Cells["dgDate"].Value = Convert.ToDateTime(item["TransDate"].ToString());.ToString("dd/MM/yyyy");
                //but I have put the format of the custom setting to get and display the time as well
                if ((bool)item["ProductStatus"])
                {                 
                    dgvStock.Rows[n].Cells["dgStatus"].Value = "Active";
                }
                else
                {
                    dgvStock.Rows[n].Cells["dgStatus"].Value = "Deactive";
                }
            }

            if(dgvStock.Rows.Count > 0)
            {
                lblTPResult.Text = dgvStock.Rows.Count.ToString();
                //It really is important that the data grid view has been adapted by
                //when creating untick "Enable Adding" otherwise will be faced with
                //nullreferencedexception error because trying to count no data in empty row
                float totQty = 0;
                for(int i = 0; i < dgvStock.Rows.Count; ++i)
                {
                    totQty +=  float.Parse(dgvStock.Rows[i].Cells["dgQuantity"].Value.ToString());
                    lblTQResult.Text = totQty.ToString();
                }
            }
            else
            {
                lblTPResult.Text = "0";
                lblTQResult.Text = "0";
            }
        }
    }
}
