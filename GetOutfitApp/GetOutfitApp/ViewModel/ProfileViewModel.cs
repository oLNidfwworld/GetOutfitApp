using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
                return _Login;
            }
            set
            {
                _Login = value;
                OnPropertyChanged();
            }
        }

        private string _Fullname;
        public string Fullname
        {
            get
            {
                return this._Fullname;
            }
            set
            {
                _Fullname = value;
                OnPropertyChanged();
            }
        }

        private string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value; OnPropertyChanged();
            }
        }

        private string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
                OnPropertyChanged();
            }
        }

        
         #endregion
        public ProfileViewModel()
        {
            Fullname = Preferences.Get("FullName", "none");
            Login = Preferences.Get("Login", "none");
            Email = Preferences.Get("Email", "none");
        }

        public  void Refresh()
        {
            string s = Preferences.Get("Login", "none");
            string profiel = Login;
            if (s != profiel)
            {
                Fullname = null; Login = null; Email = null;
                Fullname = Preferences.Get("FullName", "none").ToString();
                Login = Preferences.Get("Login", "none").ToString();
                Email = Preferences.Get("Email", "none").ToString().ToString();
            }
        }
        
    }
}
