using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using IMNS.ServiceModel.Service.BL;
using IMNSClient.Util;

namespace IMNSClient.UI
{
    public partial class SaleReportForm : Form
    {
        Image _imgIncrease = null;
        Image _imgDecrease = null;
        public SaleReportForm()
        {
            InitializeComponent();

            AdjustSize();

            _imgIncrease = picTodaySale.BackgroundImage;
            _imgDecrease = picTodayProfit.BackgroundImage;

            RunTodaySaleReport();
        }

        private void RunTodaySaleReport()
        {
            try
            {
                DateTime startDate = DateTime.Now;

                DateTime endDate = DateTime.Now;

                endDate = endDate.AddDays(1);

                SaleReportData[] reportData = Program.NailSupplyManager.GetSaleReport(startDate, endDate);

                if (reportData.Count() > 0)
                {
                    SaleReportData todaySale = reportData[0];
                    DateTime yesterday = startDate.AddDays(-1); //yesterday.
                    decimal saleAmount = todaySale.TotalSaleAmount;
                    decimal incomeAmount = todaySale.IncomeAmount;
                    lblTodaySale.Text = string.Format("{0:C2}", saleAmount);
                    lblTodayProfit.Text = string.Format("{0:C2}", incomeAmount);

                    SaleReportData[] yesterdayData = Program.NailSupplyManager.GetSaleReport(yesterday, startDate);
                    if (yesterdayData.Count() > 0)
                    {
                        SaleReportData yesterdaySale = yesterdayData[0];
                        decimal yesterdaySaleAmount = yesterdaySale.TotalSaleAmount;
                        decimal yesterdayIncomeAmount = yesterdaySale.IncomeAmount;

                        //sale
                        decimal saleDiff = saleAmount - yesterdaySaleAmount;
                        decimal percentSaleDiff = Math.Abs(saleDiff) * 100 / saleAmount;
                        if (saleDiff < 0) //decrease
                        {
                            picTodaySale.BackgroundImage = _imgDecrease;
                            //lblPercentSale.Text = "-" + percentSaleDiff.ToString("00.00") + " %";
                            lblPercentSale.Text = string.Format("{0:C2} ({1} %)", Math.Abs(saleDiff), percentSaleDiff.ToString("00.00"));
                        }
                        else //increase.
                        {
                            picTodaySale.BackgroundImage = _imgIncrease;
                            //lblPercentSale.Text = "+" + percentSaleDiff.ToString("00.00") + " %";
                            lblPercentSale.Text = string.Format("{0:C2} ({1} %)", Math.Abs(saleDiff), percentSaleDiff.ToString("00.00"));
                        }

                        //profit
                        decimal profitDiff = incomeAmount - yesterdayIncomeAmount;
                        decimal percentProfitDiff = Math.Abs(profitDiff) * 100 / incomeAmount;
                        if (profitDiff < 0) //decrease
                        {
                            picTodayProfit.BackgroundImage = _imgDecrease;
                            //lblPercentProfit.Text = "-" + percentProfitDiff.ToString("00.00") + " %";
                            lblPercentProfit.Text = string.Format("{0:C2} ({1} %)", Math.Abs(profitDiff), percentProfitDiff.ToString("00.00"));
                        }
                        else //increase.
                        {
                            picTodayProfit.BackgroundImage = _imgIncrease;
                            //lblPercentProfit.Text = "+" + percentProfitDiff.ToString("00.00") + " %";
                            lblPercentProfit.Text = string.Format("{0:C2} ({1} %)", Math.Abs(profitDiff), percentProfitDiff.ToString("00.00"));
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AdjustSize()
        {
            //adjust main window size first.
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;

            //then, container panel
            mainSplitContainer.SplitterDistance = 150; //for extra $ panel

            reportSplitContainer.SplitterDistance = reportSplitContainer.Height / 2;

            bottomSplitContainer.SplitterDistance = bottomSplitContainer.Width / 2 + 20;

            bottomLeftSplitContainer.SplitterDistance = bottomLeftSplitContainer.Height - 30;
        }


        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = dtStartDate.Value;

                DateTime endDate = dtEndDate.Value;

                DateTime shortStartDate = Convert.ToDateTime(startDate.ToShortDateString());
                DateTime shortEndDate = Convert.ToDateTime(endDate.ToShortDateString());
                if (shortEndDate < shortStartDate)
                {
                    MessageBox.Show("Start date must be smaller than End date. Please select again!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                endDate = endDate.AddDays(1); //Becasue EndDate is shortdate, we need to add one 1 to make sure that the Report will run correctly.

                SaleReportData[] reportData = Program.NailSupplyManager.GetSaleReport(startDate, endDate);
                saleReportDataSource.DataSource = reportData;
                gvSaleReport.DataSource = saleReportDataSource;

                InitializeChart(reportData);

                grpSaleReportData.Text = string.Format("Sale report from {0} to {1}", shortStartDate.ToShortDateString(), shortEndDate.ToShortDateString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "There is an error while running the Sale Report. Error: " + ex.Message, "Sale Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeChart(SaleReportData[] reportData)
        {
            try
            {
                if (reportData.Count() > 0)
                {
                    //clear all child controls
                    this.reportSplitContainer.Panel1.Controls.Clear(); 

                    Chart saleReportChart = new Chart();
                    saleReportChart.Dock = DockStyle.Fill;
                    this.reportSplitContainer.Panel1.Controls.Add(saleReportChart);

                    SaleReport ds = new SaleReport();
                    DataTable dt = ds.SaleReportData;

                    foreach (SaleReportData data in reportData)
                    {
                        DataRow row = dt.NewRow();
                        row["Date"] = data.Date.ToString("m", CultureInfo.CreateSpecificCulture("en-us"));
                        row["Income"] = data.IncomeAmount;//.ToString("C2");

                        dt.Rows.Add(row);
                    }

                    //initial chart here.
                    saleReportChart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
                    saleReportChart.BorderlineColor = System.Drawing.Color.FromArgb(26, 59, 105);
                    saleReportChart.BorderlineWidth = 3;
                    saleReportChart.BackColor = Color.NavajoWhite;

                    saleReportChart.ChartAreas.Add("chtArea");
                    saleReportChart.ChartAreas[0].AxisX.Title = "Date";
                    saleReportChart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
                    saleReportChart.ChartAreas[0].AxisY.Title = "Profit Amount ($)";
                    saleReportChart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
                    saleReportChart.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
                    saleReportChart.ChartAreas[0].BorderWidth = 2;
                    //Chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
                    //Chart1.ChartAreas[0].Area3DStyle.Inclination = 45;
                    //Chart1.ChartAreas[0].Area3DStyle.Rotation = 45;
                    //Chart1.ChartAreas[0].Area3DStyle.PointDepth = 100;
                    //Chart1.ChartAreas[0].Area3DStyle.PointGapDepth = 1;

                    saleReportChart.Legends.Add("Income");
                    saleReportChart.Series.Add("Income");
                    //Chart1.Series[0].Palette = ChartColorPalette.Bright;
                    saleReportChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    saleReportChart.Series[0].Points.DataBindXY(dt.DefaultView, "Date", dt.DefaultView, "Income");

                    //Chart1.Series[0].IsVisibleInLegend = true;
                    saleReportChart.Series[0].IsValueShownAsLabel = true;
                    saleReportChart.Series[0].ToolTip = "Data Point Y Value: #VALY{G}";

                    // Setting Line Width
                    saleReportChart.Series[0].BorderWidth = 3;
                    saleReportChart.Series[0].Color = Color.Red;

                    // Setting Line Shadow
                    //Chart1.Series[0].ShadowOffset = 5;

                    //Legend Properties
                    saleReportChart.Legends[0].LegendStyle = LegendStyle.Table;
                    saleReportChart.Legends[0].TableStyle = LegendTableStyle.Wide;
                    //saleReportChart.Legends[0].Docking = Docking.Bottom;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "There is an error while initialize sale report chart. Error: " + ex.Message, "Initialize Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        decimal _totalIncome = 0;
        decimal _totalImportAmount = 0;
        decimal _totalSaleAmount = 0;
        private void gvSaleReport_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //used for update GUI for return product
            try
            {
                //setting product name
                _totalIncome = 0;
                _totalImportAmount = 0;
                _totalSaleAmount = 0;
                foreach (DataGridViewRow row in gvSaleReport.Rows)
                {
                    //update total quantity and total import price
                    decimal sale = (decimal)row.Cells[1].Value;
                    decimal import = (decimal)row.Cells[2].Value;
                    decimal income = (decimal)row.Cells[3].Value;

                    _totalIncome += income;
                    _totalImportAmount += import;
                    _totalSaleAmount += sale;                    
                }

                //create a new row for Grid Footer.
                gvFooter.Rows.Clear();
                gvFooter.Rows.Add(new object[] { "Total: ", string.Format("{0:C2}", _totalSaleAmount), 
                                                            string.Format("{0:C2}", _totalImportAmount),
                                                            string.Format("{0:C2}", _totalIncome) });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
    
}
