using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMNS.ServiceModel.Service.BL;
using IMNSClient.Util;

namespace IMNSClient.UI
{
    public partial class ProductEditForm : BarcodeHandleForm
    {
        public ProductEditForm()
        {
            InitializeComponent();

            cboCategory.DataSource = Program.NailSupplyManager.GetAllProductCategory();
            cboProvider.DataSource = Program.NailSupplyManager.GetAllProvider();
        }

        Product _currentProduct = null;
        public ProductEditForm(Product p) : this()
        {
            _currentProduct = p;

            //initial GUI.
            txtBarcode.Text = p.Barcode;
            txtDes.Text = p.Description;
            txtImportPrice.Text = string.Format("{0:C2}", p.ImportPrice);
            txtSalePrice.Text = string.Format("{0:C2}", p.SalePrice);
            txtName.Text = p.Name;
            cboCategory.SelectedValue = p.CategoryID;
            cboProvider.SelectedValue = p.ProviderID;

            _bUpdate = false;
            _bError = false;

            this.BarcodeValueFired += ProductSettingsForm_BarcodeValueFired;
        }

        void ProductSettingsForm_BarcodeValueFired(string barcodeValue)
        {
            txtBarcode.Text = barcodeValue;

            //check to know whether or not other  textbox contains barcode by accidential
            txtName.Text = txtName.Text.Replace(barcodeValue, "");
            txtDes.Text = txtDes.Text.Replace(barcodeValue, "");
            txtSalePrice.Text = txtSalePrice.Text.Replace(barcodeValue, "");
            txtImportPrice.Text = txtImportPrice.Text.Replace(barcodeValue, "");
            this.DummyBarcode.Focus();

        }

        bool _bUpdate = false;

        public bool IsUpdate
        {
            get { return _bUpdate; }
            set { _bUpdate = value; }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_bUpdate)
            {
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

                    if (string.IsNullOrEmpty(barcode))
                    {
                        MessageBox.Show("Please use the Barcode Scanner to scan a Barcode for the Product. If the product does not have a barcode, please click on Generate Barcode button to create a new one", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //check whether the barcode is unique or not?
                    barcode = barcode.Replace("\r", "");
                    if (_currentProduct.Barcode != barcode)
                    {
                        Product oldProduct = Program.NailSupplyManager.GetProductByBarcode(barcode);
                        if (oldProduct != null)
                        {
                            MessageBox.Show(string.Format("The Barcode: {0} has already been used for another product, please click on the Generate Barcode button to create other one", barcode), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
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

                    string strSalePrice = txtSalePrice.Text;
                    strSalePrice = strSalePrice.Replace("$", "");
                    try
                    {

                        salePrice = decimal.Parse(strSalePrice);
                    }
                    catch
                    {
                        MessageBox.Show("Sale Price must be a number.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSalePrice.Focus();
                        return;
                    }

                    decimal importPrice = 0;
                    string strImportPrice = txtImportPrice.Text;
                    strImportPrice = strImportPrice.Replace("$", "");
                    if (string.IsNullOrEmpty(strImportPrice))
                    {
                        MessageBox.Show("Please enter Import Price for the Product", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtImportPrice.Focus();
                        return;
                    }

                    try
                    {
                        importPrice = decimal.Parse(strImportPrice);
                    }
                    catch
                    {
                        MessageBox.Show("Import Price must be a number.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtImportPrice.Focus();
                        return;
                    }

                    string strDes = txtDes.Text;

                    //call server to update the Provider.
                    _currentProduct.Name = txtName.Text;
                    _currentProduct.Barcode = barcode;
                    _currentProduct.BarcodeType = barcodeType;
                    _currentProduct.CategoryID = categoryId;
                    _currentProduct.ProviderID = providerId;
                    _currentProduct.ImportPrice = importPrice;
                    _currentProduct.SalePrice = salePrice;
                    _currentProduct.Description = strDes;

                    Program.NailSupplyManager.UpdateProduct(ref _currentProduct);

                    this.DialogResult = DialogResult.OK;
                }
                catch (TimeoutException ex)
                {
                    MessageBox.Show("The service operation timed out. " + ex.Message);
                    _bError = true;
                }
                catch (FaultException ex)
                {
                    MessageBox.Show("Fault: " + ex.ToString());
                    _bError = true;
                }
                catch (CommunicationException ex)
                {
                    MessageBox.Show("There was a communication problem. " +
                             ex.Message + ex.StackTrace);
                    _bError = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Other excpetion: " + ex.Message + ex.StackTrace);
                    _bError = true;
                }
                if (_bError)
                    this.DialogResult = DialogResult.Cancel;
            }
        }

        bool _bError = false;

        public bool IsError
        {
            get { return _bError; }
            set { _bError = value; }
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            _bUpdate = true;
        }

        private void OnSelectedValueChanged(object sender, EventArgs e)
        {
            _bUpdate = true;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error while generate barcode. Please try again: " + ex.Message);
            }
        }
    }
}
