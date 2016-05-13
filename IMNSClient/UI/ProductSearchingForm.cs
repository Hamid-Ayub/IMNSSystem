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
    public partial class ProductSearchingForm : Form
    {
        public ProductSearchingForm()
        {
            InitializeComponent();
           
            //set high of grid view, 
            gvProduct.RowTemplate.Height = 60;
            

            //cboCategory.DataSource = Program.NailSupplyManager.GetAllProductCategory();
            //cboProvider.DataSource = Program.NailSupplyManager.GetAllProvider();
            LoadData();
        }

       
        Product[] _lstProduct = null;
        void LoadData()
        {
            //try
            //{              

            //    //find product by name.
            //    string strProductName = txtName.Text;

            //    if (string.IsNullOrEmpty(strProductName))
            //    {
            //        MessageBox.Show("Please enter a Product Name in order to find a Product.");
            //        return;
            //    }

            //    providerSource.DataSource = Program.NailSupplyManager.GetAllProvider();
            //    categorySource.DataSource = Program.NailSupplyManager.GetAllProductCategory();

            //    _lstProduct = Program.NailSupplyManager.SearchProductByName(strProductName);
            //    productDataSource.DataSource = _lstProduct;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("There is an error while loading the Products result: Error is:" + ex.Message, "Error Searching Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        Product m_Product = null;
        public Product ProductSelection
        {
            get { return m_Product; }
        }

        private void gvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string coloumnName = gvProduct.Columns[e.ColumnIndex].Name;
            //need providerId
            int productID = (int)gvProduct.CurrentRow.Cells[0].Value;

            if (coloumnName.ToLower().CompareTo("select") == 0)
            {
                try
                {
                    //initial ProviderEdit From, then LoadData again if the updating happened.
                    Product p = _lstProduct.First(c => c.ProductID == productID);
                    if (p != null)
                    {
                        m_Product = p;
                        this.DialogResult = DialogResult.OK;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is an error when select this Product. " + ex.Message);
                }
            }
            
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

                //find product by name.
                string strProductName = txtName.Text;

                if (string.IsNullOrEmpty(strProductName))
                {
                    MessageBox.Show("Please enter a Product Name in order to find a Product.");
                    return;
                }

                providerSource.DataSource = Program.NailSupplyManager.GetAllProvider();
                categorySource.DataSource = Program.NailSupplyManager.GetAllProductCategory();

                _lstProduct = Program.NailSupplyManager.SearchProductByName(strProductName);
                productDataSource.DataSource = _lstProduct;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error while loading the Products result: Error is:" + ex.Message, "Error Searching Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
