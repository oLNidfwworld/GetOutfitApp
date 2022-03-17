using GetOutfitApp.Models;
using GetOutfitApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GetOutfitApp.ViewModel
{
    class WishListViewModel:BaseViewModel
    {

        public ObservableCollection<WearingModel> ItemsCart { get; set; }

        public WishListViewModel()
        {
            ItemsCart = new ObservableCollection<WearingModel>();
            GetItems();
            
        }
        private  async  void GetItems()
        {
            var l = await new WearingServicescs().GetWearingByIdAsync();
            ItemsCart.Clear();
            foreach(var items in l)
            {
                ItemsCart.Add(items);
            }
        }



    }
}
