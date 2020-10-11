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
            string img = "D:\\_University\\GitHub\\comp120-tinkering-graphics\\Tinkering_Graphics\\forestFires.jpg"; // call image - needs to be portable
            Bitmap bmp = new Bitmap(img); // creates bitmap variable to hold the pixel data for the graphical image "img" called above

            Bitmap reducedbmp = new Bitmap(bmp); 
            /* this makes a clone of the orginal bmp bitmap variable above, 
            it is named "reducedbmp" as this is the image that will be turning less orange 
            a clone is made so that, as the coder, we can easily ensure a visual difference has been made */
         
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

                    int modifiedR = Convert.ToInt32(r * .3);
                    int modifiedG = Convert.ToInt32(g * .4);
                    int modifiedB = Convert.ToInt32(b * .7);
                    /* above are the modifed variables used to edit the colour intensity in the picture
                    as the orange intensity in the picture needs to be decreased both red and green changed - blue a lot less*/

                    reducedbmp.SetPixel(x, y, Color.FromArgb(a, modifiedR, modifiedG, modifiedB));
                    // at each pixel, it will be set to the same rgb value but r and g are reduced
                    // this makes the forest fires look more "fake"

                }
            }

            // Here we set the the two picture boxs on the form to equal the actual BMP and modifiedBMP.
            pictureBox2.Image = bmp;
            pictureBox1.Image = reducedBMP;
        }
    }
}
