using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMNSClient.Util
{
    public partial class BarcodeHandleForm : Form
    {
        public delegate void BarcodeValueHandler(string barcodeValue);
        public event BarcodeValueHandler BarcodeValueFired;

        public TextBox DummyBarcode
        {
            get { return txtDummyBarcode; }
            set { txtDummyBarcode = value; }
        }

        public BarcodeHandleForm()
        {
            InitializeComponent();

            txtDummyBarcode.Top = -10000;
            txtDummyBarcode.Left = -10000;
            txtDummyBarcode.Width = 10;
            txtDummyBarcode.Height = 10;
            txtDummyBarcode.Focus();
        }

        DateTime _lastKeystroke = new DateTime(0);
        List<char> _barcode = new List<char>(10);
        private void BarcodeHandleForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // check timing (keystrokes within 100 ms)
            TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
            if (elapsed.TotalMilliseconds > 100)
                _barcode.Clear();

            // record keystroke & timestamp
            _barcode.Add(e.KeyChar);
            _lastKeystroke = DateTime.Now;

            // process barcode
            if (e.KeyChar == 13 && _barcode.Count > 0)
            {
                string msg = new String(_barcode.ToArray());
                _barcode.Clear();
                //raise event.
                if (BarcodeValueFired != null)
                {
                    msg = msg.Replace("\r", "");
                    BarcodeValueFired(msg);
                }
            }
        }

        /// <summary>
        //Barcode is genereated by some condition below:
        //Product Type = 4: No format restrictions, in-store use on non-food items.
        //Manufacture code = xxxxx: 5 numbers are created by Provider Id.
        //ex: providerid = 1: manufacture type = 10000
        //Product code = xxxxx: 5 numbers are created by Product id
        //ex: newest product id = y, so y + 1 is the id of new product => Product code = (y+1)0000
        //check sum: calculated as follow
        //For example: UPC-A 01234567890
        //Product Type : 0
        //Manufacturer's Code : 12345
        //Product Code : 67890
        //The first digit '0' is odd, so multiple it by 3, the second digit 1 is even so just add it, etc...
        //(0 * 3) + 1 + (2 * 3) + 3 + (4 * 3) + 5 + (6 * 3) + 7 + (8 * 3) + 9 + (0 * 3) = 85
        //85 % 10 = 5
        //( ( 10 - 5 ) % 10 ) = 5
        /// </summary>
        /// <param name="providerID"></param>
        /// <returns></returns>
        public string GenerateBarcode(int providerID)
        {
            string barcode = string.Empty;
            string productType = "4";
            string manufactureCode = GetUPCStringCode(providerID);
            string productCode = string.Empty;
            string checkSum = string.Empty;
            int newestProductId = Program.NailSupplyManager.GetNewsetProductID();

            if (newestProductId < -1)
            {
                MessageBox.Show("There is an error in client side. Please contact Admin for help.");
                return string.Empty;
            }

            do
            {
                productCode = GetUPCStringCode(newestProductId + 1);

                checkSum = CalculateChecksumDigit(productType, manufactureCode, productCode);

                barcode = string.Format("{0}{1}{2}{3}", productType, manufactureCode, productCode, checkSum);

                newestProductId++;
            }
            while (Program.NailSupplyManager.IsBarCodeExisted(barcode) == true);

            return barcode;
        }

        private string CalculateChecksumDigit(string productType, string manufactureCode, string productCode)
        {
            string sTemp = productType + manufactureCode + productCode;
            int iSum = 0;
            int iDigit = 0;

            // Calculate the checksum digit here.
            for (int i = 1; i <= sTemp.Length; i++)
            {
                iDigit = Convert.ToInt32(sTemp.Substring(i - 1, 1));
                if (i % 2 == 0)
                {    // even
                    iSum += iDigit * 1;
                }
                else
                {    // odd
                    iSum += iDigit * 3;
                }
            }

            int iCheckSum = (10 - (iSum % 10)) % 10;
            return iCheckSum.ToString();
        }


        private string GetUPCStringCode(int input)
        {
            string upcStringCode = input.ToString();
            int inLength = upcStringCode.Length;
            int length = 5 - inLength;
            if (length < 0)
            {
                MessageBox.Show("Out of Provider/Product. Please contact Admin for help.");
                return string.Empty;
            }
            for (int i = 0; i < length; i++)
            {
                upcStringCode = upcStringCode + "0";
            }
            return upcStringCode;
        }
    }
}
