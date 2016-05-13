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
using IMNSClient.BL;
using IMNSClient.Util;

namespace IMNSClient.UI
{
    public partial class InventoryPriceCheckForm : BarcodeHandleForm
    {
        public InventoryPriceCheckForm()
        {
            InitializeComponent();

            this.BarcodeValueFired += ProductSettingsForm_BarcodeValueFired;

            this.progressBar1.Maximum = 100;
            this.progressBar1.Minimum = 0;
        }

        private void ProductSettingsForm_BarcodeValueFired(string barcodeValue)
        {
            try
            {
                //search barcode to find whether it existed or not.
                //if existed, will display this enventory for editing 
                Product p = Program.NailSupplyManager.GetProductByBarcode(barcodeValue);
                if (p != null)
                {
                    Inventory inventory = Program.NailSupplyManager.GetInventoryByBarcode(barcodeValue);

                    if (inventory != null)
                    {
                        lblName.Text = p.Name;
                        lblPrice.Text = string.Format("There are {0} item(s) in the Inventory", inventory.TotalQuantity);
                        lblStatus.Text = inventory.ProductStatus == 0 ? NailSupplyData.Out_Of_Stock : NailSupplyData.Available;

                        this.DummyBarcode.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("There is not any product has a barcode: " + barcodeValue + " Please add this product to the IMNS system");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewAllProductInventory_Click(object sender, EventArgs e)
        {
            string strQuantity = txtQuantity.Text;
            if (string.IsNullOrEmpty(strQuantity))
            {
                MessageBox.Show(this, "Please enter a Quantity in order to check the Inventory for all Products under that Quantity", "Enter Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                timer1.Start();
                int nQuantity = int.Parse(txtQuantity.Text);

                //view all product under that quantity, display a form of these products
                InventoryReportForm frm = new InventoryReportForm(nQuantity);
                timer1.Stop();
                frm.ShowDialog(this) ;

                progressBar1.Value = 0; //reset it to initial value
                this.DummyBarcode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
        }
    }
}
