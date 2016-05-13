namespace IMNSClient.UI
{
    partial class ReportFunctionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportFunctionForm));
            this.btnSaleReport = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSaleReport
            // 
            this.btnSaleReport.BackColor = System.Drawing.Color.Transparent;
            this.btnSaleReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaleReport.BackgroundImage")));
            this.btnSaleReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaleReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaleReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaleReport.ForeColor = System.Drawing.Color.White;
            this.btnSaleReport.Location = new System.Drawing.Point(190, 127);
            this.btnSaleReport.Name = "btnSaleReport";
            this.btnSaleReport.Size = new System.Drawing.Size(122, 115);
            this.btnSaleReport.TabIndex = 13;
            this.btnSaleReport.Text = "Sale Report";
            this.btnSaleReport.UseVisualStyleBackColor = false;
            this.btnSaleReport.Click += new System.EventHandler(this.btnSaleReport_Click);
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.Transparent;
            this.btnDone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDone.BackgroundImage")));
            this.btnDone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.ForeColor = System.Drawing.Color.White;
            this.btnDone.Location = new System.Drawing.Point(377, 127);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(122, 115);
            this.btnDone.TabIndex = 14;
            this.btnDone.Text = "Close";
            this.btnDone.UseVisualStyleBackColor = false;
            // 
            // ReportFunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(705, 389);
            this.Controls.Add(this.btnSaleReport);
            this.Controls.Add(this.btnDone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ReportFunctionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Functions";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaleReport;
        private System.Windows.Forms.Button btnDone;
    }
}