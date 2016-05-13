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
    /// <summary>
    /// For return a product we make it simple here as the business rule below
    /// only do return only, do not combine between return and selling
    /// </summary>
    public partial class ReturnOrderDetailForm : BarcodeHandleForm
    {
        const decimal TAX_PERCENT = 0.0825M;
        const string DEFAULT_PAYMENT_TYPE = "cash";
        public ReturnOrderDetailForm()
        {
            InitializeComponent();

            splitContainer1.SplitterDistance = this.Height * 2 / 3 - 50;

            gvProductExportDetail.RowTemplate.Height = 60;
            gvProductReturnDetail.RowTemplate.Height = 60;

            this.BarcodeValueFired += ProductSettingsForm_BarcodeValueFired;
        }

        int _productExportID = -1;
        int _productReturnID = -1;
        public ReturnOrderDetailForm(int productExportID)
            : this()
        {
            _productExportID = productExportID;

            ProductExport pExport = Program.NailSupplyManager.GetProductExportByID(_productExportID);
            if (pExport != null)
            {
                if (pExport.SubTax > 0)
                    _taxPercent = TAX_PERCENT;

                _discountAmount = pExport.SubDiscount;

                //create product return or order return here.
                CreateReturnOrder();

                //will update barcode return  after user click on Done button
            }

            LoadData();
        }

        /// <summary>
        /// Whenever this event is fired, we need to add this barcode value to the product export detail 
        /// </summary>
        /// <param name="barcodeValue"></param>
        private void ProductSettingsForm_BarcodeValueFired(string barcodeValue)
        {
            try
            {
                //export barcode or order barcode is a code 39 and its length = 10, otherwise product barcode length is either 
                //12 or 9
                if (barcodeValue.Length == 10) //order barcode, process return.
                {
                    if (_productExportID != -1)
                    {
                        MessageBox.Show("There is an order is being in return process. Please complete it first before processing the other.");
                        return;
                    }
                    //search the order barcode to find whether it existed or not.
                    //if existed, will display this order detail for editting  
                    ProductExport pExport = Program.NailSupplyManager.GetProductByBarcodeOrder(barcodeValue);
                    if (pExport != null)
                    {
                        try
                        {
                            _productExportID = pExport.ProductExportID;

                            if (pExport.SubTax > 0)
                                _taxPercent = TAX_PERCENT;

                            _discountAmount = pExport.SubDiscount;

                            CreateReturnOrder();

                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("There is an error when returning this Order. " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "There is not any order has the order id is " + barcodeValue + ". Please enter a vavid order barcode", "Barcode Order is invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else //product barcode, remove from order
                {
                    try
                    {
                        //get product detail from order detail first.
                        ProductExportDetail pDetail = Program.NailSupplyManager.GetProductExportDetailByProductBarcode(_productExportID, barcodeValue);

                        if (pDetail != null)
                        {
                            int productReturnDetailID = InsertProductReturnDetail(pDetail);

                            //remove product from order detail, then add it back to product return here
                            DecreaseProductInOrderDetail(barcodeValue, productReturnDetailID);

                            LoadData(); //refresh GUI.
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There is not any product has a barcode: " + barcodeValue);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        //use for a small product that can not attach the barcode in it.
        private void btnEnterProductUPK_Click(object sender, EventArgs e)
        {
            //first thing, we need to check the order id has been entered or or not
            if (_productExportID == -1)
            {
                MessageBox.Show(this, "Please scan the Order ID or enter the Order ID.", "Enter Order ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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
                        //get product detail from order detail first.
                        ProductExportDetail pDetail = Program.NailSupplyManager.GetProductExportDetailByProductBarcode(_productExportID, p.Barcode);

                        if (pDetail != null)
                        {
                            int productReturnDetailID = InsertProductReturnDetail(pDetail);

                            //remove product from order detail, then add it back to product return here
                            DecreaseProductInOrderDetail(p.Barcode, productReturnDetailID);

                            LoadData(); //refresh GUI.
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, string.Format("There is not any Product UPK is {0}. Please enter another one.", productUPK), "Product UPK is invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateReturnOrder()
        {
            if (_productExportID == -1)
                return;

            try
            {
                //create product return or order return here.
                ProductReturn pReturn = new ProductReturn();
                pReturn.ProductExportID = _productExportID;
                pReturn.FinalPriceReturn = 0;
                pReturn.ProductReturnBarcode = string.Empty; //will update after having _productReturnID.
                pReturn.TotalDiscountReturn = 0;
                pReturn.TotalItemReturn = 0;
                pReturn.TotalPriceReturn = 0;
                pReturn.TotalTaxReturn = 0;
                _productReturnID = Program.NailSupplyManager.InsertProductReturn(pReturn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int InsertProductReturnDetail(ProductExportDetail pExportDetail)
        {
            try
            {
                //do it at server side.
                ////insert product return detail here.
                //ProductReturnDetail pReturn = new ProductReturnDetail();
                //pReturn.Barcode = pExportDetail.Barcode;
                //pReturn.ProductReturnID = _productReturnID;

                ////need product export to calculate discount and tax return.
                //ProductExport pExport = Program.NailSupplyManager.GetProductExportByID(_productExportID);
                //pReturn.DiscountReturn = 0; //need to calculate
                return Program.NailSupplyManager.InsertProductReturnDetailByExportDetail(_productReturnID, pExportDetail);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// This function used for decrease product by 1 in an order detail, if an product has only one item, it will be removed out of the order 
        /// detail, 
        /// </summary>
        /// <param name="_productExportID"></param>
        /// <param name="barcodeValue"></param>
        private void DecreaseProductInOrderDetail(string barcodeValue, int productReturnDetailID)
        {
            try
            {
                Program.NailSupplyManager.DecreaseProductInOrderDetail(_productExportID, barcodeValue, productReturnDetailID);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ProductExportDetail[] _lstProductExportDetail = null;
        ProductReturnDetail[] _lstProudctReturnDetail = null;
        private void LoadData()
        {
            try
            {
                //read  all products import detail data of product import from server.
                _lstProductExportDetail = Program.NailSupplyManager.GetAllProductExportDetail(_productExportID);
                exportDetailDataSource.DataSource = _lstProductExportDetail;

                _lstProudctReturnDetail = Program.NailSupplyManager.GetAllProductReturnDetail(_productReturnID);
                productReturnSource.DataSource = _lstProudctReturnDetail;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
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

                //update discount amount, since the tax, discount amount have been changed
                ProductExport pExport = Program.NailSupplyManager.GetProductExportByID(_productExportID);
                if (pExport != null)
                {
                    _discountAmount = pExport.SubDiscount;

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

        private void btnOrderID_Click(object sender, EventArgs e)
        {
            if (_productExportID != -1)
            {
                MessageBox.Show("There is an order is being in return process. Please complete it first before processing the other.");
                return;
            }

            try
            {
                UPKNumberForm frm = new UPKNumberForm();
                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    //display order detail by entering order id
                    int orderID = int.Parse(frm.NumberResult);
                    //search the order barcode to find whether it existed or not.
                    //if existed, will display this order detail for editting  
                    ProductExport pExport = Program.NailSupplyManager.GetProductExportByID(orderID);
                    if (pExport != null)
                    {
                        try
                        {
                            _productExportID = pExport.ProductExportID;

                            if (pExport.SubTax > 0)
                                _taxPercent = TAX_PERCENT;

                            _discountAmount = pExport.SubDiscount;

                            CreateReturnOrder();

                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("There is an error when returning this Order has order ID = . " + orderID.ToString() + ". Error is" + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int _nTotalItemReturn = 0;
        decimal _totalReturnPrice = 0;
        decimal _totalDiscountReturn = 0;
        decimal _totalTaxReturn = 0;
        decimal _totalFinalReturnPrice = 0;
        private void gvProductReturnDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //used for update GUI for return product
            try
            {
                //setting product name
                _nTotalItemReturn = 0;
                _totalReturnPrice = 0;
                _totalDiscountReturn = 0;
                _totalTaxReturn = 0;
                _totalFinalReturnPrice = 0;
                foreach (DataGridViewRow row in gvProductReturnDetail.Rows)
                {
                    string barcode = row.Cells[2].Value.ToString(); //barcode
                    Product p = Program.NailSupplyManager.GetProductByBarcode(barcode);
                    if (p != null)
                    {
                        row.Cells[3].Value = p.Name; //product name
                        row.Cells[1].Value = p.ProductID.ToString("00000"); //product UPK
                    }

                    _nTotalItemReturn += 1;

                    //update total quantity and total import price
                    decimal priceReturn = (decimal)row.Cells[4].Value;
                    decimal taxReturn = (decimal)row.Cells[5].Value;
                    decimal discountReturn = (decimal)row.Cells[6].Value;
                    decimal finalReturn = (decimal)row.Cells[7].Value;

                    _totalReturnPrice += priceReturn;
                    _totalDiscountReturn += discountReturn;
                    _totalTaxReturn += taxReturn;
                    _totalFinalReturnPrice += finalReturn;
                }

                lblTotalItemReturn.Text = _nTotalItemReturn.ToString();                
                lblTaxReturn.Text = string.Format("{0:C2}", _totalTaxReturn);
                lblReturnPrice.Text = string.Format("{0:C2}", _totalReturnPrice);
                lblDiscountReturn.Text = string.Format("{0:C2}", _totalDiscountReturn);
                lblFinalReturn.Text = string.Format("{0:C2}", _totalFinalReturnPrice);

                this.DummyBarcode.Focus(); //let dummy barcode gets focus
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void gvProductReturnDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string coloumnName = gvProductReturnDetail.Columns[e.ColumnIndex].Name;
                //need productImportID
                int productReturnDetailID = (int)gvProductReturnDetail.CurrentRow.Cells[0].Value;

                if (coloumnName.ToLower().CompareTo("remove") == 0)
                {
                    if (this.gvProductReturnDetail.CurrentRow.Index > -1)
                    {
                        //delete productReturnDetail, then add it back to productExportDetail
                        Program.NailSupplyManager.AddProductReturnBackToProductDetail(productReturnDetailID);

                        //delete product return detail.
                        Program.NailSupplyManager.DeleteProductReturnDetail(productReturnDetailID);

                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// When click on the Done button, we will import product from product return detail back to the inventory
        /// and update product export, and its payment also.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDone_Click(object sender, EventArgs e)
        {
            try
            {
                //first, import product return back to the inventory.
                if (_productReturnID == -1)
                    return;

                Program.NailSupplyManager.ImportProductReturnBackToInventory(_productReturnID);

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

                //print product return receipt
                if (_productReturnID != -1) //has a product return
                {
                    //update product return
                    ProductReturn pReturn = Program.NailSupplyManager.GetProductReturnByID(_productReturnID);
                    if (pReturn != null)
                    {
                        //product return barcode will create from productReturnID, product return barcode is a code 39 and its length = 8
                        pReturn.ProductReturnBarcode = _productReturnID.ToString("00000000");
                        pReturn.FinalPriceReturn = _totalFinalReturnPrice;
                        pReturn.ProductExportID = _productExportID;
                        pReturn.TotalDiscountReturn = _totalDiscountReturn;
                        pReturn.TotalItemReturn = _nTotalItemReturn;
                        pReturn.TotalPriceReturn = _totalReturnPrice;
                        pReturn.TotalTaxReturn = _totalTaxReturn;

                        //update it to DB
                        Program.NailSupplyManager.UpdateProductReturn(ref pReturn);

                        //print return receipt.
                        PrintManager printMng = new PrintManager();
                        printMng.PrintOrderReturn(pReturn);
                    }
                }

                //close dialog.
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        

    }
}
