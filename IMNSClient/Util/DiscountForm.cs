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
    public partial class DiscountForm : Form
    {
        public DiscountForm()
        {
            InitializeComponent();
        }

        string _strNumber = string.Empty;

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
            this.DialogResult = DialogResult.OK;
        }

        private bool _bIsPercent = false;
        public bool IsPercent
        {
            get { return _bIsPercent; }
        }

        private void OnDiscountTypeClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string discountType = button.Tag.ToString();

            _bIsPercent = discountType == "%";              


            txtDiscountType.Text = discountType;
        }
    }
}
