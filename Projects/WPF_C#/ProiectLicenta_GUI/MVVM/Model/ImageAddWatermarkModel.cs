using ProiectLicenta_GUI.MVVM.Model.Ciphers;
using ProiectLicenta_GUI.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProiectLicenta_GUI.MVVM.Model
{
    /// <summary>
    /// The class for the image add watermark object
    /// </summary>
    public class ImageAddWatermarkModel
    {

        //The constructor
        public ImageAddWatermarkModel()
        {

        }

        //The main addwatermark function
        public static void AddWatermark(MainViewModel mainViewModel, string key, string format)
        {
            if (format.Contains("PNG"))
            {
                AddWatermarkLossless(mainViewModel, key, "PNG");
                return;
            }
            if (format.Contains("BMP"))
            {
                AddWatermarkLossless(mainViewModel, key, "BMP");
                return;
            }
            if (format.Contains("JPEG"))
            {
                AddWatermarkLossy(mainViewModel, key, "JPEG");
                return;
            }
            if (format.Contains("JPG"))
            {
                AddWatermarkLossy(mainViewModel, key, "JPG");
                return;
            }
            //If the code reaches this part it is an ERROR
        }

        //The function to add a watermark to lossy image formats
        private static void AddWatermarkLossy(MainViewModel mainViewModel, string keyDefault, string format)
        {
            Bitmap bmp = (Bitmap)mainViewModel.imageModel.Bitmap.Clone();
            string key = PlayfairCipher.GetKeyForPlayfairFromTxt(keyDefault);

            //Important variables
            int differenceFactor = 40; // Its indirect proportional (to make the difference bigger, lower it)
            int pixelDifference = 3; // The Color difference between the original pixel and the duplicate
            float aspectRatio = bmp.Width / bmp.Height;
            int differenceVerticalLines = (int)(bmp.Width / (aspectRatio * differenceFactor));
            int differenceHorizontalLines = (int)(bmp.Height / differenceFactor);

            if(differenceVerticalLines < 20 * aspectRatio)
            {
                differenceVerticalLines = (int)(20 * aspectRatio);
            }

            if (differenceHorizontalLines < 20)
            {
                differenceHorizontalLines = 20;
            }

            //First add the watermark vertically
            int verticalKey = AutokeyCipher.GetLetterNumber(key[0]);
            int currentVerticalLinePos = 0 + ((differenceVerticalLines * verticalKey) / (key.Length+1));
            
            while(currentVerticalLinePos+1 < bmp.Width)
            {
                //modify the vertical line
                for(int j=0; j<bmp.Height; j++)
                {
                    Color newPixel = GetNewWatermarkPixel(bmp.GetPixel(currentVerticalLinePos, j), pixelDifference);
                    bmp.SetPixel(currentVerticalLinePos + 1, j, newPixel);
                }

                //go to the next line
                currentVerticalLinePos += differenceVerticalLines;
            }

            //Second add the watermark horizontally
            int horizontalKey = AutokeyCipher.GetLetterNumber(key[1]);
            int currentHorizontalLinePos = 0 + ((differenceHorizontalLines * horizontalKey) / (key.Length + 1));

            while (currentHorizontalLinePos + 1 < bmp.Height)
            {
                //modify the vertical line
                for (int i = 0; i < bmp.Width; i++)
                {
                    Color newPixel = GetNewWatermarkPixel(bmp.GetPixel(i, currentHorizontalLinePos), pixelDifference);
                    bmp.SetPixel(i, currentHorizontalLinePos+1, newPixel);
                }

                //go to the next line
                currentHorizontalLinePos += differenceHorizontalLines;
            }

            //Export and save the modified image
            string newFileName = FileModel.GetValidFileName(mainViewModel.fileModel.GetFileName(), mainViewModel.fileModel.GetDirectoryPath(), "_IM_WM_");
            ImageModel.SaveBitmap(bmp, mainViewModel.fileModel.GetDirectoryPath(), newFileName, format, 100L);
        }



        //The function to add a watermark to lossless image formats
        private static void AddWatermarkLossless(MainViewModel mainViewModel, string keyDefault, string format)
        {
            Bitmap bmp = (Bitmap)mainViewModel.imageModel.Bitmap.Clone();
            string key = PlayfairCipher.GetKeyForPlayfairFromTxt(keyDefault);
            int keyIterator = 0;
            int pixelX = 0, pixelY = 0;

            while (pixelX < bmp.Width)
            {
                char charToBeAdded = key[keyIterator % key.Length];
                //Add the current key character to the image
                bmp.SetPixel(pixelX, pixelY, ImageTextWritingModel.GetNewPixel1(bmp.GetPixel(pixelX, pixelY), (byte)(charToBeAdded)));
                bmp.SetPixel(pixelX, pixelY + 1, ImageTextWritingModel.GetNewPixel2(bmp.GetPixel(pixelX, pixelY + 1), (byte)(charToBeAdded)));
                //Combine the Autokey cipher and the Playfair key to make the watermark harder to detect
                keyIterator = AutokeyCipher.GetLetterNumber(charToBeAdded) + 1;

                //Go to the next valid set of pixels
                pixelY += 2;
                if (pixelY >= bmp.Height - 1)
                {
                    pixelX += 1;
                    pixelY = 0;
                }
            }

            //Export and save the modified image
            string newFileName = FileModel.GetValidFileName(mainViewModel.fileModel.GetFileName(), mainViewModel.fileModel.GetDirectoryPath(), "_IM_WM_");
            ImageModel.SaveBitmap(bmp, mainViewModel.fileModel.GetDirectoryPath(), newFileName, format, 100L);
        }

        //Helper Functions
        private static Color GetNewWatermarkPixel(Color pixel, int difference)
        {
            int newR = pixel.R - difference;
            if (newR < 0)
            {
                newR = 0;
            }
            int newG = pixel.G - difference;
            if (newG < 0)
            {
                newG = 0;
            }
            int newB = pixel.B - difference;
            if (newB < 0)
            {
                newB = 0;
            }
            return Color.FromArgb(pixel.A, newR, newG, newB);
        }
    }
}
