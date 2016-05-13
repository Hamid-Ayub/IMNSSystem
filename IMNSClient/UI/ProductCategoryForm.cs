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
    public partial class ProductCategoryForm : Form
    {
        public ProductCategoryForm()
        {
            InitializeComponent();

            //set high of grid view, 
            gvCategory.RowTemplate.Height = 60;


            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Category[] data = Program.NailSupplyManager.GetAllProductCategory();

                productCategorySource.DataSource = data;
                gvCategory.DataSource = productCategorySource;
                gvCategory.Refresh();               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //insert new service category
            //check all valid info before inserting.
            try
            {
                string strCategory = txtCategoryName.Text;
                if (string.IsNullOrEmpty(txtCategoryName.Text))
                {
                    MessageBox.Show("Please enter Category Name.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCategoryName.Focus();
                    return;
                }
                
                //good, insert to DB at server.
                Program.NailSupplyManager.InsertProductCategory(strCategory);

                txtCategoryName.Text = string.Empty;
                //txtSaleTax.Text = string.Empty;
              
                LoadData();
                gvCategory.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error while adding a product category" + ex.Message);
            }
        }

        private void gvCategory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                MessageBox.Show("Invalid input. Please enter correctly!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error when working with this Service Category List. " + ex.Message);
            }
        }

        private void gvCategory_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (gvCategory.CurrentRow.Cells[0].Value == null)
                return;

            try
            {
                //need serviceID
                int categoryID = (int)gvCategory.CurrentRow.Cells[0].Value;

                if (e.ColumnIndex == 1) //category name
                {
                    string strCategoryName = e.FormattedValue.ToString();
                    if (!string.IsNullOrEmpty(strCategoryName))
                        Program.NailSupplyManager.UpdateCategoryName(categoryID, strCategoryName);
                        
                }
                //else if (e.ColumnIndex == 2) //category sale tax
                //{
                //    try
                //    {
                //        if (e.FormattedValue != null)
                //        {
                //            string strSaleTax = e.FormattedValue.ToString();
                //            float saleTax = float.Parse(strSaleTax);
                //            Program.NailSupplyManager.UpdateCategorySaleTax(categoryID, saleTax);
                //        }
                //    }
                //    catch
                //    {
                //        MessageBox.Show("Sale tax have to be a number");
                //        e.Cancel = true;
                //        return;
                //    }
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string coloumnName = gvCategory.Columns[e.ColumnIndex].Name;
            //need serviceID
            int categoryID = (int)gvCategory.CurrentRow.Cells[0].Value;

            if (coloumnName.ToLower().CompareTo("delete") == 0)
            {
                //delete button click.
                try
                {
                    if (MessageBox.Show("Delete this category will also delete all Products, Inventory related to this category. Do you really want to delete this selected Category?", "Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (this.gvCategory.CurrentRow.Index > -1)
                        {

                            Program.NailSupplyManager.DeleteCategory(categoryID);

                            LoadData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is an error when delete this Category. " + ex.Message);
                }
            }          
             
        }
    }
}
