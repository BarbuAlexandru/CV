using ProiectLicenta_GUI.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectLicenta_GUI.MVVM.Model
{
    /// <summary>
    /// The class for image steganography
    /// </summary>
    public class ImageTextWritingModel
    {
        //The constructor
        public ImageTextWritingModel()
        {

        }

        //The main export image function
        public static void ExportImage(MainViewModel mainViewModel, string txt, string format)
        {
            if (format.Contains("PNG"))
            {
                ExportImageLossless(mainViewModel, txt, "PNG");
                return;
            }
            if (format.Contains("BMP"))
            {
                ExportImageLossless(mainViewModel, txt, "BMP");
                return;
            }
            if (format.Contains("JPEG"))
            {
                ExportImageLossy(mainViewModel, txt, "JPEG");
                return;
            }
            if (format.Contains("JPG"))
            {
                ExportImageLossy(mainViewModel, txt, "JPG");
                return;
            }
            //If it reaches this code its an error.
        }

        //the export function for LOSSY file formats
        private static void ExportImageLossy(MainViewModel mainViewModel, string txtDefault, string format)
        {
            string txt = string.Empty;
            if (txtDefault.Length > 100)
            {
                txt = txtDefault.Substring(0,100);
            }
            else
            {
                txt = txtDefault;
            }
            //create the image and get the byte array of it
            byte[] imageBytes = ImageModel.GetJpegByteArrayFromImage(mainViewModel.imageModel.Image, 100L);

            //Start from the end as it is less important but jump over 2 bytes as they
            //are the default jpeg ending of file and if modified will be added again
            int byteIterator = imageBytes.Length - 3;

            //Important variables
            int differenceModifiedBytes = 2;
            byte originalMask = 0b11111100;
            byte modifyingMask = 0b00000011;

            for(int i=-1; i<txt.Length; i++)
            {
                if (i == -1)
                {
                    //the first character that indicates that there is text hidden in this image (0b00000000)
                    imageBytes[byteIterator] = (byte)((imageBytes[byteIterator] & originalMask) | ((0b00000000 >> 6) & modifyingMask));
                    imageBytes[byteIterator - differenceModifiedBytes] = (byte)((imageBytes[byteIterator - differenceModifiedBytes] & originalMask) | ((0b00000000 >> 4) & modifyingMask));
                    imageBytes[byteIterator - differenceModifiedBytes*2] = (byte)((imageBytes[byteIterator - differenceModifiedBytes*2] & originalMask) | ((0b00000000 >> 2) & modifyingMask));
                    imageBytes[byteIterator - differenceModifiedBytes*3] = (byte)((imageBytes[byteIterator - differenceModifiedBytes*3] & originalMask) | (0b00000000 & modifyingMask));
                }
                else
                {
                    //the rest of characters
                    byteIterator -= differenceModifiedBytes * 4;
                    imageBytes[byteIterator] = (byte)((imageBytes[byteIterator] & originalMask) | (((byte)(txt[i]) >> 6) & modifyingMask));
                    imageBytes[byteIterator - differenceModifiedBytes] = (byte)((imageBytes[byteIterator - differenceModifiedBytes] & originalMask) | (((byte)(txt[i]) >> 4) & modifyingMask));
                    imageBytes[byteIterator - differenceModifiedBytes*2] = (byte)((imageBytes[byteIterator - differenceModifiedBytes*2] & originalMask) | (((byte)(txt[i]) >> 2) & modifyingMask));
                    imageBytes[byteIterator - differenceModifiedBytes*3] = (byte)((imageBytes[byteIterator - differenceModifiedBytes*3] & originalMask) | ((byte)(txt[i]) & modifyingMask));
                }

                //insert the end character at the end to indicate there is no more text (0b11111111)
                if ((i == txt.Length - 1) || (byteIterator <= imageBytes.Length/2))
                {
                    byteIterator -= differenceModifiedBytes * 4;
                    imageBytes[byteIterator] = (byte)((imageBytes[byteIterator] & originalMask) | ((0b11111111 >> 6) & modifyingMask));
                    imageBytes[byteIterator - differenceModifiedBytes] = (byte)((imageBytes[byteIterator - differenceModifiedBytes] & originalMask) | ((0b11111111 >> 4) & modifyingMask));
                    imageBytes[byteIterator - differenceModifiedBytes*2] = (byte)((imageBytes[byteIterator - differenceModifiedBytes*2] & originalMask) | ((0b11111111 >> 2) & modifyingMask));
                    imageBytes[byteIterator - differenceModifiedBytes*3] = (byte)((imageBytes[byteIterator - differenceModifiedBytes*3] & originalMask) | (0b11111111 & modifyingMask));
                    i = txt.Length;
                }
            }

            //Export and save the modified image
            string newFileName = FileModel.GetValidFileName(mainViewModel.fileModel.GetFileName(), mainViewModel.fileModel.GetDirectoryPath(), "_IM_Text_");
            ImageModel.SaveByteArray(imageBytes, mainViewModel.fileModel.GetDirectoryPath(), newFileName, format);
        }

        //The export function for LOSSLESS file formats
        private static void ExportImageLossless(MainViewModel mainViewModel, string txt, string format)
        {
            Bitmap bmp = (Bitmap)mainViewModel.imageModel.Bitmap.Clone();

            int pixelX = 0, pixelY = 0;
            for (int i=-1; i<txt.Length; i++)
            {
                if (i == -1)
                {
                    //First character that indicates the image contains some text (0b00000000)
                    bmp.SetPixel(pixelX, pixelY, GetNewPixel1(bmp.GetPixel(pixelX,pixelY), 0b00000000));
                    bmp.SetPixel(pixelX, pixelY+1, GetNewPixel2(bmp.GetPixel(pixelX, pixelY+1), 0b00000000));
                }
                else
                {
                    //The rest of characters
                    //Get the next valid set of pixels
                    pixelY += 2;
                    if(pixelY+1 >= bmp.Height)
                    {
                        pixelX += 1;
                        pixelY = 0;
                    }
                    bmp.SetPixel(pixelX, pixelY, GetNewPixel1(bmp.GetPixel(pixelX, pixelY), (byte)txt[i]));
                    bmp.SetPixel(pixelX, pixelY + 1, GetNewPixel2(bmp.GetPixel(pixelX, pixelY + 1), (byte)txt[i]));
                }

                //Insert the end character at the end to indicate there is no more text in the image
                if ((i== txt.Length - 1) || ((pixelX >= bmp.Width-1) && (pixelY >= bmp.Height-5)))
                {
                    //Get the next valid set of pixels
                    pixelY += 2;
                    if (pixelY + 1 >= bmp.Height)
                    {
                        pixelX += 1;
                        pixelY = 0;
                    }
                    bmp.SetPixel(pixelX, pixelY, GetNewPixel1(bmp.GetPixel(pixelX, pixelY), 0b11111111));
                    bmp.SetPixel(pixelX, pixelY + 1, GetNewPixel2(bmp.GetPixel(pixelX, pixelY + 1), 0b11111111));
                    //Break the for loop
                    i = txt.Length;
                }
            }
            //Export and save the modified image
            string newFileName = FileModel.GetValidFileName(mainViewModel.fileModel.GetFileName(), mainViewModel.fileModel.GetDirectoryPath(), "_IM_Text_");
            ImageModel.SaveBitmap(bmp, mainViewModel.fileModel.GetDirectoryPath(), newFileName, format, 100L);
        }


        //General Image Writing Data functions

        //The functions for LOSSLESS bit writting
        public static Color GetNewPixel1(Color pixel, byte b)
        {
            //Get the pixel information
            byte pixelA = pixel.A;
            byte pixelR = pixel.R;
            byte pixelG = pixel.G;
            byte pixelB = pixel.B;

            //Edit the pixels with only the FIRST 4 bytes of b
            byte pixelAnew = pixelA;
            byte pixelRnew = (byte)((pixelR & 0b11111100) | ((b >> 6) & 0b00000011));
            byte pixelGnew = pixelG;
            byte pixelBnew = (byte)((pixelB & 0b11111100) | ((b >> 4) & 0b00000011));

            return Color.FromArgb(pixelAnew, pixelRnew, pixelGnew, pixelBnew);
        }
        public static Color GetNewPixel2(Color pixel, byte b)
        {
            //Get the pixel information
            byte pixelA = pixel.A;
            byte pixelR = pixel.R;
            byte pixelG = pixel.G;
            byte pixelB = pixel.B;

            //Edit the pixels with only the LAST 4 bytes of b
            byte pixelAnew = pixelA;
            byte pixelRnew = (byte)((pixelR & 0b11111100) | ((b >> 2) & 0b00000011));
            byte pixelGnew = pixelG;
            byte pixelBnew = (byte)((pixelB & 0b11111100) | (b & 0b00000011));

            return Color.FromArgb(pixelAnew, pixelRnew, pixelGnew, pixelBnew);
        }
    }
}
