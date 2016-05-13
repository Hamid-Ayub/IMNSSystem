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
    public partial class InventoryReportForm : Form
    {
        public InventoryReportForm()
        {
            InitializeComponent();

            //get report path.
            string reportPath = IMNSUtility.GetReportPath();
            string reportFileName = reportPath + "InventoryReport.rpt";

            if (IMNSUtility.IsFileExisted(reportFileName))
            {
                this.crystalReportViewer1.ReportSource = reportFileName;
            }
            else
            {
                MessageBox.Show("InventoryReport do not Exist. Please contact Admin");

            }
        }

        int _nQuantity = 0;
        InventoryReportData[] _lstInventoryReportData = null;
        public InventoryReportForm(int nQuantity) : this()
        {
            _nQuantity = nQuantity;
            //get all inventorys that has quantity less than nQuantity.
            _lstInventoryReportData = Program.NailSupplyManager.GetAllInventoryReportDataByQuantity(nQuantity);
        }

        private void InventoryReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                //load all inventory here
                DSProductInventory dsInventory = new DSProductInventory();
                DataTable dataTable = dsInventory.DSInventory;

                InventoryReport report = new InventoryReport();

                foreach (InventoryReportData data in _lstInventoryReportData)
                {
                    DataRow drow = dataTable.NewRow();
                    drow["InventoryID"] = "Inventory ID: " + data.InventoryID.ToString("00000");
                    drow["Name"] = "Name: " + data.ProductName;
                    drow["Barcode"] = "Barcode: " + data.Barcode;
                    drow["ProductUPK"] = "UPK: " + data.ProductUPK;
                    drow["TotalQuantity"] = "Total Quantity: " + data.TotalQuantity;
                    dataTable.Rows.Add(drow);
                }

                report.Database.Tables["DSInventory"].SetDataSource((DataTable)dataTable);


                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
