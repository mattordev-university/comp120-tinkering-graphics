using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tinkering_Graphics
{
    public partial class Form1 : Form
    {
        //This is no longer required! For using images, please now use `Resource1.forestFires` instead (refer to examples in the code below if needed).
        //public string img = "G:\\GitRepos\\comp120-tinkering-graphics\\Tinkering_Graphics\\forestFires.jpg";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //This is just so we can show what the image looks like beforehand.
            Bitmap bmp = new Bitmap(Resource1.forestFires);
            pictureBox1.Image = bmp;
        }

        private void Posterization()
        {
            Bitmap bmp = new Bitmap(Resource1.forestFires); // creates bitmap variable to hold the pixel data for the graphical image "img" called above

            Bitmap reducedBMP = new Bitmap(bmp);
            
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

                    // reducedBMP.SetPixel(x, y, Color.FromArgb(a, r, g, 150));

                    int avg = ((r + g + b) / 3);
                    reducedBMP.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));

                    reducedBMP.SetPixel(x, y, Color.FromArgb(a, r, g, 150));

                    int modifiedR = Convert.ToInt32(r * .7);
                    int modifiedG = Convert.ToInt32(g * .8);
                    int modifiedB = Convert.ToInt32(b * 0);
                    /* above are the modifed variables used to edit the colour intensity in the picture
                    as the orange intensity in the picture needs to be decreased, both red and green changed - blue a lot less*/


                    /*
                    if (Luminance(p) > 0 && Luminance(p) < 80)
                    {
                        reducedBMP.SetPixel(x, y, Color.FromArgb(a, avg, avg, 200));
                        // at each pixel, it will be set to the same rgb value but r and g are reduced
                        // this makes the forest fires look more "fake"
                    }
                    else if (Luminance(p) > 80)
                    {
                        reducedBMP.SetPixel(x, y, Color.FromArgb(a, avg, avg, 200));
                    }
                    */
                    

                    /*
                    int modifiedR = Convert.ToInt32(r * .3);
                    int modifiedG = Convert.ToInt32(g * .4);
                    int modifiedB = Convert.ToInt32(b * .7);
                    /* above are the modifed variables used to edit the colour intensity in the picture
                    as the orange intensity in the picture needs to be decreased, both red and green changed - blue a lot less*/
                    /*
                    reducedBMP.SetPixel(x, y, Color.FromArgb(a, modifiedR, modifiedG, modifiedB));
                    // at each pixel, it will be set to the same rgb value but r and g are reduced
                    // this makes the forest fires look more "fake"
                    */

                }
            }

            // Here we set the the picture box on the form to equal the modifiedBMP.
            pictureBox1.Image = reducedBMP;
            
        }

        private static bool ColourDistance(Color pColour, Color imgColour)
        {
            int redDiff;
            int greenDiff;
            int BlueDiff;
            double sqrt;

            redDiff = pColour.R - imgColour.R;
            greenDiff = pColour.G - imgColour.G;
            BlueDiff = pColour.B - imgColour.B;

            sqrt = Math.Sqrt((redDiff * redDiff) + (greenDiff * greenDiff) + (BlueDiff * BlueDiff));

            // Console.WriteLine(sqrt);
            // return sqrt;

            if (sqrt < 255)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int Luminance(Color color)
        {
            // colour = (r, g, b)
            // must be 0 =< colour =< 255

            // L = sum of all colour channels (r g b) / divided by 3
            int l = ((color.R + color.G + color.B) / 3);
            return l;
        }

        private bool ColourTolerance(Color color, Color pixel, int t)
        {

            // distance d = sum of(c0 - p0)^2 + (c1 - p2)^2 + (c2 - p2)^2)
            double d = (Math.Sqrt(color.R - pixel.R) + (color.G - pixel.G) + (color.B - pixel.B));

            if (d < t)
            {
                return true;

            }
            else
            {
                return false;
            }

        }


        private void EffectButton_Click(object sender, EventArgs e)
        {
            // Do the thing to make fires go brrr
            Posterization();
        }

        private void DescriptionBox_Enter(object sender, EventArgs e)
        {
            ActiveControl = null;
        }
    }
}
