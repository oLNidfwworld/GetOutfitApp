using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GetOutfitApp;
using GetOutfitApp.Views;
using Xamarin.Essentials;

namespace GetOutfitApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (Preferences.ContainsKey("Login"))
                MainPage = new AppShellWLogin();
            else

                MainPage = new AppShell();
        }   

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
