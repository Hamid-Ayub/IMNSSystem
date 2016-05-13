using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMNSClient.BL;

namespace IMNSClient
{
    static class Program
    {
        //generate proxy command
        //svcutil.exe /language:cs /out:generatedProxy.cs /config:app.config http://localhost:8000/IMNS.ServiceModel.Service.BL
        //end
        private static NailSupplyManager _manager = null;

        public static NailSupplyManager NailSupplyManager
        {
            get { return Program._manager; }
            set { Program._manager = value; }
        }

        //private static NailSupplyData _supplyData = null;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //Step 1: Create an endpoint address and an instance of the WCF Client.
                if (_manager == null)
                    _manager = new BL.NailSupplyManager();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new IMNSMainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
