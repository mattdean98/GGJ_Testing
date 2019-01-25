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
            CanRun = true;

            if (!InitGPIO())
            {
                GPIOIndicator = "Unable to configure GPIO, please reboot the application.";
                CanRun = false;
                return;
            }
        }
        #endregion

        #region Properties
        private bool _canRun;
        public bool CanRun
        {
            get { return _canRun; }
            set { _canRun = value; OnPropertyChanged("CanRun"); }
        }

        private GpioController GPIO;

        private const int LED_PIN = 27;

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

        private bool _led;
        public bool LED
        {
            get { return _led; }
            set { _led = value; OnPropertyChanged("LED"); }
        }


        public GpioPin LEDPin;

        #endregion

        #region Methods

        private bool InitGPIO()
        {
            var gpio = GpioController.GetDefault();

            if (gpio == null)
            {
                GPIOIndicator = "There is no GPIO controller on this device.";
                return false;
            }
            else
            {
                GPIOIndicator = "Connected to default GPIO controller. :O ";
                GPIO = GpioController.GetDefault();
                LEDPin = GPIO.OpenPin(LED_PIN);
                LEDPin.SetDriveMode(GpioPinDriveMode.Output);
                return true;
            }
        }

        public void ToggleLED()
        {
            LED = !LED;
            if (LED)
            {
                LEDPin.Write(GpioPinValue.High);
            }
            else
            {
                LEDPin.Write(GpioPinValue.Low);
            }
        }

        #endregion

    }
}
