using ProiectLicenta_GUI.Core;
using ProiectLicenta_GUI.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProiectLicenta_GUI.MVVM.ViewModel
{
    public class CheckWatermarkViewModel : ObservableObject
    {
        // Declare Commands
        public RelayCommand CheckWatermarkCommand { get; set; }
        public RelayCommand ExportWatermarkCommand { get; set; }

        //Properties
        private MainViewModel mainViewModel;

        private ImageSource watermarkStatusSource=null;
        public ImageSource WatermarkStatusSource
        {
            get { return watermarkStatusSource; }
            set { watermarkStatusSource = value; OnPropertyChanged(); }
        }

        private string watermarkKey;
        public string WatermarkKey
        {
            get { return watermarkKey; }
            set { watermarkKey = value; OnPropertyChanged(); }
        }

        private Bitmap watermarkStatusBMP;
        public Bitmap WatermarkStatusBMP
        {
            get { return watermarkStatusBMP; }
            set { watermarkStatusBMP = value; OnPropertyChanged(); }
        }

        //The Constructor
        public CheckWatermarkViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;

            //Init Commands
            CheckWatermarkCommand = new RelayCommand(obj => { CheckWatermark(obj); });
            ExportWatermarkCommand = new RelayCommand(obj => { ExportWatermark(obj); });

        }

        //Command functions
        private void CheckWatermark(object sender)
        {
            if (WatermarkKey.Length < 1)
            {
                MessageBox.Show("Please enter a valid key.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                WatermarkStatusSource = GetImageSource(mainViewModel.fileModel.GetFilePath());
                MessageBox.Show("The watermark status was checked.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ExportWatermark(object sender)
        {
            if(WatermarkStatusSource == null)
            {
                MessageBox.Show("Please check the watermark first.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                //Export watermark status as a separate image
                ImageModel.SaveBitmap(WatermarkStatusBMP, mainViewModel.fileModel.GetDirectoryPath(),
                    FileModel.GetValidFileName(mainViewModel.fileModel.GetFileName(), mainViewModel.fileModel.GetDirectoryPath(),"_IM_WMS_"),"BMP", 100L);
                MessageBox.Show("The watermark status was exported.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        //Helper Functions
        private ImageSource GetImageSource(string filePath)
        {
            WatermarkStatusBMP = ImageCheckWatermarkModel.CheckWatermark(mainViewModel.imageModel.Bitmap, WatermarkKey, mainViewModel.fileModel.GetFileFormat());
            byte[] buffer = ImageModel.ImageToByteArray(WatermarkStatusBMP);
            MemoryStream memoryStream = new MemoryStream(buffer);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.DecodePixelWidth = 360;
            bitmap.StreamSource = memoryStream;
            bitmap.EndInit();
            bitmap.Freeze();

            return bitmap;
        }

        //Clear info after the view is no longer visible.
        public void ClearView()
        {
            WatermarkStatusSource = null;
            WatermarkStatusBMP = null;
        }
    }
}
