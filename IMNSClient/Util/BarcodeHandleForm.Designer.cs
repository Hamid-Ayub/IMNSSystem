namespace IMNSClient.Util
{
    partial class BarcodeHandleForm
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
            this.txtDummyBarcode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDummyBarcode
            // 
            this.txtDummyBarcode.Location = new System.Drawing.Point(42, 36);
            this.txtDummyBarcode.Name = "txtDummyBarcode";
            this.txtDummyBarcode.Size = new System.Drawing.Size(100, 22);
            this.txtDummyBarcode.TabIndex = 0;
            // 
            // BarcodeHandleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 386);
            this.Controls.Add(this.txtDummyBarcode);
            this.KeyPreview = true;
            this.Name = "BarcodeHandleForm";
            this.Text = "BarcodeHandleForm";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BarcodeHandleForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDummyBarcode;
    }
}