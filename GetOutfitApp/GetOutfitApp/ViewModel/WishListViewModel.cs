using GetOutfitApp.Models;
using GetOutfitApp.Services;
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
    class WishListViewModel:BaseViewModel
    {
        public ObservableCollection<WishListModel> ItemsCart { get; set; }

       


        public WishListViewModel()
        {
            ItemsCart = new ObservableCollection<WishListModel>();
            

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
