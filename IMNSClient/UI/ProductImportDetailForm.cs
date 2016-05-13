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
    public partial class ProductImportDetailForm : BarcodeHandleForm
    {
        public ProductImportDetailForm()
        {
            InitializeComponent();

            splitContainer1.SplitterDistance = this.Height * 2 / 3;

            gvProductImportDetail.RowTemplate.Height = 60;

            this.BarcodeValueFired += ProductSettingsForm_BarcodeValueFired;
           
        }

        private void ProductSettingsForm_BarcodeValueFired(string barcodeValue)
        {
            try
            {
                //First, check whether or not the product has been imported previously, 
                //if yes, open this product import detail, so that the user can edit this previously imported.
                ProductImportDetail pImportDetail = Program.NailSupplyManager.GetProductImportDetailOfProductImportByBarcode(_productImportID, barcodeValue);
                if (pImportDetail != null)
                {
                    try
                    {
                        //display product import detail edit form here
                        ProductImportDetailEditForm frm = new ProductImportDetailEditForm(pImportDetail.ProductImportDetailID);
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            LoadData(); //refersh list.
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There is an error when edit this Product Import Detail. " + ex.Message);
                    }
                }
                else
                {

                    //no, do as normal.
                    //search barcode to find whether it existed or not.
                    //if existed, will display this product for editing 
                    Product p = Program.NailSupplyManager.GetProductByBarcode(barcodeValue);
                    if (p != null)
                    {
                        //display product import detail added Form
                        ProductImportDetailEditForm frm = new ProductImportDetailEditForm(p, true, _productImportID); //added new product import detail
                        if (frm.ShowDialog() == DialogResult.OK)
                            LoadData(); //referesh list
                    }
                    else
                    {
                        //not existed, display product settings Form to add this product
                        //barcode on the form to use for adding new product
                        //txtBarcode.Text = barcodeValue;
                        ProductSettingsForm frm = new ProductSettingsForm();
                        frm.ShowDialog();
                        this.DummyBarcode.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int _productImportID = -1;
        public ProductImportDetailForm(int productImportID) : this()
        {
            _productImportID = productImportID;
            LoadData();
        }

        ProductImportDetail[] _lstProductImportDetail = null;
        private void LoadData()
        {
            //read  all products import detail data of product import from server.
            _lstProductImportDetail = Program.NailSupplyManager.GetAllProductImportDetail(_productImportID);
            importDetailSource.DataSource = _lstProductImportDetail;
        }

        private void gvProductImportDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                //setting product name
                int nQuantity = 0;
                decimal totalImportPrice = 0;
                foreach (DataGridViewRow row in gvProductImportDetail.Rows)
                {
                    string barcode = row.Cells[1].Value.ToString(); //barcode
                    Product p = Program.NailSupplyManager.GetProductByBarcode(barcode);
                    if (p != null)
                        row.Cells[2].Value = p.Name; //product name

                    //update total quantity and total import price
                    int rowQuantity = (int)row.Cells[4].Value;
                    nQuantity += rowQuantity;

                    decimal rowTotalPrice = (decimal)row.Cells[5].Value;
                    totalImportPrice += rowTotalPrice;
                }

                lblTotalQuantity.Text = nQuantity.ToString();
                lblTotalImportPrice.Text = string.Format("{0:C2}", totalImportPrice);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            //update subtotal, quantity, status for the product detail.
            ProductImport pImport = Program.NailSupplyManager.GetProductImportByID(_productImportID);
            int nInQuantity = 0; 
            decimal subTotal = 0;
           
            foreach (ProductImportDetail importDetail in _lstProductImportDetail)
            {
                nInQuantity += importDetail.InQuantiry;
                subTotal += importDetail.TotalImportPrice;
                
            }
            pImport.TotalInQuantity = nInQuantity;
            pImport.SubTotal = subTotal;            
           
            pImport.ImportStatus = (int)NailSupplyData.ImportStatus.Ready_Export;
            Program.NailSupplyManager.UpdateProductImport(ref pImport);
            this.DialogResult = DialogResult.OK;
        }

        private void gvProductImportDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string coloumnName = gvProductImportDetail.Columns[e.ColumnIndex].Name;
            //need productImportID
            int productImportDetailID = (int)gvProductImportDetail.CurrentRow.Cells[0].Value;

            if (coloumnName.ToLower().CompareTo("delete") == 0)
            {
                //delete button click.
                try
                {
                    if (this.gvProductImportDetail.CurrentRow.Index > -1)
                    {

                        Program.NailSupplyManager.DeleteProductImportDetail(productImportDetailID);

                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is an error when delete this Product Import Detail. " + ex.Message);
                }
            }
            else if (coloumnName.ToLower().CompareTo("edit") == 0)
            {
                try
                {
                    //display product import detail edit form here
                    ProductImportDetailEditForm frm = new ProductImportDetailEditForm(productImportDetailID);
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        LoadData(); //refersh list.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is an error when edit this Product Import Detail. " + ex.Message);
                }
            }
        }
    }
}
