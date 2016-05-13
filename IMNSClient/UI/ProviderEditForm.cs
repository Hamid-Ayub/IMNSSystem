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

namespace IMNSClient.UI
{
    public partial class ProviderEditForm : Form
    {
        public ProviderEditForm()
        {
            InitializeComponent();           
        }

        Provider _provider = null;
        bool _bUpdate = false;

        public bool IsUpdate
        {
            get { return _bUpdate; }
            set { _bUpdate = value; }
        }
        public ProviderEditForm(Provider p)
            : this()
        {
            _provider = p;
            if (_provider != null)
            {
                txtName.Text = _provider.Name;
                txtAddress.Text = _provider.Address;
                txtDescription.Text = _provider.Description;
                txtEmail.Text = _provider.Email;
                txtPhone.Text = _provider.Phone;
                _bUpdate = false;
            }
        }

        bool _bError = false;

        public bool IsError
        {
            get { return _bError; }
            set { _bError = value; }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if (_bUpdate)
            {
                try
                {
                    //call server to update the Provider.
                    _provider.Name = txtName.Text;
                    _provider.Address = txtAddress.Text;
                    _provider.Description = txtDescription.Text;
                    _provider.Phone = txtPhone.Text;
                    _provider.Email = txtEmail.Text;

                    Program.NailSupplyManager.UpdateProvider(ref _provider);

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

        private void OnTextChanged(object sender, EventArgs e)
        {
            _bUpdate = true;
        }
    }
}
