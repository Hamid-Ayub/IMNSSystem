namespace IMNSClient.UI
{
    partial class ProductOrderDetailForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductOrderDetailForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gvProductExportDetail = new System.Windows.Forms.DataGridView();
            this.productExportDetailIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductUPK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.inventoryIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exportDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowVersionDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.productExportIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extensionDataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exportDetailDataSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblFinalPrice = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDiscountAmount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTaxAmount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblTotalQuantity = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkShowQuantityDlg = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnEnterProductUPK = new System.Windows.Forms.Button();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.btnRemoveTax = new System.Windows.Forms.Button();
            this.btnAddTax = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProductExportDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportDetailDataSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gvProductExportDetail);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.lblFinalPrice);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.lblDiscountAmount);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.lblTaxAmount);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.lblTotalPrice);
            this.splitContainer1.Panel2.Controls.Add(this.lblTotalQuantity);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.chkShowQuantityDlg);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel2.Controls.Add(this.btnEnterProductUPK);
            this.splitContainer1.Panel2.Controls.Add(this.btnDiscount);
            this.splitContainer1.Panel2.Controls.Add(this.btnRemoveTax);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddTax);
            this.splitContainer1.Panel2.Controls.Add(this.btnDone);
            this.splitContainer1.Size = new System.Drawing.Size(1436, 753);
            this.splitContainer1.SplitterDistance = 472;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // gvProductExportDetail
            // 
            this.gvProductExportDetail.AllowUserToAddRows = false;
            this.gvProductExportDetail.AllowUserToOrderColumns = true;
            this.gvProductExportDetail.AutoGenerateColumns = false;
            this.gvProductExportDetail.BackgroundColor = System.Drawing.Color.White;
            this.gvProductExportDetail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gvProductExportDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvProductExportDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvProductExportDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProductExportDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productExportDetailIDDataGridViewTextBoxColumn,
            this.ProductUPK,
            this.barcodeDataGridViewTextBoxColumn,
            this.ProductName,
            this.itemPriceDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.subTotalDataGridViewTextBoxColumn,
            this.delete,
            this.edit,
            this.inventoryIDDataGridViewTextBoxColumn,
            this.exportDateDataGridViewTextBoxColumn,
            this.rowVersionDataGridViewImageColumn,
            this.productExportIDDataGridViewTextBoxColumn,
            this.extensionDataDataGridViewTextBoxColumn});
            this.gvProductExportDetail.DataSource = this.exportDetailDataSource;
            this.gvProductExportDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvProductExportDetail.Location = new System.Drawing.Point(0, 0);
            this.gvProductExportDetail.Margin = new System.Windows.Forms.Padding(2);
            this.gvProductExportDetail.Name = "gvProductExportDetail";
            this.gvProductExportDetail.RowHeadersVisible = false;
            this.gvProductExportDetail.RowTemplate.Height = 24;
            this.gvProductExportDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvProductExportDetail.Size = new System.Drawing.Size(1436, 472);
            this.gvProductExportDetail.TabIndex = 1;
            this.gvProductExportDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvProductExportDetail_CellContentClick);
            this.gvProductExportDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gvProductExportDetail_DataBindingComplete);
            // 
            // productExportDetailIDDataGridViewTextBoxColumn
            // 
            this.productExportDetailIDDataGridViewTextBoxColumn.DataPropertyName = "ProductExportDetailID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.productExportDetailIDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.productExportDetailIDDataGridViewTextBoxColumn.HeaderText = "Order ID";
            this.productExportDetailIDDataGridViewTextBoxColumn.Name = "productExportDetailIDDataGridViewTextBoxColumn";
            this.productExportDetailIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // ProductUPK
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.ProductUPK.DefaultCellStyle = dataGridViewCellStyle3;
            this.ProductUPK.HeaderText = "Product UPK";
            this.ProductUPK.Name = "ProductUPK";
            this.ProductUPK.ReadOnly = true;
            this.ProductUPK.Width = 150;
            // 
            // barcodeDataGridViewTextBoxColumn
            // 
            this.barcodeDataGridViewTextBoxColumn.DataPropertyName = "Barcode";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barcodeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.barcodeDataGridViewTextBoxColumn.HeaderText = "Barcode";
            this.barcodeDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
            this.barcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barcodeDataGridViewTextBoxColumn.Width = 200;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductName.DefaultCellStyle = dataGridViewCellStyle5;
            this.ProductName.HeaderText = "Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // itemPriceDataGridViewTextBoxColumn
            // 
            this.itemPriceDataGridViewTextBoxColumn.DataPropertyName = "ItemPrice";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.itemPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.itemPriceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.itemPriceDataGridViewTextBoxColumn.Name = "itemPriceDataGridViewTextBoxColumn";
            this.itemPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemPriceDataGridViewTextBoxColumn.Width = 150;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subTotalDataGridViewTextBoxColumn
            // 
            this.subTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.subTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.subTotalDataGridViewTextBoxColumn.HeaderText = "Sub Total";
            this.subTotalDataGridViewTextBoxColumn.Name = "subTotalDataGridViewTextBoxColumn";
            this.subTotalDataGridViewTextBoxColumn.ReadOnly = true;
            this.subTotalDataGridViewTextBoxColumn.Width = 150;
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
            // inventoryIDDataGridViewTextBoxColumn
            // 
            this.inventoryIDDataGridViewTextBoxColumn.DataPropertyName = "InventoryID";
            this.inventoryIDDataGridViewTextBoxColumn.HeaderText = "InventoryID";
            this.inventoryIDDataGridViewTextBoxColumn.Name = "inventoryIDDataGridViewTextBoxColumn";
            this.inventoryIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // exportDateDataGridViewTextBoxColumn
            // 
            this.exportDateDataGridViewTextBoxColumn.DataPropertyName = "ExportDate";
            this.exportDateDataGridViewTextBoxColumn.HeaderText = "ExportDate";
            this.exportDateDataGridViewTextBoxColumn.Name = "exportDateDataGridViewTextBoxColumn";
            this.exportDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // rowVersionDataGridViewImageColumn
            // 
            this.rowVersionDataGridViewImageColumn.DataPropertyName = "RowVersion";
            this.rowVersionDataGridViewImageColumn.HeaderText = "RowVersion";
            this.rowVersionDataGridViewImageColumn.Name = "rowVersionDataGridViewImageColumn";
            this.rowVersionDataGridViewImageColumn.Visible = false;
            // 
            // productExportIDDataGridViewTextBoxColumn
            // 
            this.productExportIDDataGridViewTextBoxColumn.DataPropertyName = "ProductExportID";
            this.productExportIDDataGridViewTextBoxColumn.HeaderText = "ProductExportID";
            this.productExportIDDataGridViewTextBoxColumn.Name = "productExportIDDataGridViewTextBoxColumn";
            this.productExportIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // extensionDataDataGridViewTextBoxColumn
            // 
            this.extensionDataDataGridViewTextBoxColumn.DataPropertyName = "ExtensionData";
            this.extensionDataDataGridViewTextBoxColumn.HeaderText = "ExtensionData";
            this.extensionDataDataGridViewTextBoxColumn.Name = "extensionDataDataGridViewTextBoxColumn";
            this.extensionDataDataGridViewTextBoxColumn.Visible = false;
            // 
            // exportDetailDataSource
            // 
            this.exportDetailDataSource.DataSource = typeof(IMNS.ServiceModel.Service.BL.ProductExportDetail);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(1102, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "---------------------------------------";
            // 
            // lblFinalPrice
            // 
            this.lblFinalPrice.AutoSize = true;
            this.lblFinalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalPrice.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblFinalPrice.Location = new System.Drawing.Point(1231, 192);
            this.lblFinalPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFinalPrice.Name = "lblFinalPrice";
            this.lblFinalPrice.Size = new System.Drawing.Size(0, 29);
            this.lblFinalPrice.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(1108, 192);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 25);
            this.label6.TabIndex = 22;
            this.label6.Text = "Final Price:";
            // 
            // lblDiscountAmount
            // 
            this.lblDiscountAmount.AutoSize = true;
            this.lblDiscountAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountAmount.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblDiscountAmount.Location = new System.Drawing.Point(1232, 100);
            this.lblDiscountAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiscountAmount.Name = "lblDiscountAmount";
            this.lblDiscountAmount.Size = new System.Drawing.Size(0, 29);
            this.lblDiscountAmount.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(1050, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "Discount Amount:";
            // 
            // lblTaxAmount
            // 
            this.lblTaxAmount.AutoSize = true;
            this.lblTaxAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxAmount.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblTaxAmount.Location = new System.Drawing.Point(1231, 132);
            this.lblTaxAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTaxAmount.Name = "lblTaxAmount";
            this.lblTaxAmount.Size = new System.Drawing.Size(0, 29);
            this.lblTaxAmount.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(1096, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "Tax Amount:";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblTotalPrice.Location = new System.Drawing.Point(1232, 69);
            this.lblTotalPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(0, 29);
            this.lblTotalPrice.TabIndex = 16;
            // 
            // lblTotalQuantity
            // 
            this.lblTotalQuantity.AutoSize = true;
            this.lblTotalQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQuantity.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblTotalQuantity.Location = new System.Drawing.Point(1232, 32);
            this.lblTotalQuantity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalQuantity.Name = "lblTotalQuantity";
            this.lblTotalQuantity.Size = new System.Drawing.Size(0, 29);
            this.lblTotalQuantity.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(1108, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Total Price:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(1090, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Total Item(s):";
            // 
            // chkShowQuantityDlg
            // 
            this.chkShowQuantityDlg.AutoSize = true;
            this.chkShowQuantityDlg.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowQuantityDlg.ForeColor = System.Drawing.Color.Blue;
            this.chkShowQuantityDlg.Location = new System.Drawing.Point(21, 9);
            this.chkShowQuantityDlg.Margin = new System.Windows.Forms.Padding(2);
            this.chkShowQuantityDlg.Name = "chkShowQuantityDlg";
            this.chkShowQuantityDlg.Size = new System.Drawing.Size(532, 30);
            this.chkShowQuantityDlg.TabIndex = 13;
            this.chkShowQuantityDlg.Text = "Enter Product Quantity while scanning Barcode";
            this.chkShowQuantityDlg.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(616, 173);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 94);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(169, 63);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 94);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search Product";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnEnterProductUPK
            // 
            this.btnEnterProductUPK.BackColor = System.Drawing.Color.Transparent;
            this.btnEnterProductUPK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnterProductUPK.BackgroundImage")));
            this.btnEnterProductUPK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEnterProductUPK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnterProductUPK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnterProductUPK.ForeColor = System.Drawing.Color.White;
            this.btnEnterProductUPK.Location = new System.Drawing.Point(37, 64);
            this.btnEnterProductUPK.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnterProductUPK.Name = "btnEnterProductUPK";
            this.btnEnterProductUPK.Size = new System.Drawing.Size(112, 94);
            this.btnEnterProductUPK.TabIndex = 12;
            this.btnEnterProductUPK.Text = "Enter Product UPK";
            this.btnEnterProductUPK.UseVisualStyleBackColor = false;
            this.btnEnterProductUPK.Click += new System.EventHandler(this.btnEnterProductUPK_Click);
            // 
            // btnDiscount
            // 
            this.btnDiscount.BackColor = System.Drawing.Color.Transparent;
            this.btnDiscount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDiscount.BackgroundImage")));
            this.btnDiscount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscount.ForeColor = System.Drawing.Color.White;
            this.btnDiscount.Location = new System.Drawing.Point(297, 174);
            this.btnDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(112, 94);
            this.btnDiscount.TabIndex = 12;
            this.btnDiscount.Text = "Discount";
            this.btnDiscount.UseVisualStyleBackColor = false;
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // btnRemoveTax
            // 
            this.btnRemoveTax.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveTax.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveTax.BackgroundImage")));
            this.btnRemoveTax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveTax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveTax.ForeColor = System.Drawing.Color.White;
            this.btnRemoveTax.Location = new System.Drawing.Point(169, 173);
            this.btnRemoveTax.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveTax.Name = "btnRemoveTax";
            this.btnRemoveTax.Size = new System.Drawing.Size(112, 94);
            this.btnRemoveTax.TabIndex = 12;
            this.btnRemoveTax.Text = "Remove Tax";
            this.btnRemoveTax.UseVisualStyleBackColor = false;
            this.btnRemoveTax.Click += new System.EventHandler(this.btnRemoveTax_Click);
            // 
            // btnAddTax
            // 
            this.btnAddTax.BackColor = System.Drawing.Color.Transparent;
            this.btnAddTax.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddTax.BackgroundImage")));
            this.btnAddTax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddTax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTax.ForeColor = System.Drawing.Color.White;
            this.btnAddTax.Location = new System.Drawing.Point(37, 174);
            this.btnAddTax.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddTax.Name = "btnAddTax";
            this.btnAddTax.Size = new System.Drawing.Size(112, 94);
            this.btnAddTax.TabIndex = 12;
            this.btnAddTax.Text = "Add Tax";
            this.btnAddTax.UseVisualStyleBackColor = false;
            this.btnAddTax.Click += new System.EventHandler(this.btnAddTax_Click);
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.Transparent;
            this.btnDone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDone.BackgroundImage")));
            this.btnDone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.ForeColor = System.Drawing.Color.White;
            this.btnDone.Location = new System.Drawing.Point(485, 173);
            this.btnDone.Margin = new System.Windows.Forms.Padding(2);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(112, 94);
            this.btnDone.TabIndex = 12;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // ProductOrderDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1436, 753);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProductOrderDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Order Detail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvProductExportDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportDetailDataSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gvProductExportDetail;
        private System.Windows.Forms.BindingSource exportDetailDataSource;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.CheckBox chkShowQuantityDlg;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblTotalQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFinalPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDiscountAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTaxAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.Button btnRemoveTax;
        private System.Windows.Forms.Button btnAddTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn productExportDetailIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductUPK;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn delete;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventoryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exportDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn rowVersionDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productExportIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extensionDataDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnEnterProductUPK;
        private System.Windows.Forms.Button btnSearch;
    }
}