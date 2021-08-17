using ProiectLicenta_GUI.Core;
using ProiectLicenta_GUI.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProiectLicenta_GUI.MVVM.ViewModel
{
    /// <summary>
    /// The View model for the AddWatermark View
    /// </summary>
    public class AddWatermarkViewModel : ObservableObject
    {
        //Declare commands
        public RelayCommand AddWatermarkCommand { get; set; }

        //Properties
        private MainViewModel mainViewModel;

        private string watermarkKey;
        public string WatermarkKey
        {
            get { return watermarkKey; }
            set { watermarkKey = value; OnPropertyChanged(); }
        }

        private string exportFromat;
        public string ExportFromat
        {
            get { return exportFromat; }
            set { exportFromat = value; OnPropertyChanged(); }
        }

        //The constructor
        public AddWatermarkViewModel(MainViewModel mainViewModel)
        {
            //Init Properties
            this.mainViewModel = mainViewModel;

            //Init commands
            AddWatermarkCommand = new RelayCommand(obj => { AddWatermark(obj); });
        }

        //The commands functions
        private void AddWatermark(object sender)
        {
            if (WatermarkKey.Length < 1)
            {
                MessageBox.Show("Please enter a valid key.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                ImageAddWatermarkModel.AddWatermark(mainViewModel, WatermarkKey, ExportFromat);
                MessageBox.Show("The watermark was added to the photo.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        
        //Clear info after the view is no longer visible.
        public void ClearView()
        {

        }
    }
}
