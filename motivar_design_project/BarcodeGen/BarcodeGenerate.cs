using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace BarcodeGen
{
    public static class BarcodeGenerate
    {
        public static Bitmap BarcodeGen(string bcinput)
        {

            Bitmap bitmap = new Bitmap(bcinput.Length * 40, 150);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Font oFont = new Font("IDAHC39M Code 39 Barcode", 20);
                PointF point = new PointF(2f, 2f);
                SolidBrush black = new SolidBrush(Color.Black);
                SolidBrush white = new SolidBrush(Color.White);

                graphics.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
                graphics.DrawString("*" + bcinput + "*", oFont , black , point);
            }

            using(MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return bitmap;
            }
            
        }
    }
}
