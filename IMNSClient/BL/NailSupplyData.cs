using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMNSClient.BL
{
    public class NailSupplyData
    {
        public enum ImportStatus { Initial = 0, Ready_Export, Partial_Export, Done_Export, Product_Return};
        public const string Out_Of_Stock = "Out Of Stock";
        public const string Available = "Available";
    }
}
