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
    public partial class ProductSellingForm : BarcodeHandleForm
    {
        public ProductSellingForm()
        {
            InitializeComponent();

            gvProductExport.RowTemplate.Height = 60;

            LoadData();

            this.BarcodeValueFired += ProductSettingsForm_BarcodeValueFired;

            this.DummyBarcode.Focus();
        }

        private void ProductSettingsForm_BarcodeValueFired(string barcodeValue)
        {
            try
            {
                //search the order barcode to find whether it existed or not.
                //if existed, will display this order detail for editting  
                ProductExport pExport = Program.NailSupplyManager.GetProductByBarcodeOrder(barcodeValue);
                if (pExport != null)
                {
                    try
                    {
                        //will new an export detail / order to complete the check out process.
                        //ReturnOrderDetailForm frm = new ReturnOrderDetailForm(pExport.ProductExportID);
                        //it should be edited here
                        ProductOrderDetailForm frm = new ProductOrderDetailForm(pExport.ProductExportID);
                        if (frm.ShowDialog() == DialogResult.OK) //update product export
                        {
                            //load data
                            LoadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There is an error when edit this Order. " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show(this, "There is not any order has the order id is " + barcodeValue + ". Please enter a vavid order barcode", "Barcode Order is invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ProductExport[] _lstProductExport = null;
        private void LoadData()
        {
            //read  all products import detail data of product import from server.
            _lstProductExport = Program.NailSupplyManager.GetAllProductExport();
            productExportDataSource.DataSource = _lstProductExport;            
        }
      
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                //first, create an guest customer and product export first.
                Customer guest = new Customer();
                guest.Name = string.Format("Guest:{0}", DateTime.Now.Ticks);
                int customerID = Program.NailSupplyManager.InsertCustomer(guest);
                if (customerID != -1)
                {
                    ProductExport export = new ProductExport();
                    export.Status = false; //open.
                    export.CustomerID = customerID;

                    int productExportID = Program.NailSupplyManager.InsertProductExport(export);

                    if (productExportID != -1)
                    {
                        //will new an export detail / order to complete the check out process.
                        ProductOrderDetailForm frm = new ProductOrderDetailForm(productExportID);
                        if (frm.ShowDialog() == DialogResult.OK) //update product export
                        {
                            LoadData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        const string In_Completed = "In Completed";
        const string Completed = "Completed";
        private void gvProductExport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 9) return; //need status column
                bool iStatus = (bool)e.Value;

                e.Value = iStatus ? Completed : In_Completed;
            }
            catch
            {
            }
        }

        private void gvProductExport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string coloumnName = gvProductExport.Columns[e.ColumnIndex].Name;
            //need productImportID
            int productExportID = (int)gvProductExport.CurrentRow.Cells[0].Value;

            if (coloumnName.ToLower().CompareTo("delete") == 0)
            {
                //delete button click.
                try
                {
                    if (this.gvProductExport.CurrentRow.Index > -1)
                    {

                        Program.NailSupplyManager.DeleteProductExport(productExportID);

                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is an error when delete this Order. " + ex.Message);
                }
            }
            else if (coloumnName.ToLower().CompareTo("edit") == 0)
            {
                try
                {
                    //will new an export detail / order to complete the check out process.
                    ProductOrderDetailForm frm = new ProductOrderDetailForm(productExportID);
                    if (frm.ShowDialog() == DialogResult.OK) //update product export
                    {
                        //load data
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is an error when edit this Order. " + ex.Message);
                }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                ReturnOrderDetailForm frm = new ReturnOrderDetailForm();
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error while returning this Order. Error: " + ex.Message);
            }
        }
    }
}
