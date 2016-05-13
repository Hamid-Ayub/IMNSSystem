using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMNS.ServiceModel.Service.BL;

namespace IMNSClient.BL
{
    public class PrintManager
    {
        List<string> _lstPrintLines = null;
        private Font _printFont = null;
        private int _currentLine = 0; //reset current line first.
        private bool _bIsPrintOrder = false;
        private bool _bIsPrintOrderReturn = false;
        private string _barcodeOrder = string.Empty;
        private string _barcodeOrderReturn = string.Empty;
        public PrintManager()
        {
            _lstPrintLines = new List<string>();
            _printFont = new Font("Aria", 9);
            _currentLine = 0; //reset current line first.
        }

        public void PrintOrder(ProductExport order, Payment payment)
        {
            _lstPrintLines = BuildReceiptOrder(order, payment);
            _bIsPrintOrder = true;
            _barcodeOrder = order.ExportBarcode;


            MyPrintDocument pd = new MyPrintDocument();
            pd.PrintPage += new PrintPageEventHandler(OnPrintPageEvent);
            pd.Print();

            //12/09/14 - lht added to support the new requirement from custormer is to print the receipt 2 times
            //need to reset the _currentLine in order to print the second receipt
            _currentLine = 0;
            pd.Print();
            //end.
        }

        public void PrintOrderReturn(ProductReturn pReturn)
        {
            _bIsPrintOrderReturn = true;
            _lstPrintLines = BuildReturnOrder(pReturn);
            _barcodeOrderReturn = pReturn.ProductReturnBarcode;
            MyPrintDocument pd = new MyPrintDocument();
            pd.PrintPage += new PrintPageEventHandler(OnPrintPageEvent);
            pd.Print();

            //12/09/14 - lht added to support the new requirement from custormer is to print the receipt 2 times
            //need to reset the _currentLine in order to print the second receipt
            _currentLine = 0;
            pd.Print();
            //end.
        }

        /***************************************************************************
         *                       Receipt for Item(s) Return

                             |||||||||||||||||||||||||

                                LT Supply Nails
                                07/12/14 4PM
                -----------------------------------------------------------------------
                 Qnt   Items                           Tax      Dis    Price
                  1     OPI Nails                       $1      $1        $20
                  1     Spa chair                                          $1500
                ---------------------------------------------------------------
                                                  Total  Items: 2
                                                  Price Return: $1520
                                                  Discount Return: $50
                                                  Tax Return: $20
                                               -----------------------------
                                                  Total Return: $1490
                
         * * *************************************************************************/
        private List<string> BuildReturnOrder(ProductReturn pReturn)
        {
            List<string> lstLines = new List<string>();

            if (pReturn != null)
            {
                string line = "---------------------------------------------------------------";

                //string shortline = "-----------------------------------------";

                lstLines.Add(string.Format("       NAIL DEPOT Supply") + System.Environment.NewLine);

                lstLines.Add(string.Format("       Date: {0}  Time: {1}", DateTime.Now.ToShortDateString(),
                                                    DateTime.Now.ToShortTimeString()) + System.Environment.NewLine);

                lstLines.Add(line + System.Environment.NewLine);

                string strItems = "         Items"; //40 chars.
                string strQnt = "Qnt  "; //5 chars
                string strPrice = " Price"; //5 chars
                string strTax = "        Tax";
                string strDis = "    Dis";

                //lstLines.Add("Items                        Qnt    Price" + System.Environment.NewLine);
                lstLines.Add(strQnt + strPrice + strDis + strTax + strItems + System.Environment.NewLine);

                ProductReturnDetail[] lstReturnDetails = Program.NailSupplyManager.GetAllProductReturnDetail(pReturn.ProductReturnID);

                //append to return detail.

                foreach (ProductReturnDetail returnDetail in lstReturnDetails)
                {
                    string productBarcode = returnDetail.Barcode;
                    Product p = Program.NailSupplyManager.GetProductByBarcode(productBarcode);
                    if (p != null)
                    {
                        string itemName = p.Name;
                        if (itemName.Length > 20)
                            itemName = itemName.Substring(0, 19);

                        itemName = itemName.PadRight(30);
                        string quantity = returnDetail.Quantity.ToString();
                        quantity = quantity.PadRight(5);
                        string subTotal = string.Format("{0:C2}", returnDetail.PriceReturn);
                        subTotal = subTotal.PadRight(10);
                        string taxReturn = string.Format("{0:C2}", returnDetail.TaxReturn);
                        taxReturn = taxReturn.PadRight(10);
                        string disReturn = string.Format("{0:C2}", returnDetail.DiscountReturn);
                        disReturn = disReturn.PadRight(10);
                        //lstLines.Add(string.Format("{0}         {1:C2}    {2:C2}", p.Name, orderDetail.Quantity, orderDetail.SubTotal));
                        lstLines.Add(quantity + subTotal + disReturn + taxReturn + itemName + System.Environment.NewLine);
                    }
                }
                //end

                lstLines.Add(line + System.Environment.NewLine);

                //payment type, 
                lstLines.Add(string.Format("                Total Items: {0}", pReturn.TotalItemReturn) + System.Environment.NewLine);

                lstLines.Add(string.Format("                Price Return: {0:C2}", pReturn.TotalPriceReturn) + System.Environment.NewLine);

                lstLines.Add(string.Format("                Discount Return: {0:C2}", pReturn.TotalDiscountReturn) + System.Environment.NewLine);

                lstLines.Add(string.Format("                Tax Return: {0:C2}", pReturn.TotalTaxReturn) + System.Environment.NewLine);

                lstLines.Add(string.Format("             ---------------------------------") + System.Environment.NewLine);

                lstLines.Add(string.Format("                   Final Return: {0:C2}", pReturn.FinalPriceReturn) + System.Environment.NewLine);

            }

            return lstLines;
        }

        /***************************************************************************
         *                       Receipt for Order

                             |||||||||||||||||||||||||

                                LT Supply Nails
                                07/12/14 4P:M
                ---------------------------------------------------------------
                    Items                           Qnt                    Price
                 OPI Nails                           1                       $20
                 Spa chair                           1                       $1500
                ---------------------------------------------------------------
                                                  Total  Items: 2
                                                  Total Price: $1520
                                                  Discount: $50
                                                  Tax Amount: $20
                                               -----------------------------
                                                  Sub Total: $1490
                cashier: tho
         * * *************************************************************************/
        private const int ITEM_NAME_LENGTH = 25;
        private List<string> BuildReceiptOrder(ProductExport order, Payment payment)
        {
            List<string> lstLines = new List<string>();

            if (order != null
                && payment != null)
            {
                string line = "---------------------------------------------------------------";

                //string shortline = "-----------------------------------------";

                lstLines.Add(string.Format("       NAIL DEPOT Supply") + System.Environment.NewLine);
               
                lstLines.Add(string.Format("       Date: {0}  Time: {1}", DateTime.Now.ToShortDateString(),
                                                    DateTime.Now.ToShortTimeString()) + System.Environment.NewLine);

                lstLines.Add(line + System.Environment.NewLine);

                string strItems = "Items                                   "; //40 chars.
                string strQnt = "Qnt  "; //5 chars
                string strPrice = "Price"; //5 chars

                //lstLines.Add("Items                        Qnt    Price" + System.Environment.NewLine);
                lstLines.Add(strQnt + strItems + strPrice + System.Environment.NewLine);

                ProductExportDetail[] lstExportDetails = Program.NailSupplyManager.GetAllProductExportDetail(order.ProductExportID);

                //append to order detail.

                foreach (ProductExportDetail orderDetail in lstExportDetails)
                {
                    string productBarcode = orderDetail.Barcode;
                    Product p = Program.NailSupplyManager.GetProductByBarcode(productBarcode);
                    if (p != null)
                    {
                        string quantity = orderDetail.Quantity.ToString();
                        quantity = quantity.PadRight(5);
                        string subTotal = string.Format("{0:C2}", orderDetail.SubTotal);
                        subTotal = subTotal.PadRight(5);

                        string itemName = p.Name;

                        //12/29/14 - lht modified to fix the error is that the item name is too long, so the price is overlap and can not see while print
                        //out

                        if (itemName.Length > ITEM_NAME_LENGTH) //long item name
                        {
                            //need to print at the second line.
                            string line1 = itemName.Substring(0, ITEM_NAME_LENGTH);

                            //what if the trimming happens at the middle of a world, so we need to process the trimming.
                            int lastIndex = line1.LastIndexOf(' ');
                            int nLength = ITEM_NAME_LENGTH;
                            if (lastIndex < nLength)
                                nLength = lastIndex;

                            //update line1
                            line1 = itemName.Substring(0, nLength);

                            line1 = line1.PadRight(30);

                            //lstLines.Add(string.Format("{0}         {1:C2}    {2:C2}", p.Name, orderDetail.Quantity, orderDetail.SubTotal));
                            lstLines.Add(quantity + line1 + subTotal + System.Environment.NewLine);

                            //render the substring.
                            string remainName = itemName.Substring(nLength, itemName.Length - nLength);

                            nLength = ITEM_NAME_LENGTH + 15; //another line should have its length = 35
                            int nLoop = remainName.Length / nLength;
                            string line2 = string.Empty;
                            for (int i = 0; i <= nLoop; i++)
                            {
                                //print out the remained name at the second line.
                                if (i == nLoop) //last line.
                                    line2 = remainName.Substring(nLength * i, remainName.Length - nLength * i);
                                else
                                    line2 = remainName.Substring(nLength * i, nLength);

                                //print line2.
                                lstLines.Add("      " + line2 + System.Environment.NewLine);
                            }

                            //int nLoop = itemName.Length / ITEM_NAME_LENGTH;
                            //string line2 = string.Empty;
                            //for (int i = 0; i < nLoop; i++)
                            //{
                            //    //print out the remained name at the second line.
                            //    if (i == nLoop - 1) //last line.
                            //        line2 = itemName.Substring(ITEM_NAME_LENGTH * (i + 1), itemName.Length - ITEM_NAME_LENGTH * (i + 1));
                            //    else
                            //        line2 = itemName.Substring(ITEM_NAME_LENGTH * (i + 1), ITEM_NAME_LENGTH);

                            //    //print line2.
                            //    lstLines.Add("      " + line2 + System.Environment.NewLine);
                            //}


                        }
                        else //normal short name
                        {
                            itemName = itemName.PadRight(40);

                            //lstLines.Add(string.Format("{0}         {1:C2}    {2:C2}", p.Name, orderDetail.Quantity, orderDetail.SubTotal));
                            lstLines.Add(quantity + itemName + subTotal + System.Environment.NewLine);
                        }

                        //end

                        //12/29/14 - removed original code
                        //itemName = itemName.PadRight(40);
                        //string quantity = orderDetail.Quantity.ToString();
                        //quantity = quantity.PadRight(5);
                        //string subTotal = string.Format("{0:C2}", orderDetail.SubTotal);
                        //subTotal = subTotal.PadRight(5);
                        ////lstLines.Add(string.Format("{0}         {1:C2}    {2:C2}", p.Name, orderDetail.Quantity, orderDetail.SubTotal));
                        //lstLines.Add(quantity + itemName + subTotal + System.Environment.NewLine);
                    }
                }
                //end

                lstLines.Add(line + System.Environment.NewLine);

                //payment type, 
                lstLines.Add(string.Format("                Total Items: {0}", order.TotalQuantity) + System.Environment.NewLine);

                lstLines.Add(string.Format("                Total Price: {0:C2}", payment.TotalItemAmount) + System.Environment.NewLine);

                lstLines.Add(string.Format("                   Discount: {0:C2}", payment.TotalDiscountAmount) + System.Environment.NewLine);

                lstLines.Add(string.Format("                           Tax: {0:C2}", payment.TotalTaxAmount) + System.Environment.NewLine);

                lstLines.Add(string.Format("             ---------------------------------") + System.Environment.NewLine);

                lstLines.Add(string.Format("                   Sub Total: {0:C2}", payment.TotalPayment) + System.Environment.NewLine);

                lstLines.Add(string.Format("Cashier: {0}", payment.Cashier) + System.Environment.NewLine);

            }

            return lstLines;
        }

        // The PrintPage event is raised for each page to be printed.
        float _totalLinesPerPage = 0;
        private void OnPrintPageEvent(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;

            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = string.Empty;

            int lineNumber = 0;

            if (_bIsPrintOrder) //print order 
            {
                //print barcode, 
                yPos = topMargin;

                ev.Graphics.DrawString("                      Receipt for Order", _printFont, Brushes.Black, leftMargin, yPos, new StringFormat());

                yPos = yPos + _printFont.GetHeight(ev.Graphics);

                BarcodeLib.Barcode b = new BarcodeLib.Barcode();

                Image img = b.Encode(BarcodeLib.TYPE.CODE39, _barcodeOrder.Trim(), Color.Black, Color.White, 200, 50);

                ev.Graphics.DrawImage(img, leftMargin + 30, yPos);

                lineNumber = 6; //start at this line for other info
            }
            else if (_bIsPrintOrderReturn) //print order return
            {
                //print barcode, 
                yPos = topMargin;

                ev.Graphics.DrawString("                      Receipt for Item(s) Return", _printFont, Brushes.Black, leftMargin, yPos, new StringFormat());

                yPos = yPos + _printFont.GetHeight(ev.Graphics);

                BarcodeLib.Barcode b = new BarcodeLib.Barcode();

                Image img = b.Encode(BarcodeLib.TYPE.CODE39, _barcodeOrderReturn.Trim(), Color.Black, Color.White, 200, 50);

                ev.Graphics.DrawImage(img, leftMargin + 30, yPos);

                lineNumber = 6; //start at this line for other info
            }

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height / _printFont.GetHeight(ev.Graphics);

            while (_currentLine < linesPerPage + _totalLinesPerPage)
            {
                if (_currentLine < _lstPrintLines.Count)
                {
                    line = _lstPrintLines[_currentLine];

                    //yPos = topMargin + (_currentLine * _printFont.GetHeight(ev.Graphics));
                    yPos = topMargin + (lineNumber * _printFont.GetHeight(ev.Graphics));

                    ev.Graphics.DrawString(line, _printFont, Brushes.Black,
                       leftMargin, yPos, new StringFormat());

                    _currentLine++;
                    lineNumber++;
                }
                else
                {
                    line = null;
                    break; //stop loop.
                }
            }

            // If more lines exist, print another page.
            if (line != null)
            {

                ev.HasMorePages = true;
                _totalLinesPerPage += linesPerPage;
            }
            else
            {
                ev.HasMorePages = false;
                //_lstLines.Clear();
            }
        }
    }
}
