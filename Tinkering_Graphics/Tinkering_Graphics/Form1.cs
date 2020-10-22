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

#region LISENCE
/* LICENSE - MIT LICENSE 
 * Copyright (c) 2020 DAISY BAKER, MATTTHEW ROBERTS 
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.
 * 
 * The MIT lisence has been chosen as it is a short and simple permissive license 
 * meaning this work can be used commercially, this work can be modified as wanted
 * and the compiled code and/or source can be distributed as nessecary. Essentially
 * someone can do edit and distribute this code so long as this orginal copyright and
 * license is included in any copy of the software/source.
*/
#endregion

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
            Bitmap bmp = new Bitmap(Resource1.orangeSkyBridgeFires);
            pictureBox1.Image = bmp;
        }

        #region POSTERIZATION
        // this posterization function calls 3 more algorithim functions so that during the button press only one function used (for simplicity) 
        private void Posterization()
        {
            /* this makes a clone of the orginal bmp bitmap variable above, 
            it is named "reducedbmp" as this is the image that will be turning less orange 
            a clone is made so that, as the coder, we can easily ensure a visual difference has been made */
            Bitmap bmp = new Bitmap(Resource1.orangeSkyBridgeFires); // creates bitmap variable to hold the pixel data for the graphical image "img" called above
            Bitmap reducedBMP = new Bitmap(bmp);

            
            // turns the image greyscale to mute the orange values for easier editing later on
            // without greyscale the image will turn out much pinker
            greyscale(reducedBMP);
            

            for (int y = 0; y < reducedBMP.Height; y++)
            {
                for (int x = 0; x < reducedBMP.Width; x++)
                {
                    // this new for loop is important to grab the new greyscaled pixels
                    Color p = reducedBMP.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    int modifiedR = Convert.ToInt32(r * .5);
                    int modifiedG = Convert.ToInt32(g * .5);
                    int modifiedB = Convert.ToInt32(b * 0);

                    // use posterization for editing every pixel on img to a base level
                    reducedBMP.SetPixel(x, y, Color.FromArgb(a, modifiedR, modifiedG, 50));
                }
            }

            // with increase the B value of specific areas on the img
            lessYellow(reducedBMP);
            
            // Here we set the the picture box on the form to equal the modifiedBMP.
            pictureBox1.Image = reducedBMP;
            
        }
        #endregion

        #region LESSYELLOW
        private static Bitmap lessYellow(Bitmap reducedBMP)
        {
            for(int y = 0; y < reducedBMP.Height; y++)
            {
                for (int x = 0; x < reducedBMP.Width; x++)
                {
                    // this new for loop is important to grab the new greyscaled pixels
                    Color p = reducedBMP.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    if (ColourTolerance(p, Color.FromArgb(a, 255, 255, 0), 190) == true)
                    {
                        reducedBMP.SetPixel(x, y, Color.FromArgb(a, r, g, 75));
                    }
                   
                }
            }

            return reducedBMP;
        }
        #endregion


        #region GREYSCALE
        private static Bitmap greyscale(Bitmap reducedBMP)
        {
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

                    // sets img to greyscale
                    int avg = ((r + g + b) / 3);
                    reducedBMP.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                }
            }
            return reducedBMP;
        }
        #endregion


        #region COLOURDISTANCE
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

            if (sqrt < 255)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion


        #region COLOURTOLERANCE
        private static bool ColourTolerance(Color pixel, Color color, int t)
        {

            // algorithim distance d = sum of(c0 - p0)^2 + (c1 - p2)^2 + (c2 - p2)^2)
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
        #endregion

        #region LUMINANCE
        // currently not in use 
        private static double Luminance(Color color)
        {
            // L = sum of all colour channels (r g b) / divided by 3
            double l = ((color.R + color.G + color.B) / 3);
            return l;
        }
        #endregion


        #region INCREASELUMINANCE
        // attempted at a function to increase the brightness of an image to make the image look better
        // not in use
        private static Bitmap increaseLuminance(double l, Bitmap reducedBMP)
        {
            for (int y = 0; y < reducedBMP.Height; y++)
            {
                for (int x = 0; x < reducedBMP.Width; x++)
                {
                    Color p = reducedBMP.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    int modifiedR = Convert.ToInt32(r * 1.1);
                    int modifiedG = Convert.ToInt32(g * 1.1);
                    int modifiedB = Convert.ToInt32(b * 1.1);

                    if (modifiedR > 255)
                    {
                        modifiedR = 255;
                    }
                    if (modifiedG > 255)
                    {
                        modifiedG = 255;
                    }
                    if (modifiedB > 255)
                    {
                        modifiedB = 255;
                    }

                    reducedBMP.SetPixel(x, y, Color.FromArgb(a, modifiedR, modifiedG, modifiedB));
                }
            }

            return reducedBMP;
        }
        #endregion


        private void EffectButton_Click(object sender, EventArgs e)
        {
            // calls posterization function to turn the image fake
            Posterization();
        }

        private void DescriptionBox_Enter(object sender, EventArgs e)
        {
            ActiveControl = null;
        }
    }
}
