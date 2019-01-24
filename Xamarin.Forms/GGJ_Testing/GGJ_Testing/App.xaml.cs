using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GGJ_Testing.View;
using GGJ_Testing.ViewModel;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GGJ_Testing
{
    public partial class App : Application
    {
        public static MainViewModel mvm;
        public App()
        {
            InitializeComponent();

            mvm = new MainViewModel();

            //start running the app
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    } 
}