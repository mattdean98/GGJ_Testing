using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows

namespace GGJ_Testing.ViewModel
{
    public class GameJamViewModel : INotifyPropertyChanged
    {
        #region ViewModelCreation
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

        private readonly MainViewModel mvm;
        public GameJamViewModel(MainViewModel mainViewModel)
        {
            mvm = mainViewModel;
        }

        #region Methods



        #endregion

        #region Properties



        #endregion
    }
}
