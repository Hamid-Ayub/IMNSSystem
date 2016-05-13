namespace IMNSClient.UI
{
    partial class ProductImportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductImportForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gvProductImport = new System.Windows.Forms.DataGridView();
            this.ImportBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.productImportIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalInQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalOutQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowVersionDataGridViewImageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extensionDataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productImportSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProductImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productImportSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStart.BackgroundImage")));
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.Location = new System.Drawing.Point(632, 23);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(71, 75);
            this.btnStart.TabIndex = 8;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnDone
            // 
            this.btnDone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDone.BackgroundImage")));
            this.btnDone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDone.Location = new System.Drawing.Point(720, 23);
            this.btnDone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(71, 75);
            this.btnDone.TabIndex = 8;
            this.btnDone.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnDone);
            this.splitContainer1.Panel1.Controls.Add(this.btnStart);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1034, 637);
            this.splitContainer1.SplitterDistance = 113;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gvProductImport);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(1034, 521);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All Import Products";
            // 
            // gvProductImport
            // 
            this.gvProductImport.AllowUserToAddRows = false;
            this.gvProductImport.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            this.gvProductImport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvProductImport.AutoGenerateColumns = false;
            this.gvProductImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProductImport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productImportIDDataGridViewTextBoxColumn,
            this.importDateDataGridViewTextBoxColumn,
            this.subTotalDataGridViewTextBoxColumn,
            this.totalInQuantityDataGridViewTextBoxColumn,
            this.totalOutQuantityDataGridViewTextBoxColumn,
            this.importStatusDataGridViewTextBoxColumn,
            this.ImportBy,
            this.delete,
            this.edit,
            this.rowVersionDataGridViewImageColumn,
            this.extensionDataDataGridViewTextBoxColumn});
            this.gvProductImport.DataSource = this.productImportSource;
            this.gvProductImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvProductImport.Location = new System.Drawing.Point(2, 15);
            this.gvProductImport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gvProductImport.MultiSelect = false;
            this.gvProductImport.Name = "gvProductImport";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvProductImport.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvProductImport.RowHeadersVisible = false;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Cyan;
            this.gvProductImport.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gvProductImport.RowTemplate.Height = 24;
            this.gvProductImport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvProductImport.Size = new System.Drawing.Size(1030, 504);
            this.gvProductImport.TabIndex = 1;
            this.gvProductImport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvProductImport_CellContentClick);
            this.gvProductImport.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvProductImport_CellFormatting);
            // 
            // ImportBy
            // 
            this.ImportBy.DataPropertyName = "ImportBy";
            this.ImportBy.HeaderText = "Import By";
            this.ImportBy.Name = "ImportBy";
            // 
            // delete
            // 
            this.delete.HeaderText = "";
            this.delete.Image = ((System.Drawing.Image)(resources.GetObject("delete.Image")));
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.Width = 70;
            // 
            // edit
            // 
            this.edit.HeaderText = "";
            this.edit.Image = ((System.Drawing.Image)(resources.GetObject("edit.Image")));
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Width = 70;
            // 
            // productImportIDDataGridViewTextBoxColumn
            // 
            this.productImportIDDataGridViewTextBoxColumn.DataPropertyName = "ProductImportID";
            this.productImportIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.productImportIDDataGridViewTextBoxColumn.Name = "productImportIDDataGridViewTextBoxColumn";
            this.productImportIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.productImportIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // importDateDataGridViewTextBoxColumn
            // 
            this.importDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.importDateDataGridViewTextBoxColumn.DataPropertyName = "ImportDate";
            dataGridViewCellStyle2.Format = "g";
            dataGridViewCellStyle2.NullValue = null;
            this.importDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.importDateDataGridViewTextBoxColumn.HeaderText = "Import Date";
            this.importDateDataGridViewTextBoxColumn.Name = "importDateDataGridViewTextBoxColumn";
            this.importDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subTotalDataGridViewTextBoxColumn
            // 
            this.subTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.subTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.subTotalDataGridViewTextBoxColumn.HeaderText = "Sub Total";
            this.subTotalDataGridViewTextBoxColumn.Name = "subTotalDataGridViewTextBoxColumn";
            this.subTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalInQuantityDataGridViewTextBoxColumn
            // 
            this.totalInQuantityDataGridViewTextBoxColumn.DataPropertyName = "TotalInQuantity";
            this.totalInQuantityDataGridViewTextBoxColumn.HeaderText = "Total In Quantity";
            this.totalInQuantityDataGridViewTextBoxColumn.Name = "totalInQuantityDataGridViewTextBoxColumn";
            this.totalInQuantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalInQuantityDataGridViewTextBoxColumn.Width = 150;
            // 
            // totalOutQuantityDataGridViewTextBoxColumn
            // 
            this.totalOutQuantityDataGridViewTextBoxColumn.DataPropertyName = "TotalOutQuantity";
            this.totalOutQuantityDataGridViewTextBoxColumn.HeaderText = "Total Out Quantity";
            this.totalOutQuantityDataGridViewTextBoxColumn.Name = "totalOutQuantityDataGridViewTextBoxColumn";
            this.totalOutQuantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalOutQuantityDataGridViewTextBoxColumn.Width = 150;
            // 
            // importStatusDataGridViewTextBoxColumn
            // 
            this.importStatusDataGridViewTextBoxColumn.DataPropertyName = "ImportStatus";
            this.importStatusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.importStatusDataGridViewTextBoxColumn.Name = "importStatusDataGridViewTextBoxColumn";
            this.importStatusDataGridViewTextBoxColumn.ReadOnly = true;
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
            // productImportSource
            // 
            this.productImportSource.DataSource = typeof(IMNS.ServiceModel.Service.BL.ProductImport);
            // 
            // ProductImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 637);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ProductImportForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Import";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvProductImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productImportSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gvProductImport;
        private System.Windows.Forms.BindingSource productImportSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn productImportIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalInQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalOutQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportBy;
        private System.Windows.Forms.DataGridViewImageColumn delete;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowVersionDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extensionDataDataGridViewTextBoxColumn;
    }
}