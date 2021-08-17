using Microsoft.Win32;
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
    /// The Main View Model behind the main Window
    /// </summary>
    public class MainViewModel : ObservableObject
    {
        //Define the views
        public HomeViewModel homeViewModel { get; set; }
        public AddWatermarkViewModel addWatermarkViewModel { get; set; }
        public CheckWatermarkViewModel checkWatermarkViewModel { get; set; }
        public AddTextViewModel addTextViewModel { get; set; }
        public ExtractTextViewModel extractTextViewModel { get; set; }

        //Define the commands
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand AddWatermarkViewCommand { get; set; }
        public RelayCommand CheckWatermarkViewCommand { get; set; }
        public RelayCommand AddTextViewCommand { get; set; }
        public RelayCommand ExtractTextViewCommand { get; set; }

        public RelayCommand LoadImageCommand { get; set; }
        public RelayCommand UnloadImageCommand { get; set; }

        //Define the currentView
        private object currentView;
        public object CurrentView
        {
            get { return currentView; }
            set { currentView = value; OnPropertyChanged(); }
        }

        //Define additional properties
        private static string defaultImagePath = "Resources/Images/NoImage.png";
        private string imagePath = defaultImagePath;
        //private string imagePath = "C:\\Users\\mirce\\Desktop\\test.bmp"; //!!!!!!!!JUST FOR TESTING PURPOSES
        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; OnPropertyChanged(); }
        }
        public FileModel fileModel;
        public ImageModel imageModel;

        //Main View Constructor
        public MainViewModel()
        {
            //Initialize the views
            homeViewModel = new HomeViewModel(this);
            addWatermarkViewModel = new AddWatermarkViewModel(this);
            checkWatermarkViewModel = new CheckWatermarkViewModel(this);
            addTextViewModel = new AddTextViewModel(this);
            extractTextViewModel = new ExtractTextViewModel(this);

            //Initialize Commands
            HomeViewCommand = new RelayCommand(obj => { CheckImageLoadAndGoToView(homeViewModel, true); });
            AddWatermarkViewCommand = new RelayCommand(obj => { CheckImageLoadAndGoToView(addWatermarkViewModel, false); });
            CheckWatermarkViewCommand = new RelayCommand(obj => { CheckImageLoadAndGoToView(checkWatermarkViewModel, false); });
            AddTextViewCommand = new RelayCommand(obj => { CheckImageLoadAndGoToView(addTextViewModel, false); });
            ExtractTextViewCommand = new RelayCommand(obj => { CheckImageLoadAndGoToView(extractTextViewModel, false); });

            LoadImageCommand = new RelayCommand(obj => { LoadImageBtnClick(obj); });
            UnloadImageCommand = new RelayCommand(obj => { UnloadImageBtnClick(obj); });

            //Assign initial View
            CurrentView = homeViewModel;

            //Init objects
            fileModel = new FileModel();
            imageModel = new ImageModel();

            //Default/Testing
        }

        //The actual Functions that commands execute
        private void CheckImageLoadAndGoToView(object goToView, bool skipImageCheck)
        {
            //do nothing if the current view is already the gotoView
            if (currentView.Equals(goToView))
                return;
            if (string.Equals(ImagePath, defaultImagePath) && !skipImageCheck)
            {
                MessageBox.Show("Please load an Image first.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                ClearViews();
                CurrentView = goToView;
            }
        }

        //Clear the remaining info in the views
        private void ClearViews()
        {
            addTextViewModel.ClearView();
            addWatermarkViewModel.ClearView();
            checkWatermarkViewModel.ClearView();
            extractTextViewModel.ClearView();
            homeViewModel.ClearView();
        }

        private void LoadImageBtnClick(object sender)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png; *.bmp; *.jpeg; *.jpg)|*.png; *.bmp; *.jpeg; *.jpg|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == true)
            {
                string tempFilePath = openFileDialog.FileName;
                //Load the path in the file model and check if it is ok
                if (fileModel.SetFilePath(tempFilePath))
                {
                    //the file is ok so load it into the UI
                    ImagePath = tempFilePath;
                    imageModel.LoadImageFromFilePath(ImagePath);
                }
            }
        }

        private void UnloadImageBtnClick(object sender)
        {
            if (string.Equals(ImagePath, defaultImagePath))
            {
                //there is no image loaded
                MessageBox.Show("There is no Image to unload.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                //clear the loaded image
                ImagePath = defaultImagePath;
                fileModel.ClearFileModel(false);
                imageModel.ClearImageModel();
                CurrentView = homeViewModel;
            }
        }
    }
}
