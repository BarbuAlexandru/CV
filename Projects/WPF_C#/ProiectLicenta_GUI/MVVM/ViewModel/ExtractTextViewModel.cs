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
    public class ExtractTextViewModel : ObservableObject
    {
        //Declare commands
        public RelayCommand DecryptTextCommand { get; set; }
        public RelayCommand ExtractTextCommand { get; set; }

        //Properties
        private MainViewModel mainViewModel;

        private string extractedText = string.Empty;
        public string ExtractedText
        {
            get { return extractedText; }
            set { extractedText = value; OnPropertyChanged(); }
        }

        private string decryptionKey;
        public string DecryptionKey
        {
            get { return decryptionKey; }
            set { decryptionKey = value; OnPropertyChanged(); }
        }

        private string selectedCipher;
        public string SelectedCipher
        {
            get { return selectedCipher; }
            set { selectedCipher = value; OnPropertyChanged(); }
        }

        private string decryptedText = string.Empty;
        public string DecryptedText
        {
            get { return decryptedText; }
            set { decryptedText = value; OnPropertyChanged(); }
        }


        //The constructor
        public ExtractTextViewModel(MainViewModel mainViewModel)
        {
            //Init commands
            DecryptTextCommand = new RelayCommand(obj => { DecryptText(obj); });
            ExtractTextCommand = new RelayCommand(obj => { ExtractText(obj); });

            this.mainViewModel = mainViewModel;
        }

        //The commands functions
        public void DecryptText(object sender)
        {
            DecryptedText = string.Empty;
            //check if there is some plain text.
            if (ExtractedText.Length < 1)
            {
                MessageBox.Show("Please extract some text from the image first.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (SelectedCipher.Contains("None"))
            {
                //The text should not be encrypted in any way
                MessageBox.Show("The decryption cipher is set to none.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                //check if there is a valid key
                if (DecryptionKey.Length < 1)
                {
                    MessageBox.Show("Please enter a valid key.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            DecryptedText = EncryptDecryptModel.DecryptText(ExtractedText, DecryptionKey, SelectedCipher);
        }

        public void ExtractText(object sender)
        {
            ExtractedText = string.Empty;
            DecryptedText = string.Empty;
            string extrTxt = ImageTextReadingModel.ExtractTextFromImage(mainViewModel); 
            if (extrTxt.ToUpper().Contains("ERROR"))
            {
                MessageBox.Show(extrTxt, "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                ExtractedText = extrTxt;
                MessageBox.Show("The text was extracted from the image.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        //Clear info after the view is no longer visible.
        public void ClearView()
        {
            ExtractedText = string.Empty;
            DecryptedText = string.Empty;
        }
    }
}
