using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProiectLicenta_GUI.MVVM.Model
{
    /// <summary>
    /// The model for a file. To not be confused with the image model.
    /// </summary>
    public class FileModel
    {
        //Proprieties
        private string filePath;
        private string directoryPath;
        private string fileName;
        private string fileFormat;
        private SupportedFileFormats fileFormatEnum;

        //Getters and setters
        public string GetFilePath()
        {
            return filePath;
        }
        public string GetDirectoryPath()
        {
            return directoryPath;
        }
        public string GetFileName()
        {
            return fileName;
        }
        public string GetFileFormat()
        {
            return fileFormat;
        }

        public SupportedFileFormats GetFileFormatEnum()
        {
            return fileFormatEnum;
        }

        //Constructor
        public FileModel()
        {
            ClearFileModel(false);
        }

        //Important Functions
        public bool SetFilePath(string filePath)
        {
            this.filePath = filePath;
            if (GetEverythingFromFilePath(filePath))
            {
                return true;
            }
            ClearFileModel(false);
            return false;
        }

        //Split the full path into relevant pieces.
        private bool GetEverythingFromFilePath(string filePath)
        {
            ClearFileModel(true);

            bool FirstSlash = false;
            bool FirstPoint = false;
            for (int i = filePath.Length - 1; i >= 0; i--)
            {
                //Split the file path into directory path, file name, file format
                if (filePath[i] == '\\')
                {
                    FirstSlash = true;
                }
                if (filePath[i] == '.')
                {
                    FirstPoint = true;
                }

                if (FirstSlash == false)
                {
                    if (FirstPoint == false)
                    {
                        fileFormat += filePath[i];
                    }
                    else
                    {
                        fileName += filePath[i];
                    }
                }
                else
                {
                    directoryPath += filePath[i];
                }
            }

            //Reverse each string as the full path was run through from finish to start.
            fileFormat = ReverseString(fileFormat);
            fileName = ReverseString(fileName);
            fileName = fileName.Remove(fileName.Length - 1);
            directoryPath = ReverseString(directoryPath);

            //Check if everything is ok
            if (FirstSlash == false || FirstPoint == false)
            {
                MessageBox.Show("Please select a valid File Path.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            switch (fileFormat)
            {
                case "jpeg":
                    fileFormatEnum = SupportedFileFormats.JPEG;
                    break;
                case "jpg":
                    fileFormatEnum = SupportedFileFormats.JPG;
                    break;
                case "png":
                    fileFormatEnum = SupportedFileFormats.PNG;
                    break;
                case "bmp":
                    fileFormatEnum = SupportedFileFormats.BMP;
                    break;
                default:
                    MessageBox.Show("Please select a supported File Format.", "Image Marker", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
            }
            return true;
        }

        //Clear each string from the file model.
        public void ClearFileModel(bool exceptFilePath)
        {
            if (!exceptFilePath)
            {
                filePath = string.Empty;
            }
            directoryPath = string.Empty;
            fileName = string.Empty;
            fileFormat = string.Empty;
        }

        //Helper Functions
        public static string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string GetValidFileName(string fileName, string directoryPath, string addedText)
        {
            string newFileName = fileName;
            //Get all the names of the files already present in the directory
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            string allFileNames = string.Empty;
            foreach (var file in directoryInfo.GetFiles())
            {
                allFileNames += (file.Name + " ");
            }
            //Search for a possible name
            int fileNumber = 0;
            while (allFileNames.Contains(newFileName + addedText + fileNumber))
            {
                fileNumber += 1;
            }
            newFileName += (addedText + fileNumber);
            return newFileName;
        }
    }
}
