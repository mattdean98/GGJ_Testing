using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace UWP_Project.ViewModel
{
    public class GameJamViewModel : INotifyPropertyChanged
    {
        #region ViewModel Prepwork
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
        #endregion  //no need to edit anything in this region
        #region Constructor
        private readonly MainViewModel _mvm;
        public GameJamViewModel(MainViewModel mvm)
        {
            _mvm = mvm;
            Str = "No Input";
            GPIOIndicator = "Waiting to initialize GPIO...";

            InitGPIO();
        }
        #endregion

        #region Properties

        private string _str;
        public string Str
        {
            get { return _str; }
            set { _str = value; OnPropertyChanged("Str"); }
        }

        private string _gpioIndicator;
        public string GPIOIndicator
        {
            get { return _gpioIndicator; }
            set { _gpioIndicator = value; OnPropertyChanged("GPIOIndicator"); }
        }

        #endregion

        #region Methods

        private void InitGPIO()
        {
            var gpio = GpioController.GetDefault();

            if (gpio == null)
            {
                GPIOIndicator = "There is no GPIO controller on this device.";
            }
            else
            {
                GPIOIndicator = "Connected to default GPIO controller. :O ";
            }
        }

        #endregion

    }
}
