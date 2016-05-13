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

namespace IMNSClient.UI
{
    public partial class ProductImportForm : Form
    {
        
        public ProductImportForm()
        {
            InitializeComponent();

            gvProductImport.RowTemplate.Height = 60;

            LoadData();
        }

        ProductImport[] _lstProductImport = null;
        private void LoadData()
        {
            _lstProductImport = Program.NailSupplyManager.GetAllProductImport();
            gvProductImport.DataSource = _lstProductImport;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //insert product import, 
            //then display product import detail form
            int productImportID = Program.NailSupplyManager.InsertProductImport();
            if (productImportID > 0)
            {
                //display product import detail form here
                ProductImportDetailForm frm = new ProductImportDetailForm(productImportID);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    LoadData(); //refersh list.
            }
        }

        private void gvProductImport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 5) return; //need status column
                int iStatus = (int)e.Value;
                switch (iStatus)
                {
                    case 0:
                        e.Value = NailSupplyData.ImportStatus.Initial.ToString();
                        break;
                    case 1:
                        e.Value = NailSupplyData.ImportStatus.Ready_Export.ToString();
                        break;
                    case 2:
                        e.Value = NailSupplyData.ImportStatus.Partial_Export.ToString();
                        break;
                    case 3:
                        e.Value = NailSupplyData.ImportStatus.Done_Export.ToString();
                        break;   
                    case 4:
                        e.Value = NailSupplyData.ImportStatus.Product_Return.ToString();
                        break;
                }                
            }
            catch
            {
            }
        }

        private void gvProductImport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string coloumnName = gvProductImport.Columns[e.ColumnIndex].Name;
            //need productImportID
            int productImportID = (int)gvProductImport.CurrentRow.Cells[0].Value;

            if (coloumnName.ToLower().CompareTo("delete") == 0)
            {
                //delete button click.
                try
                {
                    if (MessageBox.Show("Delete this Product Import will also delete all Product Import Details. Do you really want to delete this selected Product Import?", "Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (this.gvProductImport.CurrentRow.Index > -1)
                        {

                            Program.NailSupplyManager.DeleteProductImport(productImportID);

                            LoadData();
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
                    //display product import detail form here
                    ProductImportDetailForm frm = new ProductImportDetailForm(productImportID);
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        LoadData(); //refersh list.

                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is an error when edit this Inventory. " + ex.Message);
                }
            }
        }
    }
}
