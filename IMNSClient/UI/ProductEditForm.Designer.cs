namespace IMNSClient.UI
{
    partial class ProductEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductEditForm));
            this.btnGenerateBarcode = new System.Windows.Forms.Button();
            this.txtDes = new System.Windows.Forms.TextBox();
            this.txtImportPrice = new System.Windows.Forms.TextBox();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.cboProvider = new System.Windows.Forms.ComboBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerateBarcode
            // 
            this.btnGenerateBarcode.Location = new System.Drawing.Point(371, 151);
            this.btnGenerateBarcode.Name = "btnGenerateBarcode";
            this.btnGenerateBarcode.Size = new System.Drawing.Size(130, 45);
            this.btnGenerateBarcode.TabIndex = 4;
            this.btnGenerateBarcode.Text = "Generate Barcode";
            this.btnGenerateBarcode.UseVisualStyleBackColor = true;
            this.btnGenerateBarcode.Click += new System.EventHandler(this.btnGenerateBarcode_Click);
            // 
            // txtDes
            // 
            this.txtDes.Location = new System.Drawing.Point(723, 110);
            this.txtDes.Multiline = true;
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(308, 69);
            this.txtDes.TabIndex = 7;
            this.txtDes.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // txtImportPrice
            // 
            this.txtImportPrice.Location = new System.Drawing.Point(723, 62);
            this.txtImportPrice.Name = "txtImportPrice";
            this.txtImportPrice.Size = new System.Drawing.Size(202, 22);
            this.txtImportPrice.TabIndex = 6;
            this.txtImportPrice.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Location = new System.Drawing.Point(723, 19);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Size = new System.Drawing.Size(202, 22);
            this.txtSalePrice.TabIndex = 5;
            this.txtSalePrice.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(148, 162);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(202, 22);
            this.txtBarcode.TabIndex = 3;
            this.txtBarcode.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // cboProvider
            // 
            this.cboProvider.DisplayMember = "Name";
            this.cboProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvider.FormattingEnabled = true;
            this.cboProvider.Location = new System.Drawing.Point(148, 112);
            this.cboProvider.Name = "cboProvider";
            this.cboProvider.Size = new System.Drawing.Size(338, 24);
            this.cboProvider.TabIndex = 2;
            this.cboProvider.ValueMember = "ProviderID";
            this.cboProvider.SelectedValueChanged += new System.EventHandler(this.OnSelectedValueChanged);
            // 
            // cboCategory
            // 
            this.cboCategory.DisplayMember = "Name";
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(148, 65);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(338, 24);
            this.cboCategory.TabIndex = 1;
            this.cboCategory.ValueMember = "CategoryID";
            this.cboCategory.SelectedValueChanged += new System.EventHandler(this.OnSelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Barcode #";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Provider Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Category Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(614, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(610, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Import Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(621, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Sale Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(148, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(397, 22);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(543, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 79);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdate.Location = new System.Drawing.Point(437, 265);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(79, 79);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ProductEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 376);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnGenerateBarcode);
            this.Controls.Add(this.txtDes);
            this.Controls.Add(this.txtImportPrice);
            this.Controls.Add(this.txtSalePrice);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.cboProvider);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProductEditForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Product";
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cboCategory, 0);
            this.Controls.SetChildIndex(this.cboProvider, 0);
            this.Controls.SetChildIndex(this.txtBarcode, 0);
            this.Controls.SetChildIndex(this.txtSalePrice, 0);
            this.Controls.SetChildIndex(this.txtImportPrice, 0);
            this.Controls.SetChildIndex(this.txtDes, 0);
            this.Controls.SetChildIndex(this.btnGenerateBarcode, 0);
            this.Controls.SetChildIndex(this.btnUpdate, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateBarcode;
        private System.Windows.Forms.TextBox txtDes;
        private System.Windows.Forms.TextBox txtImportPrice;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.ComboBox cboProvider;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
    }
}