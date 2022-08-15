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
        //block indent or dedent is highlicht code and tab or shift-tab
        public Stock()
        {
            InitializeComponent();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            this.ActiveControl = dateTimePicker1;
            cmbStatus.SelectedIndex = 0;
            LoadData();
            Search();
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
            if (e.KeyCode == Keys.Enter)
            {
                if(dgview.Rows.Count > 0)
                {
                    txtProductCode.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
                    txtProductName.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
                    this.dgview.Visible = false;
                    txtQuantity.Focus();
                }
                else
                {
                    dgview.Visible = false;
                }
                //if (txtProductCode.Text.Length > 0)
                //{                
                //    txtProductCode.Text = dgvSmall.SelectedRows[0].Cells[0].Value.ToString();
                //    txtProductName.Text = dgvSmall.SelectedRows[0].Cells[1].Value.ToString();
                //    txtQuantity.Focus();
                //}
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

        bool change = true;

        private void proCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (change)
            {
                change = false;
                txtProductCode.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
                txtProductName.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
                this.dgview.Visible = false;
                txtQuantity.Focus();
                change = true;
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
            /*In the if statement above the code uses a single AND operator "&" instead of 2 "&&"
             The effect is that all 3 conditions are evaluated
             whereas with && if the first condition is false all following conditions are ignored*/
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
            //below because we are only returning values in both cases no need to create code bodies
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

                string sqlQuery;//changed this from "var sqlQuery" to avoid the need to assign a value

                if (IfProductsExists(con, txtProductCode.Text))
                {
                    //updated here from Product.cs to use the Stock Table and not Products
                    //but because I did not originally did this in "IfProductsExists" did never do an update
                    sqlQuery = @"UPDATE [Stock] SET [ProductName] = '" + txtProductName.Text + "',[Quantity] = '" + txtQuantity.Text + "',[ProductStatus] = '" + status + "'  WHERE [ProductCode] = '" + txtProductCode.Text + "'";
                    //Above only updating 3 fields
                    //you should never update the productcode and the transaction date
                    //Can do less fields than columns in table but must be in correct order/named and expected valuetype
                }
                else
                {
                    sqlQuery = @"INSERT INTO Stock (ProductCode ,ProductName,TransDate ,Quantity,ProductStatus) VALUES
                            ('" + txtProductCode.Text + "', '" + txtProductName.Text + "' , '"+ dateTimePicker1.Value.ToString("MM/dd/yyyy") +"','" + txtQuantity.Text + "' ,'" + status + "')";
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
                /*int temp = dgvStock.Rows.Count;
                temp = temp - 1;
                lblTPResult.Text = temp.ToString();
                
                 The above could be a solution for the extra row in the DGV by
                not unclicking "allow editing"*/
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

        private void dgvStock_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //vitally important that fullRowSelect mode is selected in 
            //properties of the dgv otherwiaw get out of range error
            btnAdd.Text = "Update";
            txtProductCode.Text = dgvStock.SelectedRows[0].Cells["dgProCode"].Value.ToString();
            txtProductName.Text = dgvStock.SelectedRows[0].Cells["dgProName"].Value.ToString();
            txtQuantity.Text = dgvStock.SelectedRows[0].Cells["dgQuantity"].Value.ToString();
            dateTimePicker1.Text = DateTime.Parse(dgvStock.SelectedRows[0].Cells["dgDate"].Value.ToString()).ToString("dd/MM/yyyy hh:mm:ss");
            if (dgvStock.SelectedRows[0].Cells["dgStatus"].Value.ToString() == "Active")
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
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Validation())
                {
                    SqlConnection con = Connection.GetConnection();
                    var sqlQuery = "";
                    if (IfProductsExists(con, txtProductCode.Text))
                    {
                        con.Open();
                        sqlQuery = @"DELETE FROM [Stock] WHERE [ProductCode] = '" + txtProductCode.Text + "'";
                        SqlCommand cmd = new SqlCommand(sqlQuery, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("The Record has been successfully deleted");
                    }
                    else
                    {
                        MessageBox.Show("Record does not exist...!");
                    }
                    LoadData();
                    ResetRecords();
                }
            }
        }       

        private DataGridView dgview;
        private DataGridViewTextBoxColumn dgviewcol1;
        private DataGridViewTextBoxColumn dgviewcol2;

        void Search()
        {
            dgview = new DataGridView();
            dgviewcol1 = new DataGridViewTextBoxColumn();
            dgviewcol2 = new DataGridViewTextBoxColumn();
            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.dgviewcol1, this.dgviewcol2 });
            this.dgview.Name = "dgview";
            dgview.Visible = false;
            this.dgviewcol1.Visible = false;
            this.dgviewcol2.Visible = false;
            this.dgview.AllowUserToAddRows = false;
            this.dgview.RowHeadersVisible = false;
            this.dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            //this.dgview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgview_KeyDown);

            this.Controls.Add(dgview);
            this.dgview.ReadOnly = true;
            dgview.BringToFront();
        }

        void Search(int LX, int LY, int DW, int DH, string ColName, String ColSize)
        {
            this.dgview.Location = new System.Drawing.Point(LX, LY);
            this.dgview.Size = new System.Drawing.Size(DW, DH);

            string[] CLSize = ColSize.Split(',');
            for (int i = 0; i < CLSize.Length; i++)
            {
                if (int.Parse(CLSize[i]) != 0)
                {
                    dgview.Columns[i].Width = int.Parse(CLSize[i]);
                }
                else
                {
                    dgview.Columns[i].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                }
            }

            string[] CLName = ColName.Split(',');

            for (int i = 0; i < CLName.Length; i++)
            {
                this.dgview.Columns[i].HeaderText = CLName[i];
                this.dgview.Columns[i].Visible = true;
            }
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            if (txtProductCode.Text.Length > 0)
            {
                this.dgview.Visible = true;
                dgview.BringToFront();
                Search(150, 105, 430, 200, "Pro Code, Pro Name", "100,0");
                this.dgview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.proCode_MouseDoubleClick);
                SqlConnection con = Connection.GetConnection();
                //con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select  Top(10) ProductCode, ProductName From [Products] Where [ProductCode] Like '" + txtProductCode.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //dgvSmall.DataSource = dt;
                dgview.Rows.Clear();
                foreach(DataRow row in dt.Rows)
                {
                    int n = dgview.Rows.Add();
                    dgview.Rows[n].Cells[0].Value = row["ProductCode"].ToString();
                    dgview.Rows[n].Cells[1].Value = row["ProductName"].ToString();
                }
            }
            else
            {
                dgview.Visible = false;
            }
        }
    }
}
