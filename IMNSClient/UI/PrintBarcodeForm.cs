using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMNS.ServiceModel.Service.BL;
using IMNSClient.Util;
using Microsoft.Reporting.WinForms;

namespace IMNSClient.UI
{
    public partial class PrintBarcodeForm : Form
    {
        public PrintBarcodeForm()
        {
            InitializeComponent();

            //get report path.
            string reportPath = IMNSUtility.GetReportPath();
            string reportFileName = reportPath + "BarcodeReport.rpt";

            if (IMNSUtility.IsFileExisted(reportFileName))
            {

                this.crystalReportViewer1.ReportSource = reportFileName;
            }
            else
            {
                MessageBox.Show("BarcodeReport do not Exist. Please contact Admin");

            }
        }

        string _strBarcode = string.Empty;
        public PrintBarcodeForm(string barcode)
            : this()
        {
            _strBarcode = barcode;
        }

       // ReportViewer reportViewer1;
        private void PrintBarcodeForm_Load(object sender, EventArgs e)
        {
            try
            {
                Barcodes barcodeDetails = new Barcodes();
                DataTable dataTable = barcodeDetails._Barcodes;

                if (!string.IsNullOrEmpty(_strBarcode))
                {

                    BarcodeReport report = new BarcodeReport();
                    for (int i = 0; i < 50; i++)
                    {
                        DataRow drow = dataTable.NewRow();
                        //need to draw image then assign to this Barcode field.
                        //draw barcode with its size is W = 200, H = 100
                        Image img = null;
                        BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                        b.IncludeLabel = true;
                        if (_strBarcode.Length == 12) //UPCA barcode
                        {
                            img = b.Encode(BarcodeLib.TYPE.UPCA, _strBarcode.Trim(), Color.Black, Color.White, 150, 100);
                        }
                        else //UPCE
                        {
                            img = b.Encode(BarcodeLib.TYPE.UPCE, _strBarcode.Trim(), Color.Black, Color.White, 150, 100);
                        }

                        if (img != null)
                            drow["Barcode"] = IMNSUtility.ImageToByteArray(img);

                        dataTable.Rows.Add(drow);
                    }
                    report.Database.Tables["Barcodes"].SetDataSource((DataTable)dataTable);


                    crystalReportViewer1.ReportSource = report;
                    crystalReportViewer1.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
