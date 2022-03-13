using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace GetOutfitApp.ViewModel
{
    internal class ProfileViewModel:BaseViewModel
    {
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
        public ProfileViewModel()
        {
            Fullname = Preferences.Get("FullName", "none");
            Login = Preferences.Get("Login", "none");
        }
    }
}
