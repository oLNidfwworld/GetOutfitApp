using GetOutfitApp.Models;
using GetOutfitApp.Services;
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
        List<object> list;
        public WishList()
        {
            InitializeComponent();
            wm = new WishListViewModel();
            this.BindingContext = wm;
            list= new List<object>();
        }


        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            wm.ItemsCart.Clear();
            wm.GetItems();
        }

        private  void cw_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
            list = e.CurrentSelection.ToList();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            foreach(var item in list)
            {
               await  new WishListServices().RemoveCartItemAsync((item as WishListModel).Id);
                wm.ItemsCart.Remove(item as WishListModel);
            }
            list.Clear();
            await Shell.Current.DisplayAlert("Успешно", "Товары убраны из корзины", "OK");
        }
    }
}