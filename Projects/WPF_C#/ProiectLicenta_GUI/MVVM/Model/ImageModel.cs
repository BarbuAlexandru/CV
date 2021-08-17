using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProiectLicenta_GUI.MVVM.Model
{
    /// <summary>
    /// The main model for an image.
    /// </summary>
    public class ImageModel
    {
        private Image image;
        private Bitmap bitmap;

        public Bitmap Bitmap
        {
            get { return bitmap; }
            set { bitmap = value;}
        }

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        public ImageModel()
        {
            ClearImageModel();
        }

        //Important Functions
        public void ClearImageModel()
        {
            image = null;
            bitmap = null;
        }

        public void LoadImageFromFilePath(string filePath)
        {
            image = Image.FromFile(filePath);
            bitmap = new Bitmap(image);
        }

        //save a bitmap image as a specific format
        public static void SaveBitmap(Bitmap bitmapToSave, string directoryToSave, string fileName, string format, long quality)
        {
            switch (format)
            {
                case "PNG":
                    bitmapToSave.Save(directoryToSave + fileName + ".png", ImageFormat.Png);
                    break;
                case "JPEG":
                case "JPG":
                    ImageCodecInfo jpegEncoder = GetEncoder(ImageFormat.Jpeg);
                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    if (format.Equals("JPEG"))
                    {
                        bitmapToSave.Save(directoryToSave + fileName + ".jpeg", jpegEncoder, myEncoderParameters);
                    }
                    else
                    {
                        bitmapToSave.Save(directoryToSave + fileName + ".jpg", jpegEncoder, myEncoderParameters);
                    }
                    break;
                case "BMP":
                    bitmapToSave.Save(directoryToSave + fileName + ".bmp", ImageFormat.Bmp);
                    break;
                default:
                    bitmapToSave.Save(directoryToSave + fileName + ".bmp", ImageFormat.Bmp);
                    break;
            }
        }

        //Save a byte array as a image of specific format
        public static void SaveByteArray(byte[] byteArrayToSave, string directoryToSave, string fileName, string format)
        {
            switch (format)
            {
                case "PNG":
                    File.WriteAllBytes(directoryToSave + fileName + ".png", byteArrayToSave);
                    break;
                case "JPEG":
                    File.WriteAllBytes(directoryToSave + fileName + ".jpeg", byteArrayToSave);
                    break;
                case "JPG":
                    File.WriteAllBytes(directoryToSave + fileName + ".jpg", byteArrayToSave);
                    break;
                case "BMP":
                    File.WriteAllBytes(directoryToSave + fileName + ".bmp", byteArrayToSave);
                    break;
                default:
                    File.WriteAllBytes(directoryToSave + fileName + ".bmp", byteArrayToSave);
                    break;
            }
        }
        
        //Helper Functions
        public static Image ByteArrayToImage(byte[] byteArrayToConvert)
        {
            MemoryStream memoryStream = new MemoryStream(byteArrayToConvert);
            return Image.FromStream(memoryStream);
        }

        public static byte[] ImageToByteArray(Image imageToConvert)
        {
            MemoryStream memoryStream = new MemoryStream();
            imageToConvert.Save(memoryStream, ImageFormat.Jpeg);
            return memoryStream.ToArray();
        }

        public static byte[] GetJpegByteArrayFromImage(Image img, long quality)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ImageCodecInfo jpegEncoder = GetEncoder(ImageFormat.Jpeg);
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                img.Save(ms, jpegEncoder, myEncoderParameters);
                return ms.ToArray();
            }
        }

        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}
