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
    public class AddTextViewModel : ObservableObject
    {
        //Declare commands
        public RelayCommand EncryptTextCommand { get; set; }
        public RelayCommand ExportImageCommand { get; set; }


        //Declare properties
        private MainViewModel mainViewModel;

        private string plainText;
        public string PlainText
        {
            get { return plainText; }
            set { plainText = value; OnPropertyChanged(); }
        }

        private string encryptionKey;
        public string EncryptionKey
        {
            get { return encryptionKey; }
            set { encryptionKey = value; OnPropertyChanged(); }
        }

        private string selectedCipher;
        public string SelectedCipher
        {
            get { return selectedCipher; }
            set { selectedCipher = value; OnPropertyChanged(); }
        }

        private string encryptedText = string.Empty;
        public string EncryptedText
        {
            get { return encryptedText; }
            set { encryptedText = value; OnPropertyChanged(); }
        }

        private string exportFromat;
        public string ExportFromat
        {
            get { return exportFromat; }
            set { exportFromat = value; OnPropertyChanged(); }
        }


        //The constructor
        public AddTextViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;

            //Init Commands
            EncryptTextCommand = new RelayCommand(obj => { EncryptText(obj); });
            ExportImageCommand = new RelayCommand(obj => { ExportImage(obj); });
        }

        //Command functions
        public void EncryptText(object sender)
        {
            EncryptedText = string.Empty;
            //check if there is some plain text.
            if (PlainText.Length < 1)
            {
                MessageBox.Show("Please enter some plain text first.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (SelectedCipher.Contains("None"))
            {
                //The text should not be encrypted in any way
                MessageBox.Show("The encryption cipher is set to none.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                //check if there is a valid key
                if (EncryptionKey.Length < 1)
                {
                    MessageBox.Show("Please enter a valid key.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            EncryptedText = EncryptDecryptModel.EncryptText(PlainText, EncryptionKey, SelectedCipher);
        }

        public void ExportImage(object sender)
        {
            string txtToAddToImage = string.Empty;
            if (SelectedCipher.Contains("None"))
            {
                //the text should not be encrypted and just be added to the photo
                if (PlainText.Length < 1)
                {
                    MessageBox.Show("Please enter some plain text.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                txtToAddToImage = PlainText;
            }
            else
            {
                //the text should not be encrypted and just be added to the photo
                if (EncryptedText.Length < 1)
                {
                    MessageBox.Show("Please encrypt some text first.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                txtToAddToImage = EncryptedText;
            }
            //Add the txt to the image
            ImageTextWritingModel.ExportImage(mainViewModel, txtToAddToImage, ExportFromat);
            MessageBox.Show("The text was added to the image and exported.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //Clear info after the view is no longer visible.
        public void ClearView()
        {
            EncryptedText = string.Empty;
        }
    }
}
