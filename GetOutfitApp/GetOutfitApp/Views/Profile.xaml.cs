﻿using GetOutfitApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetOutfitApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        ProfileViewModel vm;
        public Profile()
        {
            InitializeComponent();
            vm= new ProfileViewModel();
            this.BindingContext = vm;
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            if(Preferences.Get("Login","none") != vm.Login)
            {
                vm.Fullname = Preferences.Get("FullName", "none");
                vm.Login = Preferences.Get("Login", "none");
                vm.Email = Preferences.Get("Email", "none");
            }
        }
    }
}