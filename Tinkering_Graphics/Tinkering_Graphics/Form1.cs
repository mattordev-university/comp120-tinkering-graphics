using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// IMPORTANT LISENCE - MUST READ
#region LICENCE
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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // This code is just so we can show what the image looks like beforehand.
            Bitmap bmp = new Bitmap(Resource1.orangeSkyBridgeFires);
            pictureBox1.Image = bmp;
        }

        #region POSTERIZATION
        // this posterization function calls 3 more algorithim functions so that during the button press only one function used (for simplicity) 
        private void Posterization()
        {
            /* this makes a clone of the orginal bmp bitmap variable above, 
             * it is named "reducedbmp" as this is the image that will be 
             * turning fake. */
            Bitmap bmp = new Bitmap(Resource1.orangeSkyBridgeFires); 
            Bitmap reducedBMP = new Bitmap(bmp);


            /* turns the image greyscale to mute the orange values this makes 
             * easier editing later on without greyscale the image will turn 
             * out much pinker */
            greyscale(reducedBMP);


            /* this for loop is used to grab every pixel from the image
             * everything inside the foor loop will affect only the pixel
             * in the loop at the time */
            for (int y = 0; y < reducedBMP.Height; y++)
            {
                for (int x = 0; x < reducedBMP.Width; x++)
                {
                    /* this for loop grabs the new greyscaled pixels making
                     * a huge difference in the final outcome */
                    Color p = reducedBMP.GetPixel(x, y);

                    // variables to grab the argb values
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    // takes the variables above and modifies them to be used within the setpixel
                    int modifiedR = Convert.ToInt32(r * .5);
                    int modifiedG = Convert.ToInt32(g * .5);

                    // sets the pixel to the modified r and g values and a set b value
                    reducedBMP.SetPixel(x, y, Color.FromArgb(a, modifiedR, modifiedG, 50));
                }
            }


            /* the lessYellow function finds pixel that are within a 
             * particular threshold to the colour yellow and will 
             * increase the blue value within in them more */
            lessYellow(reducedBMP);


            // Here we set the the picture box on the form to equal the modifiedBMP.
            pictureBox1.Image = reducedBMP;

        }
        #endregion


        #region LESSYELLOW
        private static Bitmap lessYellow(Bitmap reducedBMP)
        {
            // for loop to grab each pixel in the image
            for (int y = 0; y < reducedBMP.Height; y++)
            {
                for (int x = 0; x < reducedBMP.Width; x++)
                {
                    /* creates variable p to hold the pixel 
                     * of particular iteration of the for loop */
                    Color p = reducedBMP.GetPixel(x, y);

                    // variables to grab the argb values
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    // if p is within threshold to another colour
                    if (ColourTolerance(p, Color.FromArgb(a, 255, 255, 0), 190) == true)
                    {
                        // then the pixel will stay the same expect for the blue value, this is increased to a set value
                        reducedBMP.SetPixel(x, y, Color.FromArgb(a, r, g, 75));
                    }
                }
            }
            // wil now return the changed reducedBMP
            return reducedBMP;
        }
        #endregion


        #region GREYSCALE
        private static Bitmap greyscale(Bitmap reducedBMP)
        {
            // for loop to grab each pixel in the image
            for (int y = 0; y < reducedBMP.Height; y++)
            {
                for (int x = 0; x < reducedBMP.Width; x++)
                {
                    /* creates variable p to hold the pixel 
                     * of particular iteration of the for loop */
                    Color p = reducedBMP.GetPixel(x, y);

                    // variables to grab the argb values
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    /* creates variable avg which takes the sum of all three 
                     * colour values (r, g and b) and divided by 3 */
                    int avg = ((r + g + b) / 3);

                    /* keeps a as the orginal a value but sets all 3 rgb colour 
                     * values to avg which makes it greyscale */
                    reducedBMP.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                }
            }

            return reducedBMP;
        }
        #endregion


        #region COLOURTOLERANCE
        private static bool ColourTolerance(Color pixel, Color color, int t)
        {
            /* algorithm - distance d = sum of(c0 - p0)^2 + (c1 - p2)^2 + (c2 - p2)^2)
             * sqaures the sum of c+p 0 to 2 */
            double d = (Math.Sqrt(color.R - pixel.R) + (color.G - pixel.G) + (color.B - pixel.B));

            /* if d, distance, is less than threshold return as true
             * if true is returned we know that our pixel is close to 
             * a colour we specified */
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


        private void EffectButton_Click(object sender, EventArgs e)
        {
            // calls posterization function to turn the image fake
            Posterization();
        }

        private void DescriptionBox_Enter(object sender, EventArgs e)
        {
            // This disables control on the text box so users can't change it
            ActiveControl = null;
        }

        #region IMAGESAVING
        void SavePicture()
        {
            // Here we create new version of the SaveFileDialogue method, and use some fancy syntax to add the params
            SaveFileDialog sfd = new SaveFileDialog()
            {
                InitialDirectory = "C:\\",              // Set the initial dir that the user will see
                Filter = "JPeg file (*.jpg)|*.jpg"      // jpg format
                + "|PNG file (*.png)|*.png"             // png format
                + "|TIFF file (*.tiff)|*.tiff",         // tiff format
                // Start on PNG, most common file type
                FilterIndex = 2,
                // Set a title for the sfd
                Title = "Save your file.."
            };


            // We want to test to make sure that there has actually been some result from the dialogue
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                /*This switch case uses the filter index to choose what image type will be saved.
                  More statemnets can be added for more file types, but in this program the 
                  chance of someone using anything than one of these 3 is slim.*/
                switch (sfd.FilterIndex)
                {
                    case 1:
                        pictureBox1.Image.Save(sfd.FileName, ImageFormat.Jpeg);     // Save jpg image
                        break;
                    case 2:
                        pictureBox1.Image.Save(sfd.FileName, ImageFormat.Png);      // Save png image
                        break;
                    case 3:
                        pictureBox1.Image.Save(sfd.FileName, ImageFormat.Tiff);     // Save tiff image
                        break;
                }
                //Tell the console that the image has saved
                Console.WriteLine("Image successfully saved");
            }
        }

        private void SaveImageButton_Click(object sender, EventArgs e)
        {
            // Run the SavePicture function
            SavePicture();
        }
#endregion
    }
}