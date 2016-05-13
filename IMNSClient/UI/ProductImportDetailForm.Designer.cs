namespace IMNSClient.UI
{
    partial class ProductImportDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductImportDetailForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gvProductImportDetail = new System.Windows.Forms.DataGridView();
            this.importDetailSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblTotalImportPrice = new System.Windows.Forms.Label();
            this.lblTotalQuantity = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.productImportDetailIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemImportPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inQuantiryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalImportPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.itemImportStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoryIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowVersionDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.productImportIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extensionDataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProductImportDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importDetailSource)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.gvProductImportDetail);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.lblTotalImportPrice);
            this.splitContainer1.Panel2.Controls.Add(this.lblTotalQuantity);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btnDone);
            this.splitContainer1.Size = new System.Drawing.Size(1163, 819);
            this.splitContainer1.SplitterDistance = 524;
            this.splitContainer1.TabIndex = 0;
            // 
            // gvProductImportDetail
            // 
            this.gvProductImportDetail.AllowUserToAddRows = false;
            this.gvProductImportDetail.AllowUserToOrderColumns = true;
            this.gvProductImportDetail.AutoGenerateColumns = false;
            this.gvProductImportDetail.BackgroundColor = System.Drawing.Color.White;
            this.gvProductImportDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvProductImportDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvProductImportDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProductImportDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productImportDetailIDDataGridViewTextBoxColumn,
            this.barcodeDataGridViewTextBoxColumn,
            this.ProductName,
            this.itemImportPriceDataGridViewTextBoxColumn,
            this.inQuantiryDataGridViewTextBoxColumn,
            this.totalImportPriceDataGridViewTextBoxColumn,
            this.delete,
            this.edit,
            this.itemImportStatusDataGridViewTextBoxColumn,
            this.importDateDataGridViewTextBoxColumn,
            this.outQuantityDataGridViewTextBoxColumn,
            this.inventoryIDDataGridViewTextBoxColumn,
            this.rowVersionDataGridViewImageColumn,
            this.productImportIDDataGridViewTextBoxColumn,
            this.extensionDataDataGridViewTextBoxColumn});
            this.gvProductImportDetail.DataSource = this.importDetailSource;
            this.gvProductImportDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvProductImportDetail.Location = new System.Drawing.Point(0, 0);
            this.gvProductImportDetail.Name = "gvProductImportDetail";
            this.gvProductImportDetail.RowHeadersVisible = false;
            this.gvProductImportDetail.RowTemplate.Height = 24;
            this.gvProductImportDetail.Size = new System.Drawing.Size(1163, 524);
            this.gvProductImportDetail.TabIndex = 0;
            this.gvProductImportDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvProductImportDetail_CellContentClick);
            this.gvProductImportDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gvProductImportDetail_DataBindingComplete);
            // 
            // importDetailSource
            // 
            this.importDetailSource.DataSource = typeof(IMNS.ServiceModel.Service.BL.ProductImportDetail);
            // 
            // lblTotalImportPrice
            // 
            this.lblTotalImportPrice.AutoSize = true;
            this.lblTotalImportPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalImportPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTotalImportPrice.Location = new System.Drawing.Point(905, 79);
            this.lblTotalImportPrice.Name = "lblTotalImportPrice";
            this.lblTotalImportPrice.Size = new System.Drawing.Size(0, 36);
            this.lblTotalImportPrice.TabIndex = 2;
            // 
            // lblTotalQuantity
            // 
            this.lblTotalQuantity.AutoSize = true;
            this.lblTotalQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTotalQuantity.Location = new System.Drawing.Point(905, 13);
            this.lblTotalQuantity.Name = "lblTotalQuantity";
            this.lblTotalQuantity.Size = new System.Drawing.Size(0, 36);
            this.lblTotalQuantity.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(634, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Import Price:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(680, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Quantity:";
            // 
            // btnDone
            // 
            this.btnDone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDone.BackgroundImage")));
            this.btnDone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDone.Location = new System.Drawing.Point(34, 31);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(78, 77);
            this.btnDone.TabIndex = 0;
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // productImportDetailIDDataGridViewTextBoxColumn
            // 
            this.productImportDetailIDDataGridViewTextBoxColumn.DataPropertyName = "ProductImportDetailID";
            this.productImportDetailIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.productImportDetailIDDataGridViewTextBoxColumn.Name = "productImportDetailIDDataGridViewTextBoxColumn";
            this.productImportDetailIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.productImportDetailIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // barcodeDataGridViewTextBoxColumn
            // 
            this.barcodeDataGridViewTextBoxColumn.DataPropertyName = "Barcode";
            this.barcodeDataGridViewTextBoxColumn.HeaderText = "Barcode";
            this.barcodeDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
            this.barcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barcodeDataGridViewTextBoxColumn.Width = 150;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductName.HeaderText = "Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // itemImportPriceDataGridViewTextBoxColumn
            // 
            this.itemImportPriceDataGridViewTextBoxColumn.DataPropertyName = "ItemImportPrice";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.itemImportPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.itemImportPriceDataGridViewTextBoxColumn.HeaderText = "Import Price";
            this.itemImportPriceDataGridViewTextBoxColumn.Name = "itemImportPriceDataGridViewTextBoxColumn";
            this.itemImportPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemImportPriceDataGridViewTextBoxColumn.Width = 130;
            // 
            // inQuantiryDataGridViewTextBoxColumn
            // 
            this.inQuantiryDataGridViewTextBoxColumn.DataPropertyName = "InQuantiry";
            this.inQuantiryDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.inQuantiryDataGridViewTextBoxColumn.Name = "inQuantiryDataGridViewTextBoxColumn";
            this.inQuantiryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalImportPriceDataGridViewTextBoxColumn
            // 
            this.totalImportPriceDataGridViewTextBoxColumn.DataPropertyName = "TotalImportPrice";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.totalImportPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.totalImportPriceDataGridViewTextBoxColumn.HeaderText = "Total Price";
            this.totalImportPriceDataGridViewTextBoxColumn.Name = "totalImportPriceDataGridViewTextBoxColumn";
            this.totalImportPriceDataGridViewTextBoxColumn.ReadOnly = true;
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
            // itemImportStatusDataGridViewTextBoxColumn
            // 
            this.itemImportStatusDataGridViewTextBoxColumn.DataPropertyName = "ItemImportStatus";
            this.itemImportStatusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.itemImportStatusDataGridViewTextBoxColumn.Name = "itemImportStatusDataGridViewTextBoxColumn";
            this.itemImportStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemImportStatusDataGridViewTextBoxColumn.Visible = false;
            // 
            // importDateDataGridViewTextBoxColumn
            // 
            this.importDateDataGridViewTextBoxColumn.DataPropertyName = "ImportDate";
            dataGridViewCellStyle4.Format = "g";
            dataGridViewCellStyle4.NullValue = null;
            this.importDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.importDateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.importDateDataGridViewTextBoxColumn.Name = "importDateDataGridViewTextBoxColumn";
            this.importDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.importDateDataGridViewTextBoxColumn.Visible = false;
            this.importDateDataGridViewTextBoxColumn.Width = 130;
            // 
            // outQuantityDataGridViewTextBoxColumn
            // 
            this.outQuantityDataGridViewTextBoxColumn.DataPropertyName = "OutQuantity";
            this.outQuantityDataGridViewTextBoxColumn.HeaderText = "Out Quantity";
            this.outQuantityDataGridViewTextBoxColumn.Name = "outQuantityDataGridViewTextBoxColumn";
            this.outQuantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.outQuantityDataGridViewTextBoxColumn.Visible = false;
            // 
            // inventoryIDDataGridViewTextBoxColumn
            // 
            this.inventoryIDDataGridViewTextBoxColumn.DataPropertyName = "InventoryID";
            this.inventoryIDDataGridViewTextBoxColumn.HeaderText = "InventoryID";
            this.inventoryIDDataGridViewTextBoxColumn.Name = "inventoryIDDataGridViewTextBoxColumn";
            this.inventoryIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.inventoryIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // rowVersionDataGridViewImageColumn
            // 
            this.rowVersionDataGridViewImageColumn.DataPropertyName = "RowVersion";
            this.rowVersionDataGridViewImageColumn.HeaderText = "RowVersion";
            this.rowVersionDataGridViewImageColumn.Name = "rowVersionDataGridViewImageColumn";
            this.rowVersionDataGridViewImageColumn.ReadOnly = true;
            this.rowVersionDataGridViewImageColumn.Visible = false;
            // 
            // productImportIDDataGridViewTextBoxColumn
            // 
            this.productImportIDDataGridViewTextBoxColumn.DataPropertyName = "ProductImportID";
            this.productImportIDDataGridViewTextBoxColumn.HeaderText = "ProductImportID";
            this.productImportIDDataGridViewTextBoxColumn.Name = "productImportIDDataGridViewTextBoxColumn";
            this.productImportIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.productImportIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // extensionDataDataGridViewTextBoxColumn
            // 
            this.extensionDataDataGridViewTextBoxColumn.DataPropertyName = "ExtensionData";
            this.extensionDataDataGridViewTextBoxColumn.HeaderText = "ExtensionData";
            this.extensionDataDataGridViewTextBoxColumn.Name = "extensionDataDataGridViewTextBoxColumn";
            this.extensionDataDataGridViewTextBoxColumn.Visible = false;
            // 
            // ProductImportDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 819);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProductImportDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Import Detail";
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvProductImportDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importDetailSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gvProductImportDetail;
        private System.Windows.Forms.BindingSource importDetailSource;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Label lblTotalImportPrice;
        private System.Windows.Forms.Label lblTotalQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productImportDetailIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemImportPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inQuantiryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalImportPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn delete;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemImportStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn outQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventoryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn rowVersionDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productImportIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extensionDataDataGridViewTextBoxColumn;
    }
}