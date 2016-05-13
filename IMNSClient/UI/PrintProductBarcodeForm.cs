using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMNSClient.Util;

namespace IMNSClient.UI
{
    public partial class PrintProductBarcodeForm : BarcodeHandleForm
    {
        public PrintProductBarcodeForm()
        {
            InitializeComponent();

            this.DummyBarcode.Focus();

            this.BarcodeValueFired += ProductSettingsForm_BarcodeValueFired;
        }

        private void ProductSettingsForm_BarcodeValueFired(string barcodeValue)
        {
            try
            {
                txtBarcode.Text = barcodeValue;
                this.DummyBarcode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private UpcA _upc;
        //private void btnPrintPreview_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        CheckBarcodeValue();
        //        if (txtBarcode.Text.Length == 12)
        //        {
        //            bool bIsNormal = rdoNormalSize.Checked;

        //            //valid.
        //            string barcode = txtBarcode.Text.Replace("\r", "");
        //            _upc = new UpcA(barcode, bIsNormal);

        //            System.Drawing.Graphics g = this.picBarcode.CreateGraphics();

        //            g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.SystemColors.Control),
        //                new Rectangle(0, 0, picBarcode.Width, picBarcode.Height));

        //            _upc.Scale = (float)0.8; //1;
        //            PointF currentPt = _upc.DrawUpcaBarcode(g, new System.Drawing.Point(0, 0));

        //            //currentPt.X = currentPt.X * 96; //since 1 inch = 96 px

        //            //draw again in the same row.
        //            _upc.DrawUpcaBarcode(g, new PointF(currentPt.X, 0));


        //            g.Dispose();
        //        }
        //        else
        //        {
        //            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
        //            b.IncludeLabel = true;
        //            picBarcode.Image = b.Encode(BarcodeLib.TYPE.UPCE, this.txtBarcode.Text.Trim(), Color.Black, Color.White, 150, 100);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void CheckBarcodeValue()
        {
            string barcode = txtBarcode.Text;
            barcode = barcode.Replace("\r", "");
            if (string.IsNullOrEmpty(barcode))
            {
                MessageBox.Show("Please enter a Barcode number.");
                return;
            }

            if (barcode.Length != 12 && barcode.Length != 8)
            {
                MessageBox.Show("Please enter the 12 numbers or 8 numbers barcode value.");
                return;
            }

            foreach (char c in barcode)
            {
                if (Char.IsLetter(c))
                {
                    MessageBox.Show("Barcode is a 12 or 8 digit. Please enter again");
                    txtBarcode.Focus();
                    return;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void btnPrintToPage_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtNumOfBarcode.Text))
        //    {
        //        MessageBox.Show("Please enter a number of barcode you want to print.");
        //        return;
        //    }

        //    int numOfBarcode = 0;
        //    try
        //    {
        //        numOfBarcode = int.Parse(txtNumOfBarcode.Text);
        //        if (numOfBarcode <= 0)
        //        {
        //            MessageBox.Show("Number of Barcode should be bigger than 0.");
        //            return;
        //        }
        //        System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
        //        pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pd_PrintPage);
        //        pd.Print();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
           
        //}

        //private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs ev)
        //{
        //    try
        //    {
        //        //valid.
        //        int numOfBarcode = int.Parse(txtNumOfBarcode.Text);

        //        if (txtBarcode.Text.Length == 12) //UPC-A
        //        {

        //            bool bIsNormal = rdoNormalSize.Checked;
        //            string barcode = txtBarcode.Text.Replace("\r", "");
        //            _upc = new UpcA(barcode, bIsNormal);

        //            _upc.Scale = bIsNormal ? 1f : 0.8f; // 0.8; //1;
        //            PointF currentPoint = new PointF(0.2f, 0.2f); //start at this point
        //            PointF returnPoint;
        //            float wBarcode = _upc.Scale * _upc.Width;
        //            float hBarcode = _upc.Scale * _upc.Height;

        //            //set page unit to inch.
        //            ev.Graphics.PageUnit = System.Drawing.GraphicsUnit.Inch;
        //            for (int i = 0; i < numOfBarcode; i++)
        //            {
        //                returnPoint = _upc.DrawUpcaBarcode(ev.Graphics, currentPoint);
        //                currentPoint.X = returnPoint.X + 0.5f; //0.5 inch is the distance between 2 barcode.

        //                //check to verify whether or not there is enough space to draw to barcode on the same line or move to the next line.
        //                if (currentPoint.X + wBarcode > ev.Graphics.VisibleClipBounds.Width) //overload, need to move to next row.
        //                {
        //                    currentPoint.X = 0.2f; //reset it.
        //                    currentPoint.Y = currentPoint.Y + hBarcode + 0.5f;
        //                    // 0.5 inch is the distance between 2 barcode in verticle
        //                }

        //                //currentPoint.Y = returnPoint.Y + 1f;
        //            }

        //            // Add Code here to print other information.
        //            ev.Graphics.Dispose();
        //        }
        //        else //UPC-E
        //        {
        //            //call barcode lib to draw UPC-E
        //            //===== Encoding performed here =====
        //            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
        //            b.IncludeLabel = true;
        //            Image img = b.Encode(BarcodeLib.TYPE.UPCE, this.txtBarcode.Text.Trim(), Color.Black, Color.White, 150, 100);

        //            PointF currentPoint = new PointF(0.2f, 0.2f); //start at this point

        //            float wBarcode = 1.5f;
        //            float hBarcode = 1f;

        //            //set page unit to inch.
        //            ev.Graphics.PageUnit = System.Drawing.GraphicsUnit.Inch;
        //            for (int i = 0; i < numOfBarcode; i++)
        //            {
        //                ev.Graphics.DrawImage(img, currentPoint);
        //                currentPoint.X = currentPoint.X + 1.5f + 0.5f; //0.5 inch is the distance between 2 barcode.

        //                //check to verify whether or not there is enough space to draw to barcode on the same line or move to the next line.
        //                if (currentPoint.X + wBarcode > ev.Graphics.VisibleClipBounds.Width) //overload, need to move to next row.
        //                {
        //                    currentPoint.X = 0.2f; //reset it.
        //                    currentPoint.Y = currentPoint.Y + hBarcode + 0.5f;
        //                    // 0.5 inch is the distance between 2 barcode in verticle
        //                }

        //                //currentPoint.Y = returnPoint.Y + 1f;
        //            }

        //            //===================================
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void btnBarcodeReport_Click(object sender, EventArgs e)
        {
            try
            {
                CheckBarcodeValue();
                string barcode = txtBarcode.Text;
                barcode = barcode.Replace("\r", "");

                if (!string.IsNullOrEmpty(barcode))
                {
                    PrintBarcodeForm frm = new PrintBarcodeForm(barcode);
                    frm.ShowDialog(this);
                }

                this.DummyBarcode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrintBarcodeCatalog_Click(object sender, EventArgs e)
        {
            try
            {
                //display all barcode product for user to print out to aid for product import and check out.
                BarcodeCatalogReportForm frm = new BarcodeCatalogReportForm();
                frm.ShowDialog(this);

                this.DummyBarcode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
