using GetOutfitApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GetOutfitApp.ViewModel
{
    internal class FeedViewModel:BaseViewModel
    {

        public FeedViewModel()
        {
            LogoutСommand = new Command(LogoutAsync);
        }

        public Command LogoutСommand { get; private set; }

        private async void LogoutAsync()
        {
            Preferences.Clear();
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        


    }
}
