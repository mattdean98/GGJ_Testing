﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using UWP_Project.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_Project.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public readonly MainViewModel mvm;
        public MainPage()
        {
            this.InitializeComponent();
            mvm = App.mvm;


            if (mvm.GJVM.CanRun == false)
            {
                ToggleLED_Button.IsEnabled = false;
            }
        }

        async private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            var temp = await mvm.ShowConfirm("hello world!", "Confirm", "Ok", "No");
            mvm.GJVM.Str = temp.ToString();
        }

        private void PopupClick(object sender, RoutedEventArgs e)
        {
            mvm.ShowAlert("Testing message pop ups");
            mvm.GJVM.Str = "No Input";
        }

        private void ToggleLED_Click(object sender, RoutedEventArgs e)
        {
            mvm.GJVM.ToggleLED();
        }

        async private void Console_Click(object sender, RoutedEventArgs e)
        {
            var str = await mvm.ShowInputAsync("Enter a string");
            //mvm.ShowAlert("Entered input is: " + str);
        }
    }
}
