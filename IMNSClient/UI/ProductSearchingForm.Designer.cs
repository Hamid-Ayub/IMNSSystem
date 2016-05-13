namespace IMNSClient.UI
{
    partial class ProductSearchingForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductSearchingForm));
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvProduct = new System.Windows.Forms.DataGridView();
            this.productIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.categorySource = new System.Windows.Forms.BindingSource(this.components);
            this.providerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.providerSource = new System.Windows.Forms.BindingSource(this.components);
            this.barcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowVersionDataGridViewImageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extensionDataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.select = new System.Windows.Forms.DataGridViewImageColumn();
            this.productDataSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categorySource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.providerSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtName.Location = new System.Drawing.Point(120, 20);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(800, 46);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Product Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.gvProduct);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(0, 119);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(1064, 566);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "All Products";
            // 
            // gvProduct
            // 
            this.gvProduct.AllowUserToAddRows = false;
            this.gvProduct.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            this.gvProduct.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvProduct.AutoGenerateColumns = false;
            this.gvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productIDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.categoryIDDataGridViewTextBoxColumn,
            this.providerIDDataGridViewTextBoxColumn,
            this.barcodeDataGridViewTextBoxColumn,
            this.barcodeTypeDataGridViewTextBoxColumn,
            this.salePriceDataGridViewTextBoxColumn,
            this.importPriceDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.rowVersionDataGridViewImageColumn,
            this.extensionDataDataGridViewTextBoxColumn,
            this.select});
            this.gvProduct.DataSource = this.productDataSource;
            this.gvProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvProduct.Location = new System.Drawing.Point(2, 18);
            this.gvProduct.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gvProduct.MultiSelect = false;
            this.gvProduct.Name = "gvProduct";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Cyan;
            this.gvProduct.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gvProduct.RowTemplate.Height = 24;
            this.gvProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvProduct.Size = new System.Drawing.Size(1060, 546);
            this.gvProduct.TabIndex = 0;
            this.gvProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvProduct_CellContentClick);
            // 
            // productIDDataGridViewTextBoxColumn
            // 
            this.productIDDataGridViewTextBoxColumn.DataPropertyName = "ProductID";
            this.productIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.productIDDataGridViewTextBoxColumn.Name = "productIDDataGridViewTextBoxColumn";
            this.productIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.productIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // categoryIDDataGridViewTextBoxColumn
            // 
            this.categoryIDDataGridViewTextBoxColumn.DataPropertyName = "CategoryID";
            this.categoryIDDataGridViewTextBoxColumn.DataSource = this.categorySource;
            this.categoryIDDataGridViewTextBoxColumn.DisplayMember = "Name";
            this.categoryIDDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.categoryIDDataGridViewTextBoxColumn.HeaderText = "Category Name";
            this.categoryIDDataGridViewTextBoxColumn.Name = "categoryIDDataGridViewTextBoxColumn";
            this.categoryIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.categoryIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.categoryIDDataGridViewTextBoxColumn.ValueMember = "CategoryID";
            this.categoryIDDataGridViewTextBoxColumn.Width = 200;
            // 
            // categorySource
            // 
            this.categorySource.DataSource = typeof(IMNS.ServiceModel.Service.BL.Category);
            // 
            // providerIDDataGridViewTextBoxColumn
            // 
            this.providerIDDataGridViewTextBoxColumn.DataPropertyName = "ProviderID";
            this.providerIDDataGridViewTextBoxColumn.DataSource = this.providerSource;
            this.providerIDDataGridViewTextBoxColumn.DisplayMember = "Name";
            this.providerIDDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.providerIDDataGridViewTextBoxColumn.HeaderText = "Provider Name";
            this.providerIDDataGridViewTextBoxColumn.Name = "providerIDDataGridViewTextBoxColumn";
            this.providerIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.providerIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.providerIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.providerIDDataGridViewTextBoxColumn.ValueMember = "ProviderID";
            this.providerIDDataGridViewTextBoxColumn.Width = 200;
            // 
            // providerSource
            // 
            this.providerSource.DataSource = typeof(IMNS.ServiceModel.Service.BL.Provider);
            // 
            // barcodeDataGridViewTextBoxColumn
            // 
            this.barcodeDataGridViewTextBoxColumn.DataPropertyName = "Barcode";
            this.barcodeDataGridViewTextBoxColumn.HeaderText = "Barcode";
            this.barcodeDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
            this.barcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barcodeDataGridViewTextBoxColumn.Width = 150;
            // 
            // barcodeTypeDataGridViewTextBoxColumn
            // 
            this.barcodeTypeDataGridViewTextBoxColumn.DataPropertyName = "BarcodeType";
            this.barcodeTypeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.barcodeTypeDataGridViewTextBoxColumn.Name = "barcodeTypeDataGridViewTextBoxColumn";
            this.barcodeTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barcodeTypeDataGridViewTextBoxColumn.Width = 60;
            // 
            // salePriceDataGridViewTextBoxColumn
            // 
            this.salePriceDataGridViewTextBoxColumn.DataPropertyName = "SalePrice";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.salePriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.salePriceDataGridViewTextBoxColumn.HeaderText = "Sale Price";
            this.salePriceDataGridViewTextBoxColumn.Name = "salePriceDataGridViewTextBoxColumn";
            this.salePriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.salePriceDataGridViewTextBoxColumn.Width = 150;
            // 
            // importPriceDataGridViewTextBoxColumn
            // 
            this.importPriceDataGridViewTextBoxColumn.DataPropertyName = "ImportPrice";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.importPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.importPriceDataGridViewTextBoxColumn.HeaderText = "Import Price";
            this.importPriceDataGridViewTextBoxColumn.Name = "importPriceDataGridViewTextBoxColumn";
            this.importPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.importPriceDataGridViewTextBoxColumn.Visible = false;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Visible = false;
            // 
            // rowVersionDataGridViewImageColumn
            // 
            this.rowVersionDataGridViewImageColumn.DataPropertyName = "RowVersion";
            this.rowVersionDataGridViewImageColumn.HeaderText = "RowVersion";
            this.rowVersionDataGridViewImageColumn.Name = "rowVersionDataGridViewImageColumn";
            this.rowVersionDataGridViewImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.rowVersionDataGridViewImageColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.rowVersionDataGridViewImageColumn.Visible = false;
            // 
            // extensionDataDataGridViewTextBoxColumn
            // 
            this.extensionDataDataGridViewTextBoxColumn.DataPropertyName = "ExtensionData";
            this.extensionDataDataGridViewTextBoxColumn.HeaderText = "ExtensionData";
            this.extensionDataDataGridViewTextBoxColumn.Name = "extensionDataDataGridViewTextBoxColumn";
            this.extensionDataDataGridViewTextBoxColumn.Visible = false;
            // 
            // select
            // 
            this.select.HeaderText = "";
            this.select.Image = ((System.Drawing.Image)(resources.GetObject("select.Image")));
            this.select.Name = "select";
            this.select.ReadOnly = true;
            this.select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.select.Width = 70;
            // 
            // productDataSource
            // 
            this.productDataSource.DataSource = typeof(IMNS.ServiceModel.Service.BL.Product);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(936, 10);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 93);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search Product";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ProductSearchingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 685);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ProductSearchingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Products";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categorySource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.providerSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource categorySource;
        private System.Windows.Forms.BindingSource providerSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gvProduct;
        private System.Windows.Forms.BindingSource productDataSource;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn categoryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn providerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowVersionDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extensionDataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn select;

    }
}