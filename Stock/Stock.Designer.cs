
namespace Stock
{
    partial class Stock
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
            this.components = new System.ComponentModel.Container();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.dgSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblToalProducts = new System.Windows.Forms.Label();
            this.lblTotalQuantities = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTPResult = new System.Windows.Forms.Label();
            this.lblTQResult = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(38, 84);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker1_KeyDown);
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(303, 84);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(150, 26);
            this.txtProductCode.TabIndex = 1;
            this.txtProductCode.TextChanged += new System.EventHandler(this.txtProductCode_TextChanged);
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            this.txtProductCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductCode_KeyPress);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(540, 84);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(256, 26);
            this.txtProductName.TabIndex = 2;
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductName_KeyDown);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(880, 84);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(150, 26);
            this.txtQuantity.TabIndex = 3;
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyDown);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(479, 146);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(131, 58);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgSno,
            this.dgProCode,
            this.dgProName,
            this.dgQuantity,
            this.dgDate,
            this.dgStatus});
            this.dgvStock.Location = new System.Drawing.Point(12, 247);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.RowHeadersWidth = 62;
            this.dgvStock.RowTemplate.Height = 28;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(1266, 348);
            this.dgvStock.TabIndex = 5;
            this.dgvStock.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStock_CellMouseDoubleClick);
            // 
            // dgSno
            // 
            this.dgSno.HeaderText = "SNo";
            this.dgSno.MinimumWidth = 8;
            this.dgSno.Name = "dgSno";
            this.dgSno.Width = 50;
            // 
            // dgProCode
            // 
            this.dgProCode.HeaderText = "Product Code";
            this.dgProCode.MinimumWidth = 8;
            this.dgProCode.Name = "dgProCode";
            this.dgProCode.Width = 150;
            // 
            // dgProName
            // 
            this.dgProName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgProName.HeaderText = "Product Name";
            this.dgProName.MinimumWidth = 8;
            this.dgProName.Name = "dgProName";
            // 
            // dgQuantity
            // 
            this.dgQuantity.DataPropertyName = "none";
            this.dgQuantity.HeaderText = "Quantity";
            this.dgQuantity.MinimumWidth = 8;
            this.dgQuantity.Name = "dgQuantity";
            this.dgQuantity.ToolTipText = "Quantity";
            this.dgQuantity.Width = 150;
            // 
            // dgDate
            // 
            this.dgDate.HeaderText = "Date";
            this.dgDate.MinimumWidth = 8;
            this.dgDate.Name = "dgDate";
            this.dgDate.Width = 150;
            // 
            // dgStatus
            // 
            this.dgStatus.HeaderText = "Status";
            this.dgStatus.MinimumWidth = 8;
            this.dgStatus.Name = "dgStatus";
            this.dgStatus.Width = 150;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(40, 41);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(44, 20);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Date";
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Location = new System.Drawing.Point(299, 41);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(106, 20);
            this.lblProductCode.TabIndex = 7;
            this.lblProductCode.Text = "Product Code";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(543, 41);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(110, 20);
            this.lblProductName.TabIndex = 8;
            this.lblProductName.Text = "Product Name";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(876, 41);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(68, 20);
            this.lblQuantity.TabIndex = 9;
            this.lblQuantity.Text = "Quantity";
            // 
            // lblToalProducts
            // 
            this.lblToalProducts.AutoSize = true;
            this.lblToalProducts.Location = new System.Drawing.Point(40, 629);
            this.lblToalProducts.Name = "lblToalProducts";
            this.lblToalProducts.Size = new System.Drawing.Size(127, 20);
            this.lblToalProducts.TabIndex = 10;
            this.lblToalProducts.Text = "Total Products:   ";
            // 
            // lblTotalQuantities
            // 
            this.lblTotalQuantities.AutoSize = true;
            this.lblTotalQuantities.Location = new System.Drawing.Point(525, 629);
            this.lblTotalQuantities.Name = "lblTotalQuantities";
            this.lblTotalQuantities.Size = new System.Drawing.Size(132, 20);
            this.lblTotalQuantities.TabIndex = 11;
            this.lblTotalQuantities.Text = "Total Quantities:  ";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(616, 146);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 58);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(744, 146);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(123, 58);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.AutoCompleteCustomSource.AddRange(new string[] {
            "Active",
            "Deactive"});
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Deactive"});
            this.cmbStatus.Location = new System.Drawing.Point(1102, 82);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(174, 28);
            this.cmbStatus.TabIndex = 14;
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbStatus_KeyDown);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(1097, 35);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 20);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "Status";
            // 
            // lblTPResult
            // 
            this.lblTPResult.AutoSize = true;
            this.lblTPResult.Location = new System.Drawing.Point(154, 629);
            this.lblTPResult.Name = "lblTPResult";
            this.lblTPResult.Size = new System.Drawing.Size(18, 20);
            this.lblTPResult.TabIndex = 16;
            this.lblTPResult.Text = "0";
            // 
            // lblTQResult
            // 
            this.lblTQResult.AutoSize = true;
            this.lblTQResult.Location = new System.Drawing.Point(648, 629);
            this.lblTQResult.Name = "lblTQResult";
            this.lblTQResult.Size = new System.Drawing.Size(18, 20);
            this.lblTQResult.TabIndex = 17;
            this.lblTQResult.Text = "0";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 667);
            this.Controls.Add(this.lblTQResult);
            this.Controls.Add(this.lblTPResult);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblTotalQuantities);
            this.Controls.Add(this.lblToalProducts);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "Stock";
            this.Text = "Stock";
            this.Load += new System.EventHandler(this.Stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblToalProducts;
        private System.Windows.Forms.Label lblTotalQuantities;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTPResult;
        private System.Windows.Forms.Label lblTQResult;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStatus;
    }
}