using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMNSClient.UI
{
    public partial class ReportFunctionForm : Form
    {
        public ReportFunctionForm()
        {
            InitializeComponent();
        }

        private void btnSaleReport_Click(object sender, EventArgs e)
        {
            //sale report will calculate the different between import and export to calculate the revenue.
            //sale report should be fingure out the increasing and dereasing b/w each day, month and years
            SaleReportForm frm = new SaleReportForm();
            frm.ShowDialog(this);
        }
    }
}
