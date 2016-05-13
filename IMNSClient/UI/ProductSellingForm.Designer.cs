namespace IMNSClient.UI
{
    partial class ProductSellingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductSellingForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gvProductExport = new System.Windows.Forms.DataGridView();
            this.productExportIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exportBarcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exportDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subDiscountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finalSalePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalImportPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.rowVersionDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.customerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extensionDataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productExportDataSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProductExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productExportDataSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnReturn);
            this.splitContainer1.Panel1.Controls.Add(this.btnCheckOut);
            this.splitContainer1.Panel1.Controls.Add(this.btnDone);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1457, 805);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.Transparent;
            this.btnReturn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReturn.BackgroundImage")));
            this.btnReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Location = new System.Drawing.Point(57, 43);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(122, 115);
            this.btnReturn.TabIndex = 14;
            this.btnReturn.Text = "Return Order";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.Transparent;
            this.btnCheckOut.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCheckOut.BackgroundImage")));
            this.btnCheckOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.Location = new System.Drawing.Point(687, 43);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(122, 115);
            this.btnCheckOut.TabIndex = 15;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnDone
            // 
            this.btnDone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDone.BackgroundImage")));
            this.btnDone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDone.Location = new System.Drawing.Point(1297, 38);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(122, 115);
            this.btnDone.TabIndex = 12;
            this.btnDone.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gvProductExport);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1457, 602);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All Recent Orders";
            // 
            // gvProductExport
            // 
            this.gvProductExport.AllowUserToAddRows = false;
            this.gvProductExport.AllowUserToOrderColumns = true;
            this.gvProductExport.AutoGenerateColumns = false;
            this.gvProductExport.BackgroundColor = System.Drawing.Color.White;
            this.gvProductExport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvProductExport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvProductExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProductExport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productExportIDDataGridViewTextBoxColumn,
            this.exportBarcodeDataGridViewTextBoxColumn,
            this.exportDateDataGridViewTextBoxColumn,
            this.totalQuantityDataGridViewTextBoxColumn,
            this.subTotalDataGridViewTextBoxColumn,
            this.subDiscountDataGridViewTextBoxColumn,
            this.subTaxDataGridViewTextBoxColumn,
            this.finalSalePriceDataGridViewTextBoxColumn,
            this.totalImportPriceDataGridViewTextBoxColumn,
            this.statusDataGridViewCheckBoxColumn,
            this.delete,
            this.edit,
            this.rowVersionDataGridViewImageColumn,
            this.customerIDDataGridViewTextBoxColumn,
            this.extensionDataDataGridViewTextBoxColumn});
            this.gvProductExport.DataSource = this.productExportDataSource;
            this.gvProductExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvProductExport.Location = new System.Drawing.Point(3, 18);
            this.gvProductExport.Name = "gvProductExport";
            this.gvProductExport.RowHeadersVisible = false;
            this.gvProductExport.RowTemplate.Height = 24;
            this.gvProductExport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvProductExport.Size = new System.Drawing.Size(1451, 581);
            this.gvProductExport.TabIndex = 2;
            this.gvProductExport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvProductExport_CellContentClick);
            this.gvProductExport.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvProductExport_CellFormatting);
            // 
            // productExportIDDataGridViewTextBoxColumn
            // 
            this.productExportIDDataGridViewTextBoxColumn.DataPropertyName = "ProductExportID";
            this.productExportIDDataGridViewTextBoxColumn.HeaderText = "Order ID";
            this.productExportIDDataGridViewTextBoxColumn.Name = "productExportIDDataGridViewTextBoxColumn";
            this.productExportIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.productExportIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // exportBarcodeDataGridViewTextBoxColumn
            // 
            this.exportBarcodeDataGridViewTextBoxColumn.DataPropertyName = "ExportBarcode";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBarcodeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.exportBarcodeDataGridViewTextBoxColumn.HeaderText = "Order Number";
            this.exportBarcodeDataGridViewTextBoxColumn.Name = "exportBarcodeDataGridViewTextBoxColumn";
            this.exportBarcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.exportBarcodeDataGridViewTextBoxColumn.Width = 200;
            // 
            // exportDateDataGridViewTextBoxColumn
            // 
            this.exportDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.exportDateDataGridViewTextBoxColumn.DataPropertyName = "ExportDate";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.Format = "g";
            dataGridViewCellStyle3.NullValue = null;
            this.exportDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.exportDateDataGridViewTextBoxColumn.HeaderText = "Order Date";
            this.exportDateDataGridViewTextBoxColumn.Name = "exportDateDataGridViewTextBoxColumn";
            this.exportDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalQuantityDataGridViewTextBoxColumn
            // 
            this.totalQuantityDataGridViewTextBoxColumn.DataPropertyName = "TotalQuantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalQuantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.totalQuantityDataGridViewTextBoxColumn.HeaderText = "Total Item";
            this.totalQuantityDataGridViewTextBoxColumn.Name = "totalQuantityDataGridViewTextBoxColumn";
            this.totalQuantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subTotalDataGridViewTextBoxColumn
            // 
            this.subTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.subTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.subTotalDataGridViewTextBoxColumn.HeaderText = "Sub Total";
            this.subTotalDataGridViewTextBoxColumn.Name = "subTotalDataGridViewTextBoxColumn";
            this.subTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subDiscountDataGridViewTextBoxColumn
            // 
            this.subDiscountDataGridViewTextBoxColumn.DataPropertyName = "SubDiscount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.subDiscountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.subDiscountDataGridViewTextBoxColumn.HeaderText = "Sub Discount";
            this.subDiscountDataGridViewTextBoxColumn.Name = "subDiscountDataGridViewTextBoxColumn";
            this.subDiscountDataGridViewTextBoxColumn.ReadOnly = true;
            this.subDiscountDataGridViewTextBoxColumn.Width = 120;
            // 
            // subTaxDataGridViewTextBoxColumn
            // 
            this.subTaxDataGridViewTextBoxColumn.DataPropertyName = "SubTax";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.subTaxDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.subTaxDataGridViewTextBoxColumn.HeaderText = "Sub Tax";
            this.subTaxDataGridViewTextBoxColumn.Name = "subTaxDataGridViewTextBoxColumn";
            this.subTaxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // finalSalePriceDataGridViewTextBoxColumn
            // 
            this.finalSalePriceDataGridViewTextBoxColumn.DataPropertyName = "FinalSalePrice";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.finalSalePriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.finalSalePriceDataGridViewTextBoxColumn.HeaderText = "Final Sale Price";
            this.finalSalePriceDataGridViewTextBoxColumn.Name = "finalSalePriceDataGridViewTextBoxColumn";
            this.finalSalePriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.finalSalePriceDataGridViewTextBoxColumn.Width = 200;
            // 
            // totalImportPriceDataGridViewTextBoxColumn
            // 
            this.totalImportPriceDataGridViewTextBoxColumn.DataPropertyName = "TotalImportPrice";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = null;
            this.totalImportPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.totalImportPriceDataGridViewTextBoxColumn.HeaderText = "Total Import Price";
            this.totalImportPriceDataGridViewTextBoxColumn.Name = "totalImportPriceDataGridViewTextBoxColumn";
            this.totalImportPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalImportPriceDataGridViewTextBoxColumn.Width = 200;
            // 
            // statusDataGridViewCheckBoxColumn
            // 
            this.statusDataGridViewCheckBoxColumn.DataPropertyName = "Status";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusDataGridViewCheckBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.statusDataGridViewCheckBoxColumn.HeaderText = "Status";
            this.statusDataGridViewCheckBoxColumn.Name = "statusDataGridViewCheckBoxColumn";
            this.statusDataGridViewCheckBoxColumn.ReadOnly = true;
            this.statusDataGridViewCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.statusDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.statusDataGridViewCheckBoxColumn.Width = 120;
            // 
            // delete
            // 
            this.delete.HeaderText = "";
            this.delete.Image = ((System.Drawing.Image)(resources.GetObject("delete.Image")));
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Width = 60;
            // 
            // edit
            // 
            this.edit.HeaderText = "";
            this.edit.Image = ((System.Drawing.Image)(resources.GetObject("edit.Image")));
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Width = 60;
            // 
            // rowVersionDataGridViewImageColumn
            // 
            this.rowVersionDataGridViewImageColumn.DataPropertyName = "RowVersion";
            this.rowVersionDataGridViewImageColumn.HeaderText = "RowVersion";
            this.rowVersionDataGridViewImageColumn.Name = "rowVersionDataGridViewImageColumn";
            this.rowVersionDataGridViewImageColumn.Visible = false;
            // 
            // customerIDDataGridViewTextBoxColumn
            // 
            this.customerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID";
            this.customerIDDataGridViewTextBoxColumn.HeaderText = "CustomerID";
            this.customerIDDataGridViewTextBoxColumn.Name = "customerIDDataGridViewTextBoxColumn";
            this.customerIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.customerIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // extensionDataDataGridViewTextBoxColumn
            // 
            this.extensionDataDataGridViewTextBoxColumn.DataPropertyName = "ExtensionData";
            this.extensionDataDataGridViewTextBoxColumn.HeaderText = "ExtensionData";
            this.extensionDataDataGridViewTextBoxColumn.Name = "extensionDataDataGridViewTextBoxColumn";
            this.extensionDataDataGridViewTextBoxColumn.Visible = false;
            // 
            // productExportDataSource
            // 
            this.productExportDataSource.DataSource = typeof(IMNS.ServiceModel.Service.BL.ProductExport);
            // 
            // ProductSellingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1457, 805);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProductSellingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Selling";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvProductExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productExportDataSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource productExportDataSource;
        private System.Windows.Forms.DataGridView gvProductExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn productExportIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exportBarcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exportDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subDiscountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn finalSalePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalImportPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn delete;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewImageColumn rowVersionDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extensionDataDataGridViewTextBoxColumn;


    }
}