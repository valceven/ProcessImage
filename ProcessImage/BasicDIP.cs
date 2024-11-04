using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessImage
{
    static class BasicDIP
    {
        public static void Hist(ref Bitmap loaded, ref Bitmap processed)
        {
            Byte graydata;
            Color pixel;
            Color gray;

            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    pixel = loaded.GetPixel((int)x, (int)y);
                    graydata = (byte)((pixel.R + pixel.G + pixel.B) / 3);
                    gray = Color.FromArgb(graydata, graydata, graydata);
                    loaded.SetPixel(x, y, gray);
                }
            }

            int[] histdata = new int[256];

            for (int x = 0;x < loaded.Width; x++)
            {
                for(int y = 0;y < loaded.Height; y++)
                {
                    pixel = loaded.GetPixel(x, y);
                    histdata[pixel.R]++;
                }
            }

            processed = new Bitmap(256, 800);

            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 800; y++)
                {
                    processed.SetPixel(x, y, Color.CadetBlue);  
                }
            }

            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < Math.Min(histdata[x] / 5, processed.Height - 1); y++)
                {
                    processed.SetPixel(x, (processed.Height - 1) - y, Color.White);
                }
            }
        }
    }
}
