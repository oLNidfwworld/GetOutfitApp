using GetOutfitApp.Models;
using GetOutfitApp.Services;
using GetOutfitApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GetOutfitApp.ViewModel
{
    public class WishListViewModel:BaseViewModel
    {
        public ObservableCollection<WishListModel> ItemsCart { get; set; }

        public Command GoToConfirmCommand {  get; set; }


        public WishListViewModel()
        {
            ItemsCart = new ObservableCollection<WishListModel>();

            GoToConfirmCommand = new Command(async () => await GoToConfirmAsync());
        }

        private async Task GoToConfirmAsync()
        {
            await Shell.Current.Navigation.PushModalAsync(new ConfirmPurchase(ItemsCart));
        }

        public  async  void GetItems()
        {
            var list = await new WishListServices().GetWishListItemsAsync();
            foreach(var item in list)
            {
                
                ItemsCart.Add(item);
            }

        }


    }
}
