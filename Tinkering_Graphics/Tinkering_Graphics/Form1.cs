using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tinkering_Graphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string img = "D:\\_University\\GitHub\\comp120-tinkering-graphics\\Tinkering_Graphics\\forestFires.jpg";
            Bitmap bmp = new Bitmap(img);
            pictureBox1.Image = bmp;
        }
    }
}
