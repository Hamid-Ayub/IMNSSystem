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
    public partial class ProviderForm : Form
    {
        public ProviderForm()
        {
            InitializeComponent();
            //set high of grid view, 
            gvProvider.RowTemplate.Height = 60;


            LoadData();
        }

        Provider[] _lstProvider = null;
        private void LoadData()
        {
            try
            {
                _lstProvider = Program.NailSupplyManager.GetAllProvider();

                providerDataSource.DataSource = _lstProvider;
                gvProvider.DataSource = providerDataSource;
                gvProvider.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //insert new provider
            //check all valid info before inserting.
            try
            {
                string strName = txtName.Text;
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("Please enter Provider Name.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Focus();
                    return;
                }

                string strAddress = txtAddress.Text;
                if (string.IsNullOrEmpty(txtAddress.Text))
                {
                    MessageBox.Show("Please enter Provider Address.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAddress.Focus();
                    return;
                }

                string strEmail = txtEmail.Text;
                string strPhone = txtPhone.Text;
                string strDes = txtDescription.Text;

                //good, insert to DB at server.
                Program.NailSupplyManager.InsertProvider(strName, strAddress, strEmail, strPhone, strDes);

                txtName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtDescription.Text = string.Empty;

                LoadData();
                gvProvider.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error while adding a product category" + ex.Message);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {

        }

        private void gvProvider_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 6)  return;            
            byte[] array = (byte[])e.Value;
            e.Value = string.Empty;
            //foreach (byte b in array)
            //{
            //    e.Value += String.Format("{0:x2} ", b);
            //}

            StringBuilder sb = new StringBuilder();
            foreach (var x in array)
            {
                sb.Append(x.ToString());
                sb.Append(" ");
            }
            e.Value = sb.ToString();
        }

        private void gvProvider_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string coloumnName = gvProvider.Columns[e.ColumnIndex].Name;
            //need providerId
            int providerID = (int)gvProvider.CurrentRow.Cells[0].Value;

            if (coloumnName.ToLower().CompareTo("delete") == 0)
            {
                //delete button click.
                try
                {
                    if (MessageBox.Show("Delete this Provider will also delete all Products, Inventory related to this Provider. Do you really want to delete this selected Provider?", "Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (this.gvProvider.CurrentRow.Index > -1)
                        {

                            Program.NailSupplyManager.DeleteProvider(providerID);

                            LoadData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is an error when delete this Provider. " + ex.Message);
                }
            }
            else if (coloumnName.ToLower().CompareTo("edit") == 0)
            {
                try
                {
                    //initial ProviderEdit From, then LoadData again if the updating happened.
                    Provider p = _lstProvider.First(c => c.ProviderID == providerID);
                    if (p != null)
                    {
                        ProviderEditForm frm = new ProviderEditForm(p);
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

                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is an error when edit this provider. " + ex.Message);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
