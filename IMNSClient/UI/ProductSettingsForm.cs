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
    public partial class ProductSettingsForm : BarcodeHandleForm
    {
        public ProductSettingsForm()
        {
            InitializeComponent();
            this.BarcodeValueFired += ProductSettingsForm_BarcodeValueFired;

            //set high of grid view, 
            gvProduct.RowTemplate.Height = 60;
            

            cboCategory.DataSource = Program.NailSupplyManager.GetAllProductCategory();
            cboProvider.DataSource = Program.NailSupplyManager.GetAllProvider();
            LoadData();
        }

        public ProductSettingsForm(string barcode)
            : this()
        {
            txtBarcode.Text = barcode;
            this.DummyBarcode.Focus();
        }

        Product[] _lstProduct = null;
        void LoadData()
        {
            providerSource.DataSource = Program.NailSupplyManager.GetAllProvider();
            categorySource.DataSource = Program.NailSupplyManager.GetAllProductCategory();
            _lstProduct = Program.NailSupplyManager.GetAllProducts();
            productDataSource.DataSource = _lstProduct;
        }

        void ProductSettingsForm_BarcodeValueFired(string barcodeValue)
        {
            //MessageBox.Show("Barcode value is: " + barcodeValue);          

            //search barcode to find whether it existed or not.
            //if existed, will display this product for editing 
            Product p = Program.NailSupplyManager.GetProductByBarcode(barcodeValue);
            if (p != null)
                ShowEditProductForm(p);
            else
            {
                //not existed, display barcode on the form to use for adding new product
                txtBarcode.Text = barcodeValue;
                this.DummyBarcode.Focus();
            }
        }

       
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            ProductCategoryForm frm = new ProductCategoryForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                cboCategory.DataSource = Program.NailSupplyManager.GetAllProductCategory();
            }
            this.DummyBarcode.Focus();
        }

        private void btnAddProvider_Click(object sender, EventArgs e)
        {
            ProviderForm frm = new ProviderForm();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cboProvider.DataSource = Program.NailSupplyManager.GetAllProvider();
            }
            this.DummyBarcode.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //insert new product to DB at server side
            //check all valid info before inserting.
            try
            {
                string strName = txtName.Text;
                if (string.IsNullOrEmpty(strName))
                {
                    MessageBox.Show("Please enter Product Name.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Focus();
                    return;
                }

                if (cboCategory.SelectedValue == null)
                {
                    MessageBox.Show("Please select Product Category.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                    return;
                }

                int categoryId = (int)cboCategory.SelectedValue;
                
                if (cboProvider.SelectedValue == null)
                {
                    MessageBox.Show("Please select Provider.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int providerId = (int)cboProvider.SelectedValue;

                string barcode = txtBarcode.Text;
                barcode = barcode.Replace("\r", "");
                if (string.IsNullOrEmpty(barcode))
                {
                    MessageBox.Show("Please use the Barcode Scanner to scan a Barcode for the Product. If the product does not have a barcode, please click on Generate Barcode button to create a new one", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                    return;
                }

                string barcodeType = string.Empty;
                if (barcode.Length == 12)
                    barcodeType = "UPCA";
                else if (barcode.Length == 8)
                    barcodeType = "UPCE";
                
                decimal salePrice = 0;
                if (string.IsNullOrEmpty(txtSalePrice.Text))
                {
                    MessageBox.Show("Please enter Sale Price for the Product", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSalePrice.Focus();
                    return;
                }

                try
                {
                    salePrice = decimal.Parse(txtSalePrice.Text);
                }
                catch
                {
                    MessageBox.Show("Sale Price must be a number.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSalePrice.Focus();
                    return;
                }

                decimal importPrice = 0;
                if (string.IsNullOrEmpty(txtImportPrice.Text))
                {
                    MessageBox.Show("Please enter Import Price for the Product", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtImportPrice.Focus();
                    return;
                }

                try
                {
                    importPrice = decimal.Parse(txtImportPrice.Text);
                }
                catch
                {
                    MessageBox.Show("Import Price must be a number.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtImportPrice.Focus();
                    return;
                }

                string strDes = txtDes.Text;

                //good, insert to DB at server.
                Product p = new Product();
                p.Name = strName;
                p.CategoryID = categoryId;
                p.ProviderID = providerId;
                p.Barcode = barcode;
                p.BarcodeType = barcodeType;
                p.SalePrice = salePrice;
                p.ImportPrice = importPrice;
                p.Description = strDes;

                int result = Program.NailSupplyManager.InsertProduct(p);

                if (result == -2) //barcode is not unique, need to generate other one.
                {
                    MessageBox.Show(string.Format("The Barcode: {0} has already been used for another product, please click on the Generate Barcode button to create other one", barcode), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //done, reset all GUI.
                txtName.Text = string.Empty;
                txtBarcode.Text = string.Empty;
                txtSalePrice.Text = string.Empty;
                txtImportPrice.Text = string.Empty;
                txtDes.Text = string.Empty;
               
                //txtSaleTax.Text = string.Empty;

                LoadData();
                gvProduct.Refresh();
                this.DummyBarcode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error while adding a product category" + ex.Message);
            }
        }

        private void gvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string coloumnName = gvProduct.Columns[e.ColumnIndex].Name;
            //need providerId
            int productID = (int)gvProduct.CurrentRow.Cells[0].Value;

            if (coloumnName.ToLower().CompareTo("delete") == 0)
            {
                //delete button click.
                try
                {
                    if (MessageBox.Show("Delete this Product will also delete all Inventory, Product Imports, Exports related to this Product. Do you really want to delete this selected Product?", "Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (this.gvProduct.CurrentRow.Index > -1)
                        {

                            Program.NailSupplyManager.DeleteProduct(productID);

                            LoadData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is an error when delete this Product. " + ex.Message);
                }
            }
            else if (coloumnName.ToLower().CompareTo("edit") == 0)
            {
                try
                {
                    //initial ProviderEdit From, then LoadData again if the updating happened.
                    Product p = _lstProduct.First(c => c.ProductID == productID);
                    if (p != null)
                    {
                        ShowEditProductForm(p);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is an error when edit this provider. " + ex.Message);
                }
            }
            this.DummyBarcode.Focus();
        }

        private void ShowEditProductForm(Product p)
        {
            try
            {
                ProductEditForm frm = new ProductEditForm(p);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.IsUpdate)
                        LoadData();
                }
                else //cancel or error
                {
                    if (frm.IsError)
                        MessageBox.Show("There is another computer updated this record. Please click on the Refresh button to get the latest data", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.DummyBarcode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerateBarcode_Click(object sender, EventArgs e)
        {
            //barcode generated has to be unique, if not: we have to regenerate other one.
            try
            {
                int providerID = (int)cboProvider.SelectedValue;
                string barcodeString = GenerateBarcode(providerID);
                barcodeString = barcodeString.Replace("\r", ""); 
                txtBarcode.Text = barcodeString;
                this.DummyBarcode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error while generate barcode. Please try again: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            this.DummyBarcode.Focus();
        }        
    }
}
