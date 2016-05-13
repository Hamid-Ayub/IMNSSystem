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
using IMNSClient.UI;

namespace IMNSClient
{
    public partial class IMNSMainForm : Form
    {
        public IMNSMainForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            IMNSSettingsForm frm = new IMNSSettingsForm();
            frm.ShowDialog();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ProductImportForm frm = new ProductImportForm();
            frm.ShowDialog();
        }

        private void btnPrintProductBarcode_Click(object sender, EventArgs e)
        {
            PrintProductBarcodeForm frm = new PrintProductBarcodeForm();
            frm.ShowDialog();
        }

        private void btnPriceCheck_Click(object sender, EventArgs e)
        {
            PriceCheckForm frm = new PriceCheckForm();
            frm.ShowDialog();
        }

        private void btnSaleProducts_Click(object sender, EventArgs e)
        {
            ProductSellingForm frm = new ProductSellingForm();
            frm.ShowDialog(this);
        }

        private void btnCheckInventory_Click(object sender, EventArgs e)
        {
            InventoryPriceCheckForm frm = new InventoryPriceCheckForm();
            frm.ShowDialog(this);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportFunctionForm frm = new ReportFunctionForm();
            frm.ShowDialog(this);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                //first, create an guest customer and product export first.
                Customer guest = new Customer();
                guest.Name = string.Format("Guest:{0}", DateTime.Now.Ticks);
                int customerID = Program.NailSupplyManager.InsertCustomer(guest);
                if (customerID != -1)
                {
                    ProductExport export = new ProductExport();
                    export.Status = false; //open.
                    export.CustomerID = customerID;

                    int productExportID = Program.NailSupplyManager.InsertProductExport(export);

                    if (productExportID != -1)
                    {
                        //will new an export detail / order to complete the check out process.
                        ProductOrderDetailForm frm = new ProductOrderDetailForm(productExportID);
                        frm.ShowDialog(this);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
