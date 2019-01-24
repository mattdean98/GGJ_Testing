using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using GGJ_Testing.View;

namespace GGJ_Testing.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
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

        public MainViewModel()
        {
            //make instances of viewmodels
            GJVM = new GameJamViewModel(this);
        }

        #region ViewModels

        public GameJamViewModel GJVM { get; set; }

        #endregion

        #region Methods



        #endregion

        #region Properties



        #endregion
    }
}
