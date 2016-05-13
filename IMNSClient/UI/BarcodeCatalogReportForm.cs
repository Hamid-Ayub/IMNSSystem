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

namespace IMNSClient.UI
{
    public partial class BarcodeCatalogReportForm : Form
    {
        public BarcodeCatalogReportForm()
        {
            InitializeComponent();

            //get report path.
            string reportPath = IMNSUtility.GetReportPath();
            string reportFileName = reportPath + "BarcodeCatalogReport.rpt";

            if (IMNSUtility.IsFileExisted(reportFileName))
            {
                this.crystalReportViewer1.ReportSource = reportFileName;
            }
            else
            {
                MessageBox.Show("BarcodeCatalogReport do not Exist. Please contact Admin");

            }
        }

        private void BarcodeCatalogReportForm_Load(object sender, EventArgs e)
        {
            //fill data into datatable 
            try
            {
                //load all inventory here
                BarcodeCatalog dsBarcode = new BarcodeCatalog();
                DataTable dataTable = dsBarcode._BarcodeCatalog;

                Product[] lstProduct = Program.NailSupplyManager.GetAllProducts();

                if (lstProduct != null)
                {
                    
                    BarcodeCatalogReport report = new BarcodeCatalogReport();

                    foreach (Product p in lstProduct)
                    {
                        DataRow drow = dataTable.NewRow();
                        drow["Name"] = "Name: " + p.Name;

                        drow["ProductUPK"] = "UPK: " + p.ProductID.ToString("00000");
                        drow["Price"] = "Price: " + p.SalePrice.ToString("C2");

                        //need to draw image then assign to this Barcode field.
                        //draw barcode with its size is W = 200, H = 100
                        Image img = null;
                        BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                        b.IncludeLabel = true;
                        if (p.BarcodeType == "UPCA") //
                        {

                            img = b.Encode(BarcodeLib.TYPE.UPCA, p.Barcode.Trim(), Color.Black, Color.White, 150, 100);
                        }
                        else //UPCE
                        {

                            img = b.Encode(BarcodeLib.TYPE.UPCE, p.Barcode.Trim(), Color.Black, Color.White, 150, 100);
                        }

                        if (img != null)
                            drow["Barcode"] = IMNSUtility.ImageToByteArray(img);


                        dataTable.Rows.Add(drow);
                    }

                    report.Database.Tables["BarcodeCatalog"].SetDataSource((DataTable)dataTable);


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
