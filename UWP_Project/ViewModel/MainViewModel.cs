using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace UWP_Project.ViewModel
{
    public class MainViewModel  : INotifyPropertyChanged
    {
        #region mainviewmodel creation
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        #region properties
        private MainViewModel _mvm;
        #endregion 

        #region methods
        //constructor
        public MainViewModel()
        {
            _mvm = this;
            GJVM = new GameJamViewModel(this);

            //var test = BackgroundExecutionManager.RequestAccessAsync();
        }

        async public Task<bool> ShowConfirm(string message, string title="Confirm", string primaryBtn = "Yes", string secondaryBtn="No")
        {
            ContentDialog dialogbox = new ContentDialog
            {
                Title = title,
                Content = message,
                PrimaryButtonText = primaryBtn,
                SecondaryButtonText = secondaryBtn,
            };

            ContentDialogResult result = await dialogbox.ShowAsync();
            if(result == ContentDialogResult.Primary)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        async public void ShowAlert(string message, string title = "Alert", string btn = "Ok")
        {
            ContentDialog dialogbox = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = "Ok"
            };

            await dialogbox.ShowAsync();
        }
        #endregion

        #region viewmodel creation

        private GameJamViewModel _gJVM;
        public GameJamViewModel GJVM
        {
            get { return _gJVM; }
            set
            {
                _gJVM = value;
                OnPropertyChanged("GJVM");
            }
        }

        #endregion
    }
}
