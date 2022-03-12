using GetOutfitApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetOutfitApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShellWLogin : Shell
    {
        public AppShellWLogin()
        {
            InitializeComponent();




            Routing.RegisterRoute(nameof(Feed), typeof(Feed));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(Outfit), typeof(Outfit));
            Routing.RegisterRoute(nameof(WishList), typeof(WishList));
            Routing.RegisterRoute(nameof(Profile), typeof(Profile));
        }
    }
}