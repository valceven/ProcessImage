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
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImageProcessor imageProcessor = new ImageProcessor();
            imageProcessor.FormClosed += (s, args) => this.Show();
            imageProcessor.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Activity2 activity2 = new Activity2();
            activity2.FormClosed += (s, args) => this.Show();
            activity2.Show();
            this.Hide();
        }
    }
}
