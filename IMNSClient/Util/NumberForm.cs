using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace IMNSClient.Util
{
    public partial class NumberForm : Form
    {
        public NumberForm()
        {
            InitializeComponent();
        }

        public NumberForm(int p) : this()
        {
            // TODO: Complete member initialization
            _maxQuantity = p;
            this.lblHeader.Visible = true;
            lblHeader.Text = string.Format("There are {0} item(s) left in the Inventory.", _maxQuantity);
        }

        string _strNumber = string.Empty;
        private int _maxQuantity = 0;

        public string NumberResult
        {
            get { return _strNumber; }
            set { _strNumber = value; }
        }

        private void OnButtonNumberClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string number = button.Tag.ToString();

            _strNumber = _strNumber + number;
            txtResult.Text = _strNumber;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_strNumber.Length > 0)
            {
                _strNumber = _strNumber.Substring(0, _strNumber.Length - 1);
                txtResult.Text = _strNumber;
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_strNumber))
            {
                try
                {
                    int number = int.Parse(_strNumber);
                    if (number > _maxQuantity)
                    {
                        MessageBox.Show(this, string.Format("There only has {0} item(s) in the inventory. Please enter another Quantity", _maxQuantity), "Quantity Exceed", MessageBoxButtons.OK, MessageBoxIcon.Warning);  
                        return;
                    }
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void NumberForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
