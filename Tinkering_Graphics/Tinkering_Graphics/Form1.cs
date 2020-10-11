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
            string img = "D:\\_University\\GitHub\\comp120-tinkering-graphics\\Tinkering_Graphics\\forestFires.jpg"; // Need to make this universal across systems
            Bitmap bmp = new Bitmap(img);
            Bitmap reducedBMP = new Bitmap(bmp);
            
            for (int y = 0; y < reducedBMP.Height; y++)
            {
                for (int x = 0; x < reducedBMP.Width; x++)
                {
                    // Create a color, and then asign each channel of that color an int for later use.
                    Color p = reducedBMP.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    int modifiedR = Convert.ToInt32(r * .55);
                    int modifiedG = Convert.ToInt32(g * .65);
                    int modifiedB = Convert.ToInt32(b * 0);

                    /* set the pixels of the "modified" bmp to the actual modified R, G and B values
                    Notice that we are not change the Alpha value here because it is not needed, so we just leave it as "a"*/
                    reducedBMP.SetPixel(x, y, Color.FromArgb(a, modifiedR, modifiedG, modifiedB));
                }
            }

            // Here we set the the two picture boxs on the form to equal the actual BMP and modifiedBMP.
            pictureBox2.Image = bmp;
            pictureBox1.Image = reducedBMP;
        }
    }
}
