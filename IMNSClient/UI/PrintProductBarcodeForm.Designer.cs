namespace IMNSClient.UI
{
    partial class PrintProductBarcodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintProductBarcodeForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrintToPage = new System.Windows.Forms.Button();
            this.btnPrintBarcodeCatalog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Barcode";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(210, 42);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(219, 22);
            this.txtBarcode.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Location = new System.Drawing.Point(370, 171);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(118, 112);
            this.btnClose.TabIndex = 6;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrintToPage
            // 
            this.btnPrintToPage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrintToPage.BackgroundImage")));
            this.btnPrintToPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrintToPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintToPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintToPage.ForeColor = System.Drawing.Color.White;
            this.btnPrintToPage.Location = new System.Drawing.Point(71, 170);
            this.btnPrintToPage.Name = "btnPrintToPage";
            this.btnPrintToPage.Size = new System.Drawing.Size(118, 112);
            this.btnPrintToPage.TabIndex = 8;
            this.btnPrintToPage.Text = "Print Barcode ";
            this.btnPrintToPage.UseVisualStyleBackColor = true;
            this.btnPrintToPage.Click += new System.EventHandler(this.btnBarcodeReport_Click);
            // 
            // btnPrintBarcodeCatalog
            // 
            this.btnPrintBarcodeCatalog.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrintBarcodeCatalog.BackgroundImage")));
            this.btnPrintBarcodeCatalog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrintBarcodeCatalog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintBarcodeCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBarcodeCatalog.ForeColor = System.Drawing.Color.White;
            this.btnPrintBarcodeCatalog.Location = new System.Drawing.Point(220, 170);
            this.btnPrintBarcodeCatalog.Name = "btnPrintBarcodeCatalog";
            this.btnPrintBarcodeCatalog.Size = new System.Drawing.Size(118, 112);
            this.btnPrintBarcodeCatalog.TabIndex = 8;
            this.btnPrintBarcodeCatalog.Text = "Print Barcode Catalog";
            this.btnPrintBarcodeCatalog.UseVisualStyleBackColor = true;
            this.btnPrintBarcodeCatalog.Click += new System.EventHandler(this.btnPrintBarcodeCatalog_Click);
            // 
            // PrintProductBarcodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(552, 381);
            this.Controls.Add(this.btnPrintBarcodeCatalog);
            this.Controls.Add(this.btnPrintToPage);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PrintProductBarcodeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Product Barcode ";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtBarcode, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnPrintToPage, 0);
            this.Controls.SetChildIndex(this.btnPrintBarcodeCatalog, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrintToPage;
        private System.Windows.Forms.Button btnPrintBarcodeCatalog;
    }
}