using GetOutfitApp.Models;
using GetOutfitApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GetOutfitApp.ViewModel
{
    class WishListViewModel:BaseViewModel
    {
        private List<WearingModel> _SelectedItems;
        public List<WearingModel> SelectedItem { get { return _SelectedItems; } set { _SelectedItems = value; OnPropertyChanged(); } }

        public ObservableCollection<WearingModel> ItemsCart { get; set; }

        public Command RemoveItemsCommand { get; private set; }

        public WishListViewModel()
        {
            ItemsCart = new ObservableCollection<WearingModel>();
            SelectedItem = new List<WearingModel>();
            GetItems();

            RemoveItemsCommand = new Command(async () => await RemoveItemsAsync());

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

        private async Task RemoveItemsAsync()
        {
            var items = SelectedItem;
            try {

                foreach(var item in items)
                {
                    ItemsCart.Remove(item);
                }
                
            }
            catch (Exception e)
            {
                await Shell.Current.DisplayAlert("a", e.Message, "OK");
            }
            await Shell.Current.DisplayAlert("^^", "Успешно удалено", "0k");

        }

    }
}
