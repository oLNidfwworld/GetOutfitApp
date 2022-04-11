using GetOutfitApp.Models;
using GetOutfitApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetOutfitApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WishList : ContentPage
    {
        WishListViewModel wm;
        public WishList()
        {
            InitializeComponent();
            wm = new WishListViewModel();
            this.BindingContext = wm;
        }

        private void cw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
                return;
            else
                return;
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            wm.ItemsCart.Clear();
            wm.GetItems();
        }
    }
}