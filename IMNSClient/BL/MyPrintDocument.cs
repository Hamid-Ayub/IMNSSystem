using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMNSClient.BL
{
    public class MyPrintDocument : PrintDocument
    {
        protected override void OnPrintPage(PrintPageEventArgs ev)
        {
            //Rectangle MarginBounds = new Rectangle(ev.MarginBounds.X, ev.MarginBounds.Y - 180, ev.MarginBounds.Width, ev.MarginBounds.Height);

            Rectangle MarginBounds = new Rectangle(10, 10, ev.MarginBounds.Width, ev.MarginBounds.Height);

            PrintPageEventArgs Printarg = new PrintPageEventArgs(ev.Graphics, MarginBounds, ev.PageBounds, ev.PageSettings);
            base.OnPrintPage(Printarg);

            if (Printarg.HasMorePages == true)
                ev.HasMorePages = true;

            //base.OnPrintPage(e);
        }
    }
}
