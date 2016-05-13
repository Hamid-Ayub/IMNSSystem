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

namespace IMNSClient.UI
{
    public partial class InventoryEditForm : Form
    {
        public InventoryEditForm()
        {
            InitializeComponent();
        }

        Inventory _inventory = null;
        public InventoryEditForm(Inventory inventory)
            : this()
        {
            _inventory = inventory;
            if (_inventory != null)
                txtLocation.Text = _inventory.Location;

            Product p = Program.NailSupplyManager.GetProductByBarcode(_inventory.Barcode);
            if (p != null)
                lblProductName.Text = p.Name;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string strLocation = txtLocation.Text;
            if (string.IsNullOrEmpty(strLocation))
                MessageBox.Show("Please enter Location for this product");

            _inventory.Location = strLocation;
            Program.NailSupplyManager.UpdateInventory(ref _inventory);
            this.DialogResult = DialogResult.OK;
        }
    }
}
