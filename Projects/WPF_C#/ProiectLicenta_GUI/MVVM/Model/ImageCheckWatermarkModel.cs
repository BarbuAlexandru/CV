using ProiectLicenta_GUI.MVVM.Model.Ciphers;
using ProiectLicenta_GUI.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectLicenta_GUI.MVVM.Model
{
    /// <summary>
    /// The class that manages the checking of image watermarks
    /// </summary>
    public class ImageCheckWatermarkModel
    {

        //The constructor
        public ImageCheckWatermarkModel()
        {

        }

        //The main Function for the checking of image watermark
        public static Bitmap CheckWatermark(Bitmap bmp, string key, string format)
        {
            if (format.ToUpper().Contains("PNG"))
            {
                return CheckWatermarkLossless(bmp, key);
            }
            if (format.ToUpper().Contains("BMP"))
            {
                return CheckWatermarkLossless(bmp, key);
            }
            if (format.ToUpper().Contains("JPEG"))
            {
                return CheckWatermarkLossy(bmp, key);
            }
            if (format.ToUpper().Contains("JPG"))
            {
                return CheckWatermarkLossy(bmp, key);
            }
            //If it reaches this code its an error.
            return bmp;
        }

        //Check watermark for Lossy image formats
        private static Bitmap CheckWatermarkLossy(Bitmap originalBmp, string keyDefault)
        {
            Bitmap bmp = (Bitmap)originalBmp.Clone();
            string key = PlayfairCipher.GetKeyForPlayfairFromTxt(keyDefault);

            //Important variables
            int sizeChangesMarker = bmp.Width/30;
            int differenceFactor = 40; // Its indirect proportional (to make the difference bigger, lower it)
            int pixelDifference = 3; // The Color difference between the original pixel and the duplicate
            float aspectRatio = bmp.Width / bmp.Height;
            int differenceVerticalLines = (int)(bmp.Width / (aspectRatio * differenceFactor));
            int differenceHorizontalLines = (int)(bmp.Height / differenceFactor);

            if (differenceVerticalLines < 20 * aspectRatio)
            {
                differenceVerticalLines = (int)(20 * aspectRatio);
            }

            if (differenceHorizontalLines < 20)
            {
                differenceHorizontalLines = 20;
            }

            //First check the watermark vertically
            int verticalKey = AutokeyCipher.GetLetterNumber(key[0]);
            int currentVerticalLinePos = 0 + ((differenceVerticalLines * verticalKey) / (key.Length + 1));

            while (currentVerticalLinePos + 1 < bmp.Width)
            {
                // check each vertical line
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color originalPixel = bmp.GetPixel(currentVerticalLinePos, j);
                    Color watermarkPixel = bmp.GetPixel(currentVerticalLinePos + 1, j);

                    //compare the two pixels
                    if (ArePixelsIdentical(originalPixel, watermarkPixel))
                    {
                        //If they are identical they were modified
                        bmp.SetPixel(currentVerticalLinePos + 1, j, Color.FromArgb(255, 255, 0, 0));
                    }
                    else
                    {
                        if (GetPixelsRGBDifference(originalPixel, watermarkPixel) > pixelDifference * 10)
                        {
                            //The difference between them is too big so they were modified
                            bmp.SetPixel(currentVerticalLinePos + 1, j, Color.FromArgb(255, 255, 0, 0));
                        }
                    }
                }

                //go to the next line
                currentVerticalLinePos += differenceVerticalLines;
            }
            
            //Second check the watermark horizontally
            int horizontalKey = AutokeyCipher.GetLetterNumber(key[1]);
            int currentHorizontalLinePos = 0 + ((differenceHorizontalLines * horizontalKey) / (key.Length + 1));

            while (currentHorizontalLinePos + 1 < bmp.Height)
            {
                //check each horizontal line
                for (int i = 0; i < bmp.Width; i++)
                {
                    Color originalPixel = bmp.GetPixel(i, currentHorizontalLinePos);
                    Color watermarkPixel = bmp.GetPixel(i, currentHorizontalLinePos+1);

                    //compare the two pixels
                    if (ArePixelsIdentical(originalPixel, watermarkPixel))
                    {
                        //If they are identical they were modified
                        bmp.SetPixel(i, currentHorizontalLinePos + 1, Color.FromArgb(255, 255, 0, 0));
                    }
                    else
                    {
                        if(GetPixelsRGBDifference(originalPixel, watermarkPixel) > pixelDifference * 10)
                        {
                            //The difference between them is too big so they were modified
                            bmp.SetPixel(i, currentHorizontalLinePos + 1, Color.FromArgb(255, 255, 0, 0));
                        }
                    }
                }

                //go to the next line
                currentHorizontalLinePos += differenceHorizontalLines;
            }

            Bitmap watermarkStatus = (Bitmap)bmp.Clone();
            Graphics graphics = Graphics.FromImage(watermarkStatus);
            SolidBrush brush = new SolidBrush(Color.FromArgb(255,255,0,0));
            //Go throwgh all pixels and see if there are some irregularities
            for (int i = 1; i < bmp.Width-1; i++)
            {
                for (int j = 1; j < bmp.Height-1; j++)
                {
                    if (IsPixelRedOnly(bmp.GetPixel(i,j)))
                    {
                        //if a pixel is only red, check its neighbours
                        if(IsPixelRedOnly(bmp.GetPixel(i+1, j)) || IsPixelRedOnly(bmp.GetPixel(i-1, j)) ||
                            IsPixelRedOnly(bmp.GetPixel(i, j+1)) || IsPixelRedOnly(bmp.GetPixel(i, j-1))){
                            //If the red pixels has some neighbours also red, it more likely the pixel was modify so
                            //make some other pixels
                            graphics.FillRectangle(brush, new Rectangle((i- sizeChangesMarker/2), (j- sizeChangesMarker/2), sizeChangesMarker, sizeChangesMarker));
                        }
                        else
                        {
                            //the pixel was just a JPEG compression irregularity so reverse it back
                            watermarkStatus.SetPixel(i, j, originalBmp.GetPixel(i, j));
                        }
                    }
                }
            }

            return watermarkStatus;
        }


        //Check watermark for Lossless image formats
        private static Bitmap CheckWatermarkLossless(Bitmap originalBmp, string keyDefault)
        {
            Bitmap bmp = (Bitmap)originalBmp.Clone();
            string key = PlayfairCipher.GetKeyForPlayfairFromTxt(keyDefault);
            int keyIterator = 0;
            int pixelX = 0, pixelY = 0;

            while (pixelX < bmp.Width)
            {
                char keyChar = key[keyIterator % key.Length];
                //Read the next character from the watermark
                char readChar = (char)(ImageTextReadingModel.GetByteFromPixels(bmp.GetPixel(pixelX,pixelY), bmp.GetPixel(pixelX, pixelY+1)));
                //Check to see if the chars are the same, if not, modify the pixels as RED to mark the modifications
                if(keyChar != readChar)
                {
                    bmp.SetPixel(pixelX, pixelY, Color.FromArgb(255, 255, 0, 0));
                    bmp.SetPixel(pixelX, pixelY+1, Color.FromArgb(255, 255, 0, 0));
                }
                //Combine the Autokey cipher and the Playfair key to make the watermark harder to detect
                //Get the next character from the key
                keyIterator = AutokeyCipher.GetLetterNumber(keyChar) + 1;

                //Go to the next valid set of pixels
                pixelY += 2;
                if (pixelY >= bmp.Height - 1)
                {
                    pixelX += 1;
                    pixelY = 0;
                }
            }
            return bmp;
        }

        //Helper Functions
        private static int GetPixelTotalRGB(Color pixel)
        {
            return pixel.R + pixel.G + pixel.B;
        }

        private static int GetPixelsRGBDifference(Color p1, Color p2)
        {
            int difference = (p1.R - p2.R) + (p1.G - p2.G) + (p1.B - p2.B);
            return difference;
        }
        
        private static bool ArePixelsIdentical(Color p1, Color p2)
        {
            if(p1.R==p2.R && p1.G==p2.G && p1.B == p2.B)
            {
                return true;
            }
            return false;
        }

        private static bool IsPixelRedOnly(Color pixel)
        {
            if(pixel.R==255 && pixel.G==0 && pixel.B==0)
            {
                return true;
            }
            return false;
        }
    }
}
