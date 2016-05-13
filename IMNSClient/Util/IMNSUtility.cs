using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMNSClient.Util
{
    public class IMNSUtility
    {
        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms.ToArray();
            }
        }

        public static string GetApplicationPath()
        {
            string exLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string appPath = System.IO.Path.GetDirectoryName(exLocation);
            return appPath;
        }

        public static string GetReportPath()
        {
            return GetApplicationPath() + "\\Util\\";
        }

        internal static bool IsFileExisted(string fileName)
        {
            return File.Exists(fileName);
        }
    }
}
