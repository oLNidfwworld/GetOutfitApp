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
        private ObservableCollection<WishListModel> _SelectedItems;
        public ObservableCollection<WishListModel> SelectedItem { get { return _SelectedItems; } set { _SelectedItems = value; OnPropertyChanged(); OnCollectionChanged(NotifyCollectionChangedAction.Reset);
            }}

        public ObservableCollection<WishListModel> ItemsCart { get; set; }

        public Command RemoveItemsCommand { get; private set; } // создать функцию

        public WishListViewModel()
        {
            ItemsCart = new ObservableCollection<WishListModel>();
            SelectedItem = new ObservableCollection<WishListModel>();
            SelectedItem.Clear();
            

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
