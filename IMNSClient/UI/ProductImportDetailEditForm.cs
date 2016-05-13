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
    public partial class ProductImportDetailEditForm : Form
    {
        public ProductImportDetailEditForm()
        {
            InitializeComponent();
        }

        Product _currentProduct = null;
        int _productImportID = -1;
        /// <summary>
        /// This contructor used for adding a new product import detail ID.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="isAdded"></param>
        /// <param name="productImportID"></param>
        public ProductImportDetailEditForm(Product p, bool isAdded, int productImportID)
            : this()
        {
            btnAdd.Visible = isAdded;
            btnUpdate.Visible = !isAdded;
            _currentProduct = p;
            _productImportID = productImportID;
            if (_currentProduct != null)
            {
                txtName.Text = p.Name;
                txtBarcode.Text = p.Barcode;
                txtImportPrice.Text = string.Format("{0:C2}", p.ImportPrice);
                txtQuantity.Text = "1"; //default value
            }
        }

        //This constructor used for edit a product import detail
        ProductImportDetail _productImportDetail = null;
        public ProductImportDetailEditForm(int productImportDetailID) : this ()
        {
            _productImportDetail = Program.NailSupplyManager.GetProductImportDetailByID(productImportDetailID);
            if (_productImportDetail != null)
            {
                //update GUI.
                string barcode = _productImportDetail.Barcode;
                Product p = Program.NailSupplyManager.GetProductByBarcode(barcode);
                if (p != null)
                    txtName.Text = p.Name;

                txtImportPrice.Text = string.Format("{0:C2}", _productImportDetail.ItemImportPrice);
                txtQuantity.Text = _productImportDetail.InQuantiry.ToString();
                txtBarcode.Text = barcode;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string strImportPrice = txtImportPrice.Text;
                if (string.IsNullOrEmpty(strImportPrice))
                {
                    MessageBox.Show("Please enter Import Price.");
                    return;
                }

                strImportPrice = strImportPrice.Replace("$", "");
                try
                {
                    decimal importPrice = decimal.Parse(strImportPrice);
                    if (importPrice != _currentProduct.ImportPrice)
                    {
                        _currentProduct.ImportPrice = importPrice;
                        //update current product import price for next time import this product.
                        Program.NailSupplyManager.UpdateProduct(ref _currentProduct);
                    }

                }
                catch
                {
                    MessageBox.Show("Import Price has to be a number");
                    return;
                }

                //quantity.
                if (string.IsNullOrEmpty(txtQuantity.Text))
                {
                    MessageBox.Show("Please enter the import Quantity for this Product");
                    return;
                }

                int nQuantity = 0;
                try
                {
                    nQuantity = int.Parse(txtQuantity.Text);
                }
                catch
                {
                    MessageBox.Show("Quantity has to be a number");
                    return;
                }

                //find inventory for this product, then assign the product to that inventory.
                //if not have, create a new one.
                Inventory inventory = Program.NailSupplyManager.GetInventoryByBarcode(_currentProduct.Barcode);
                if (inventory == null)
                {
                    //create inventory.
                    inventory = new Inventory();
                    inventory.Barcode = _currentProduct.Barcode;
                    inventory.Location = string.Empty;

                    int inventoryID = Program.NailSupplyManager.InsertInventory(inventory);
                    inventory.InventoryID = inventoryID;
                }
                

                //insert product import detail here.
                ProductImportDetail pDetail = new ProductImportDetail();
                pDetail.Barcode = _currentProduct.Barcode;
                pDetail.ImportDate = DateTime.Now;
                pDetail.InQuantiry = nQuantity;
                pDetail.OutQuantity = 0;
                pDetail.InventoryID = inventory.InventoryID;
                pDetail.ItemImportPrice = _currentProduct.ImportPrice;
                //pDetail.ItemImportStatus = 0; //already update at server side
                decimal totalPrice = _currentProduct.ImportPrice * nQuantity;
                pDetail.TotalImportPrice = totalPrice;
                pDetail.ProductImportID = _productImportID;

                Program.NailSupplyManager.InsertProductImportDetail(pDetail);

                //done, 
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error while adding product import detail." + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_productImportDetail == null)
                return;

            try
            {
                string strImportPrice = txtImportPrice.Text;
                if (string.IsNullOrEmpty(strImportPrice))
                {
                    MessageBox.Show("Please enter Import Price.");
                    return;
                }

                strImportPrice = strImportPrice.Replace("$", "");
                decimal importPrice = 0;
                try
                {
                    importPrice = decimal.Parse(strImportPrice);
                    Product currentProduct = Program.NailSupplyManager.GetProductByBarcode(_productImportDetail.Barcode);
                    if (currentProduct != null 
                        && currentProduct.ImportPrice != importPrice)
                    {
                        currentProduct.ImportPrice = importPrice;
                        //update this import price
                        Program.NailSupplyManager.UpdateProduct(ref currentProduct);
                    }

                }
                catch
                {
                    MessageBox.Show("Import Price has to be a number");
                    return;
                }

                //quantity.
                if (string.IsNullOrEmpty(txtQuantity.Text))
                {
                    MessageBox.Show("Please enter the import Quantity for this Product");
                    return;
                }

                int nQuantity = 0;
                try
                {
                    nQuantity = int.Parse(txtQuantity.Text);
                }
                catch
                {
                    MessageBox.Show("Quantity has to be a number");
                    return;
                }

                //here, we need to update the quantity of this product in the inventory also.
                int diffQuantity = nQuantity - _productImportDetail.InQuantiry;

                //update this product quantity in Inventory.
                Program.NailSupplyManager.UpdateProductQuantityInInventory(_productImportDetail.InventoryID, diffQuantity);

                _productImportDetail.ItemImportPrice = importPrice;

                _productImportDetail.InQuantiry = nQuantity;
                

                decimal totalPrice = importPrice * nQuantity;
                _productImportDetail.TotalImportPrice = totalPrice;

                //update product import detail at server side
                Program.NailSupplyManager.UpdateProductImportDetail(ref _productImportDetail);
               
                //done, 
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error while adding product import detail." + ex.Message);
            }
        }
    }
}
