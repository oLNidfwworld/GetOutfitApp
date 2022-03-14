using GetOutfitApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GetOutfitApp.ViewModel
{
    internal class RegistrationPageViewmodel:BaseViewModel
    {

        public RegistrationPageViewmodel()
        {
            RegCommand = new Command(async () => await RegCommandAsync());
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
                return this._Fullname;
            }
            set
            {
                this._Fullname = value;
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
        public bool Result{
            get
            {
                return this._Result;
            }
            set
            {
                this._Result = value;
                NotifyPropertyChanged(nameof(_Result));
            }
        }

        private string _Email;
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this._Email = value;
                NotifyPropertyChanged(nameof(_Email));
            }
        }

        #endregion

        #region
        public Command RegCommand { get; private set; }
        #endregion


        #region
        private async Task RegCommandAsync()
        {
            if (Isbusy)
                return;
            try
            {
                Isbusy = true;
                var userServices = new UserServices();
                Result = await userServices.RegisterUser(Login, Password, Email,Fullname);
                if (Result)
                {
                    await Shell.Current.DisplayAlert("Успешно", "Пользователь создан!", "OK");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Ошибка", "Пользователь уже существует", "OK");
                }
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
