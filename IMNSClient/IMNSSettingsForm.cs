using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMNSClient.UI;

namespace IMNSClient
{
    public partial class IMNSSettingsForm : Form
    {
        public IMNSSettingsForm()
        {
            InitializeComponent();          
                
        }          

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintProductBarcode_Click(object sender, EventArgs e)
        {
            PrintProductBarcodeForm frm = new PrintProductBarcodeForm();
            frm.ShowDialog();
        }

        private void btnInventorySettings_Click(object sender, EventArgs e)
        {
            InventorySettingsForm frm = new InventorySettingsForm();
            frm.ShowDialog();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ProductImportForm frm = new ProductImportForm();
            frm.ShowDialog();
        }

        private void btnCategorySettings_Click(object sender, EventArgs e)
        {
            ProductCategoryForm frm = new ProductCategoryForm();
            frm.ShowDialog();
        }

        private void btnProviderSettings_Click(object sender, EventArgs e)
        {
            ProviderForm frm = new ProviderForm();
            frm.ShowDialog();
        }

        private void btnProductSettings_Click(object sender, EventArgs e)
        {
            ProductSettingsForm frm = new ProductSettingsForm();
            frm.ShowDialog();
        }

        private void btnUserSettings_Click(object sender, EventArgs e)
        {

        }
        
    }
}
