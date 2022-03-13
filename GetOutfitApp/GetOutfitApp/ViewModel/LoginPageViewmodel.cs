using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using GetOutfitApp.Services;
using GetOutfitApp.Views;
using Xamarin.Essentials;
using GetOutfitApp.Models;
using GetOutfitApp.Helpers;

namespace GetOutfitApp.ViewModel
{
    internal class LoginPageViewmodel:BaseViewModel
    {

        public LoginPageViewmodel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            GoToRegistrationCommand = new Command(async () => await GoToRegistrationAsync());
        }
        #region
        private string _Login;
        public string Login
        {
            get
            {
                return this._Login;
            }
            set
            {
                this._Login = value;
                OnPropertyChanged();
            }
        }

        private string _Fullname;
        public string Fullname
        {
            get
            {
                return this._Login;
            }
            set
            {
                this._Login = value;
                OnPropertyChanged();
            }
        }
             
        private string _Password;
        public string Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                this._Password = value;
                OnPropertyChanged();
            }
        }

        private bool _Isbusy;
        public bool Isbusy
        {
            get
            {
                return this._Isbusy;
            }
            set
            {
                this._Isbusy = value;
                OnPropertyChanged();
            }
        }

        private bool _Result;
        public bool Result
        {
            get
            {
                return this._Result;
            }
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region
        public Command LoginCommand { get; private set; }
        public Command GoToRegistrationCommand { get;private set; }
        #endregion

        #region
        private async Task LoginCommandAsync()
        {
            if (Isbusy)
                return;
            try {
                Isbusy = true;
                var usersrvs = new UserServices();
                Result = await usersrvs.LoginUser(Login, Password);
                if (Result)
                {
                    Preferences.Set("Login", Login);
                    var user = await usersrvs.GetUser(Login);
                    Preferences.Set("FullName", user.Object.Fullname);
                    
                    await Shell.Current.GoToAsync($"//{nameof(Feed)}");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Invalid Login or Password", "OK");
                }
            }
            catch(Exception e)
            {
                await Shell.Current.DisplayAlert("Error", e.Message, "Ok");
            }
            finally
            {
                Isbusy = false;
            }
        }
        private async Task GoToRegistrationAsync()
        {

            if (Isbusy)
                return;
            try
            {
                Isbusy = true;
                await Shell.Current.Navigation.PushModalAsync(new RegistrationPage());
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {
                Isbusy = false;
            }
        }
        #endregion

    }
}
