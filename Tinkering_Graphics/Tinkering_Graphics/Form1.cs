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
            Bitmap reducedbmp = new Bitmap(bmp);

            
            for (int y = 0; y < reducedbmp.Height; y++)
            {
                for (int x = 0; x < reducedbmp.Width; x++)
                {
                    Color p = reducedbmp.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    int Modifiedr = Convert.ToInt32(r * .55);
                    int Modifiedg = Convert.ToInt32(g * .65);
                    int Modifiedb = Convert.ToInt32(b * 0);

                    reducedbmp.SetPixel(x, y, Color.FromArgb(a, Modifiedr, Modifiedg, Modifiedb));
                }
            }

            pictureBox2.Image = bmp;
            pictureBox1.Image = reducedbmp;
        }
    }
}
