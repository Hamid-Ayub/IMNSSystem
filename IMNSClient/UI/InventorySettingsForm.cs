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
    public partial class InventorySettingsForm : BarcodeHandleForm
    {
        
        public InventorySettingsForm()
        {
            InitializeComponent();


            this.BarcodeValueFired += ProductSettingsForm_BarcodeValueFired;

            //set high of grid view, 
            gvInventory.RowTemplate.Height = 60;


            LoadData();
        }

        Inventory[] _lstInventory = null;
        void LoadData()
        {
            _lstInventory = Program.NailSupplyManager.GetAllInventory();
            inventorySource.DataSource = _lstInventory;

            
        }

        void ProductSettingsForm_BarcodeValueFired(string barcodeValue)
        {
            //search barcode to find whether it existed or not.
            //if existed, will display this enventory for editing 
            Inventory inventory = Program.NailSupplyManager.GetInventoryByBarcode(barcodeValue);
            if (inventory != null)
            {
                ShowEditInventoryForm(inventory);
            }
            else
            {

                CheckBarcodeValue(barcodeValue);
                txtBarcode.Text = barcodeValue;
                this.DummyBarcode.Focus();
            }
        }

        private void ShowEditInventoryForm(Inventory inventory)
        {
            //display edit form.
            InventoryEditForm frm = new InventoryEditForm(inventory);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //reload list.
                LoadData();
            }
        }

        private void CheckBarcodeValue(string barcodeValue)
        {
            Product p = Program.NailSupplyManager.GetProductByBarcode(barcodeValue);

            if (p != null)
            {
                lblProductDescription.Text = p.Name;                               
            }
            else //not existed, display barcode on the form to use for adding new product 
            {
                DialogResult result = MessageBox.Show(string.Format("There is not any Product which has barcode is {0}. Do you want to create new Product for this Barcode", barcodeValue), "No Product with Barcode", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    //Display added product form.
                    ProductSettingsForm frm = new ProductSettingsForm();
                    frm.ShowDialog();
                    //recursive again.
                    CheckBarcodeValue(barcodeValue);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string strBarcode = txtBarcode.Text;
                if (string.IsNullOrEmpty(strBarcode))
                {
                    MessageBox.Show("Barcode can not be NULL. Please enter a barcode");
                    txtBarcode.Focus();
                    return;

                }
                strBarcode = strBarcode.Replace("\r", "");
                CheckBarcodeValue(strBarcode);

                string strLocation = txtLocation.Text;
                if (string.IsNullOrEmpty(strLocation))
                {
                    MessageBox.Show("Location can not be NULL. Please enter a location of this Product");
                    txtLocation.Focus();
                    return;
                }

                Inventory inventory = new Inventory();
                inventory.Barcode = strBarcode;
                inventory.Location = strLocation;

                Program.NailSupplyManager.InsertInventory(inventory);

                txtBarcode.Text = string.Empty;
                txtLocation.Text = string.Empty;
                lblProductDescription.Text = string.Empty;
                txtBarcode.Focus();
                LoadData(); //refersh list
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error when add this Inventory. " + ex.Message);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void gvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string coloumnName = gvInventory.Columns[e.ColumnIndex].Name;
            //need providerId
            int inventoryID = (int)gvInventory.CurrentRow.Cells[0].Value;

            if (coloumnName.ToLower().CompareTo("delete") == 0)
            {
                //delete button click.
                try
                {
                    if (MessageBox.Show("Delete this Inventory will also delete all Product Imports, Import Details, Product Exports, Export Details related to this Inventory. Do you really want to delete this selected Inventory?", "Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (this.gvInventory.CurrentRow.Index > -1)
                        {
                            if (Program.NailSupplyManager.IsAllowDeleteInventory(inventoryID) == true)
                            {

                                Program.NailSupplyManager.DeleteInventory(inventoryID);
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("There are some import product details, export product details associated with this inventory. You can not delete this Inventory", "Can not delete Inventory");
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is an error when delete this Inventory. " + ex.Message);
                }
            }
            else if (coloumnName.ToLower().CompareTo("edit") == 0)
            {
                try
                {
                    //initial ProviderEdit From, then LoadData again if the updating happened.
                    Inventory inventory = _lstInventory.First(c => c.InventoryID == inventoryID);
                    if (inventory != null)
                    {
                        ShowEditInventoryForm(inventory);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is an error when edit this Inventory. " + ex.Message);
                }
            }
        }

        private void gvInventory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 4) return; //need status column
                int iStatus = (int)e.Value;
                e.Value = iStatus == 0 ? NailSupplyData.Out_Of_Stock : NailSupplyData.Available;
            }
            catch
            {
            }
        }

        private void gvInventory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                //setting product name
                foreach (DataGridViewRow row in gvInventory.Rows)
                {
                    string barcode = row.Cells[1].Value.ToString(); //barcode
                    Product p = Program.NailSupplyManager.GetProductByBarcode(barcode);
                    if (p != null)
                        row.Cells[2].Value = p.Name; //product name
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
