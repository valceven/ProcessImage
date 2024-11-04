using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessImage
{
    public partial class ImageProcessor : Form
    {
        Bitmap loaded, processed;

        public ImageProcessor()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void pixelCopyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);
            Color pixel;

            for(int x = 0; x < loaded.Width; x++)
            {
                for(int y = 0;y < loaded.Height; y++)
                {
                    pixel = loaded.GetPixel(x, y);
                    processed.SetPixel(x, y, pixel);
                }
            }

            pictureBox2.Image = processed;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            processed.Save(saveFileDialog1.FileName);
        }

        private void greyscalingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int grey;
            processed = new Bitmap(loaded.Width, loaded.Height);
            Color pixel;
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    pixel = loaded.GetPixel((int)x, (int)y);
                    grey = (int)(pixel.R + pixel.G + pixel.B) / 3;
                    Color gray = Color.FromArgb(grey, grey, grey);
                    processed.SetPixel(x, y, gray);
                }
            }

            pictureBox2.Image = processed;
        }

        private void inversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            processed = new Bitmap(loaded.Width, loaded.Height);
            Color pixel;
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    pixel = loaded.GetPixel((int)x, (int)y);
                    Color temp = Color.FromArgb(255 - pixel.R,255 - pixel.G,255 - pixel.B);
                    processed.SetPixel(x, y, temp);
                }
            }

            pictureBox2.Image = processed;
        }

        private void mirrorHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);
            Color pixel;
            for (int x = loaded.Width - 1; x > 0; x--)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    pixel = loaded.GetPixel(x, y);
                    processed.SetPixel(loaded.Width - x, y, pixel);
                }
            }
            pictureBox2.Image = processed;
        }

        private void mirrorVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);
            Color pixel;
            for (int i = 0 ; i < loaded.Width; i++)
            {
                for (int j = loaded.Height - 1 ; j > 0; j--)
                {
                    pixel = loaded.GetPixel(i, j);
                    processed.SetPixel(i, loaded.Height - j, pixel);
                }
            }
            pictureBox2.Image = processed;
        }

        
        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicDIP.Hist(ref loaded,ref processed);
            pictureBox2.Image = processed;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);
            Color pixel;
            double r,g,b;

            for (int i = 0 ; i < loaded.Width;i++)
            {
                for (int j = 0 ; j < loaded.Height; j++)
                {
                    pixel = loaded.GetPixel(i,j);
                    r = Math.Min((pixel.R * 0.393) + (pixel.G * 0.769) + (pixel.B * 0.189) * 1.2, 255);
                    g = Math.Min((pixel.R * 0.349) + (pixel.G * 0.686) + (pixel.B * 0.168) * 1.2, 255);
                    b = Math.Min((pixel.R * 0.272) + (pixel.G * 0.534) + (pixel.B * 0.131) * 1.2, 255);
                    Color sepia = Color.FromArgb((int)r,(int)g,(int)b);
                    processed.SetPixel(i,j,sepia);
                }
            }
            pictureBox2.Image = processed;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            loaded = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = loaded;
        }
    }
}
