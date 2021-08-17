using ProiectLicenta_GUI.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectLicenta_GUI.MVVM.Model
{
    /// <summary>
    /// The class that manages the reading of secret text from an image
    /// </summary>
    public class ImageTextReadingModel
    {
        //The constructor
        public ImageTextReadingModel()
        {

        }

        //The main function for extracting the text from the image
        public static string ExtractTextFromImage(MainViewModel mainViewModel)
        {
            if (mainViewModel.fileModel.GetFileFormat().ToUpper().Contains("PNG"))
            {
                return ExtractTextFromImageLossless(mainViewModel);
            }
            if (mainViewModel.fileModel.GetFileFormat().ToUpper().Contains("BMP"))
            {
                return ExtractTextFromImageLossless(mainViewModel);
            }
            if (mainViewModel.fileModel.GetFileFormat().ToUpper().Contains("JPEG"))
            {
                return ExtractTextFromImageLossy(mainViewModel);
            }
            if (mainViewModel.fileModel.GetFileFormat().ToUpper().Contains("JPG"))
            {
                return ExtractTextFromImageLossy(mainViewModel);
            }
            //If it reaches this code its an error.
            return "ERROR - This image format is not supported.";
        }

        //The text extraction function for LOSSY file formats
        private static string ExtractTextFromImageLossy(MainViewModel mainViewModel)
        {
            byte[] imageBytes = ImageModel.ImageToByteArray(mainViewModel.imageModel.Image);
            string txt = string.Empty;

            //Start from the end as it is less important but jump over 2 bytes as they
            //are the default jpeg ending of file and if modified will be added again
            int byteIterator = imageBytes.Length - 3;
            //Important variables
            int differenceModifiedBytes = 2;

            //First character that indicates the image contains some text
            byte b = GetByteFromBytes(imageBytes[byteIterator], imageBytes[byteIterator - differenceModifiedBytes],
                                      imageBytes[byteIterator - differenceModifiedBytes*2], imageBytes[byteIterator - differenceModifiedBytes*3]);
            //Check to see if this is the byte that indicates the image has hidden text
            if (b != 0b00000000)
            {
                //if not return an error message
                return "ERROR - This image does not contain any hidden text.";
            }

            //Get all the characters hidden in the image
            char lastChar = 'C';
            while ((byte)(lastChar) != 0b11111111)
            {
                //Check to see if there are still pixels in the image
                if (byteIterator <= (imageBytes.Length / 2 - differenceModifiedBytes * 8))
                {
                    //if not return an error message
                    return "ERROR - The text hidden in the image doesn't have an end character.";
                }
                byteIterator -= differenceModifiedBytes * 4;
                lastChar = (char)(GetByteFromBytes(imageBytes[byteIterator], imageBytes[byteIterator - differenceModifiedBytes],
                                                   imageBytes[byteIterator - differenceModifiedBytes*2], imageBytes[byteIterator - differenceModifiedBytes*3]));
                txt += lastChar;
            }

            //Remove the end character and return the text
            return txt.Remove(txt.Length - 1);
        }

        //The text extraction function for LOSSLESS file formats
        private static string ExtractTextFromImageLossless(MainViewModel mainViewModel)
        {
            Bitmap bmp = (Bitmap)mainViewModel.imageModel.Bitmap.Clone();
            string txt = string.Empty;

            int pixelX = 0, pixelY = 0;

            //First character that indicates the image contains some text
            byte b = GetByteFromPixels(bmp.GetPixel(pixelX, pixelY), bmp.GetPixel(pixelX, pixelY + 1));
            //Check to see if this is the byte that indicates the image has hidden text
            if (b != 0b00000000)
            {
                //if not return an error message
                return "ERROR - This image does not contain any hidden text.";
            }

            char lastChar = 'C';
            while ((byte)(lastChar)!= 0b11111111)
            {
                //Check to see if there are still pixels in the image
                if (((pixelX >= bmp.Width - 1) && (pixelY >= bmp.Height - 3)))
                {
                    //if not return an error message
                    return "ERROR - The text hidden in the image doesn't have an end character.";
                }
                //Get the next valid set of pixels
                pixelY += 2;
                if (pixelY + 1 >= bmp.Height)
                {
                    pixelX += 1;
                    pixelY = 0;
                }

                lastChar = (char)(GetByteFromPixels(bmp.GetPixel(pixelX, pixelY), bmp.GetPixel(pixelX, pixelY + 1)));
                txt += lastChar;
            }

            //Remove the end character and return the text
            return txt.Remove(txt.Length-1);
        }
        
        
        //General Image Reading Data functions

        //The function that gets the info byte from 2 pixels
        public static byte GetByteFromPixels(Color pixel1, Color pixel2)
        {
            byte b = 0b00000000;
            b = (byte)(b | ((pixel1.R << 6) & (0b00000011 << 6)));
            b = (byte)(b | ((pixel1.B << 4) & (0b00000011 << 4)));
            b = (byte)(b | ((pixel2.R << 2) & (0b00000011 << 2)));
            b = (byte)(b | (pixel2.B & 0b00000011));
            return b;
        }

        //Extract the byte from a set of 4 bytes
        public static byte GetByteFromBytes(byte b1, byte b2, byte b3, byte b4)
        {
            byte b = 0b00000000;
            b = (byte)(b | ((b1 << 6) & (0b00000011 << 6)));
            b = (byte)(b | ((b2 << 4) & (0b00000011 << 4)));
            b = (byte)(b | ((b3 << 2) & (0b00000011 << 2)));
            b = (byte)(b | (b4 & 0b00000011));
            return b;
        }
    }
}
