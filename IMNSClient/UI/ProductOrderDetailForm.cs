using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMNS.ServiceModel.Service.BL;
using IMNSClient.BL;
using IMNSClient.Util;

namespace IMNSClient.UI
{
    public partial class ProductOrderDetailForm : BarcodeHandleForm
    {
        const decimal TAX_PERCENT = 0.0825M;
        const string DEFAULT_PAYMENT_TYPE = "cash";
        public ProductOrderDetailForm()
        {
            InitializeComponent();

            splitContainer1.SplitterDistance = this.Height * 2 / 3 - 50;

            gvProductExportDetail.RowTemplate.Height = 60;

            this.BarcodeValueFired += ProductSettingsForm_BarcodeValueFired;
        }

        /// <summary>
        /// Whenever this event is fired, we need to add this barcode value to the product export detail 
        /// </summary>
        /// <param name="barcodeValue"></param>
        private void ProductSettingsForm_BarcodeValueFired(string barcodeValue)
        {
            try
            {
                //search barcode to find whether it existed or not.
                //if existed, will display this enventory for editing 
                Product p = Program.NailSupplyManager.GetProductByBarcode(barcodeValue);
                if (p != null)
                {
                    InsertProductToOrderDetail(p);
                }
                else
                {
                    MessageBox.Show("There is not any product has the barcode: " + barcodeValue + " Please add this product to the IMNS system");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InsertProductToOrderDetail(Product p)
        {
            if (p == null)
                return;

            try
            {
                Inventory inventory = Program.NailSupplyManager.GetInventoryByBarcode(p.Barcode);

                if (inventory != null)
                {
                    if (inventory.ProductStatus == 0)
                    {
                        MessageBox.Show(this, string.Format("This product: {0} is temporary Out Of Stock. Please select another item or check back later", p.Name), "Out Of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //create an product export detail.
                    ProductExportDetail orderDetail = new ProductExportDetail();
                    orderDetail.Barcode = p.Barcode;
                    orderDetail.InventoryID = inventory.InventoryID;
                    orderDetail.ItemPrice = p.SalePrice;
                    orderDetail.ProductExportID = _productExportID;
                    //default is 1, will show a dialog to ask to enter product quantity if clicked on enter quantity checkbox
                    if (chkShowQuantityDlg.Checked)
                    {
                        NumberForm frm = new NumberForm(inventory.TotalQuantity);
                        if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            if (!string.IsNullOrEmpty(frm.NumberResult))
                                orderDetail.Quantity = int.Parse(frm.NumberResult);
                        }
                    }
                    if (orderDetail.Quantity <= 0)
                        orderDetail.Quantity = 1;

                    //check the desired quantity is available in inventory or not. 
                    //if yes, go ahead, if not, need to pop-up message let the user know that

                    orderDetail.SubTotal = orderDetail.ItemPrice * orderDetail.Quantity;

                    //insert to DB
                    Program.NailSupplyManager.InsertProductExportDetail(orderDetail);

                    //refresh list.
                    LoadData();

                    this.DummyBarcode.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("This product is temporary out of stock. Please check Inventory", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ProductExportDetail[] _lstProductExportDetail = null;
        private void LoadData()
        {
            try
            {
                //read  all products import detail data of product import from server.
                _lstProductExportDetail = Program.NailSupplyManager.GetAllProductExportDetail(_productExportID);
                exportDetailDataSource.DataSource = _lstProductExportDetail;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }


        int _productExportID = -1;
        public ProductOrderDetailForm(int productExportID)
            : this()
        {
            _productExportID = productExportID;

            ProductExport pExport = Program.NailSupplyManager.GetProductExportByID(_productExportID);
            if (pExport != null)
            {
                if (pExport.SubTax > 0)
                    _taxPercent = TAX_PERCENT;

                _discountAmount = pExport.SubDiscount;
            }

            LoadData();
        }

        int _nQuantity = 0;
        decimal _totalPrice = 0;
        decimal _taxAmount = 0;
        decimal _taxPercent = 0;
        decimal _discountAmount = 0;
        decimal _finalDiscount = 0;
        bool _isDiscountPercent = false;
        decimal _finalTotal = 0;
        decimal _totalImportPrice = 0;
        private void gvProductExportDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            UpdateGUI();
        }

        private void UpdateGUI()
        {
            try
            {
                //setting product name
                _nQuantity = 0;
                _totalPrice = 0;
                _totalImportPrice = 0;
                foreach (DataGridViewRow row in gvProductExportDetail.Rows)
                {
                    string barcode = row.Cells[2].Value.ToString(); //barcode
                    Product p = Program.NailSupplyManager.GetProductByBarcode(barcode);
                    if (p != null)
                    {
                        row.Cells[3].Value = p.Name; //product name
                        row.Cells[1].Value = p.ProductID.ToString("00000"); //product UPK
                    }

                    //update total quantity and total import price
                    int rowQuantity = (int)row.Cells[5].Value;
                    _nQuantity += rowQuantity;

                    decimal rowTotalPrice = (decimal)row.Cells[6].Value;
                    _totalPrice += rowTotalPrice;

                    _totalImportPrice += p.ImportPrice;
                }

                decimal discount = 0;
                if (_isDiscountPercent)
                    discount = (_discountAmount / 100) * _totalPrice;
                else
                    discount = _discountAmount;

                _finalDiscount = discount;

                //finish discount, calculate finalPrice.
                _finalTotal = _totalPrice - discount; 

                //tax will calculate based on _finalTotal
                _taxAmount = _taxPercent * _finalTotal;

                if (_taxPercent != 0)
                    lblTaxAmount.Text = string.Format("{0}% * {1:C2} = {2:C2}", (TAX_PERCENT * 100).ToString("F", CultureInfo.InvariantCulture), _finalTotal, _taxAmount);
                else
                    lblTaxAmount.Text = string.Format("{0:C2}", _taxAmount);

                //update final total
                _finalTotal = _finalTotal + _taxAmount; //total needs to plus tax
                
                if (_isDiscountPercent)
                    lblDiscountAmount.Text = string.Format("{0}% * {1:C2} = {2:C2}", _discountAmount, _totalPrice, discount);
                else
                    lblDiscountAmount.Text = string.Format("{0:C2}", discount);              

                lblTotalQuantity.Text = _nQuantity.ToString();
                lblTotalPrice.Text = string.Format("{0:C2}", _totalPrice);
                lblFinalPrice.Text = string.Format("{0:C2}", _finalTotal);

                this.DummyBarcode.Focus(); //let dummy barcode gets focus
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void gvProductExportDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string coloumnName = gvProductExportDetail.Columns[e.ColumnIndex].Name;
            //need productImportID
            int productExportDetailID = (int)gvProductExportDetail.CurrentRow.Cells[0].Value;

            if (coloumnName.ToLower().CompareTo("delete") == 0)
            {
                //delete button click.
                try
                {
                    if (this.gvProductExportDetail.CurrentRow.Index > -1)
                    {

                        Program.NailSupplyManager.DeleteProductExportDetail(productExportDetailID);

                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is an error when delete this Product Export Detail. " + ex.Message);
                }
            }
            else if (coloumnName.ToLower().CompareTo("edit") == 0) //edit product quantities only
            {
                try
                {
                    ProductExportDetail orderDetail = Program.NailSupplyManager.GetProductExportDetailByID(productExportDetailID);
                    if (orderDetail != null)
                    {
                        Inventory inventory = Program.NailSupplyManager.GetInventoryByBarcode(orderDetail.Barcode);
                        if (inventory != null)
                        {
                            NumberForm frm = new NumberForm(inventory.TotalQuantity);
                            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                            {
                                if (!string.IsNullOrEmpty(frm.NumberResult))
                                {
                                    orderDetail.Quantity = int.Parse(frm.NumberResult);

                                    if (orderDetail.Quantity <= 0)
                                        orderDetail.Quantity = 1;

                                    //check the desired quantity is available in inventory or not. 
                                    //if yes, go ahead, if not, need to pop-up message let the user know that

                                    orderDetail.SubTotal = orderDetail.ItemPrice * orderDetail.Quantity;

                                    //insert to DB
                                    Program.NailSupplyManager.UpdateProductExportDetail(ref orderDetail);

                                    //refresh list.
                                    LoadData();

                                    this.DummyBarcode.Focus();
                                }
                            }

                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is an error when edit this Product Import Detail. " + ex.Message);
                }
            }
        }

        private void btnAddTax_Click(object sender, EventArgs e)
        {
            _taxPercent = TAX_PERCENT; //temporary harcode here, will move this number to configuration file later.
            UpdateGUI();
        }

        private void btnRemoveTax_Click(object sender, EventArgs e)
        {
            _taxPercent = 0;
            UpdateGUI();
            
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            try
            {
                //display discount Form here.
                DiscountForm frm = new DiscountForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _isDiscountPercent = frm.IsPercent;
                    _discountAmount = decimal.Parse(frm.NumberResult);
                    UpdateGUI();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            try
            {
                //update order or product export, then payment also.
                //1: update product export, change order status to complete (1), and update all other fields
                ProductExport pExport = Program.NailSupplyManager.GetProductExportByID(_productExportID);
                if (pExport != null)
                {
                    pExport.Status = true; //complete
                    //export barcode will calculate from productExportID, export barcode or order barcode is a code 39 and its length = 10
                    pExport.ExportBarcode = _productExportID.ToString("0000000000");
                    pExport.FinalSalePrice = _finalTotal;
                    pExport.SubDiscount = _finalDiscount;
                    pExport.SubTax = _taxAmount;
                    pExport.SubTotal = _totalPrice;
                    //need to calculate total import price
                    pExport.TotalImportPrice = _totalImportPrice;
                    pExport.TotalQuantity = _nQuantity;

                    //call update product export.
                    Program.NailSupplyManager.UpdateProductExport(ref pExport);

                    //then, we need to udpate or insert payment.
                    Payment p = new Payment();
                    //p.Cashier = //cashier is a user who log in to the system.
                    p.PaymentType = DEFAULT_PAYMENT_TYPE;
                    p.ProductExportID = pExport.ProductExportID;
                    p.TotalItemAmount = _totalPrice;
                    p.TotalPayment = _finalTotal;
                    p.TotalTaxAmount = _taxAmount;
                    p.TotalDiscountAmount = _finalDiscount;

                    //insert payment for this product export, then print out a receipt for this order
                    Program.NailSupplyManager.InsertPayment(p);

                    //print out order.
                    PrintManager print = new PrintManager();
                    print.PrintOrder(pExport, p);                   
                }

                //close dialog.
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //used to add product to order detail by using product UPK
        private void btnEnterProductUPK_Click(object sender, EventArgs e)
        {
            try
            {
                UPKNumberForm frm = new UPKNumberForm();
                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    //add product to order detail by using product UPK.
                    int productUPK = int.Parse(frm.NumberResult);
                    Product p = Program.NailSupplyManager.GetProductByID(productUPK);
                    if (p != null)
                    {
                        InsertProductToOrderDetail(p); //call this method to add product to order detail
                    }
                    else
                    {
                        MessageBox.Show(this, string.Format("There is not any product has Product UPK is {0}. Please enter again.", productUPK), "Invalid Product UPK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //display search product from.
                //enter product name, then display all products have that name
                ProductSearchingForm frm = new ProductSearchingForm();
                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    Product p = frm.ProductSelection;
                    if (p != null)
                    {
                        InsertProductToOrderDetail(p); //call this method to add product to order detail
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
