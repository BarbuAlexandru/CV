using ProiectLicenta_GUI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectLicenta_GUI.MVVM.ViewModel
{
    public class HomeViewModel : ObservableObject
    {
        private MainViewModel mainViewModel;

        public string TEST
        {
            get { return mainViewModel.ImagePath; }
        }

        public HomeViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }


        //Clear info after the view is no longer visible.
        public void ClearView()
        {

        }
    }
}
