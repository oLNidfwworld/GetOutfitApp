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
        private ObservableCollection<WearingModel> _SelectedItems;
        public ObservableCollection<WearingModel> SelectedItem { get { return _SelectedItems; } set { _SelectedItems = value; OnPropertyChanged(); OnCollectionChanged(NotifyCollectionChangedAction.Reset);
            }}

        public ObservableCollection<WearingModel> ItemsCart { get; set; }

        public Command RemoveItemsCommand { get; private set; } // создать функцию

        public WishListViewModel()
        {
            ItemsCart = new ObservableCollection<WearingModel>();
            SelectedItem = new ObservableCollection<WearingModel>();
            GetItems();
            SelectedItem.Clear();
            

        }
        private  async  void GetItems()
        {
            //Изменить добавление
        }

        

    }
}
