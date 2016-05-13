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
    public partial class PriceCheckForm : BarcodeHandleForm
    {
        public PriceCheckForm()
        {
            InitializeComponent();

            this.BarcodeValueFired += ProductSettingsForm_BarcodeValueFired;
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
                        lblPrice.Text = string.Format("{0:C2}", p.SalePrice);
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

       
    }
}
