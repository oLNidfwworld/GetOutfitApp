using GetOutfitApp.Models;
using GetOutfitApp.Services;
using GetOutfitApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GetOutfitApp.ViewModel
{
    internal class FeedViewModel:BaseViewModel
    {

        public int _UserCartItemsCount;
        public int UserCartItemsCount
        {
            get { return _UserCartItemsCount; }
            set { _UserCartItemsCount = value;
                NotifyPropertyChanged(nameof(_UserCartItemsCount));
            }
        }

        public ObservableCollection<CategoriesModel> Categories { get; set; }
        public ObservableCollection<WearingModel> LatestWearings { get; set; }
        public ObservableCollection<WearingModel> TrendingItems { get; set; }

        public FeedViewModel()
        {
            LogoutСommand = new Command(LogoutAsync);

            Categories = new ObservableCollection<CategoriesModel>();  
            LatestWearings = new ObservableCollection<WearingModel>();
            TrendingItems = new ObservableCollection<WearingModel>();
            GetCategories();
            GetLatestItems();
            GetTrendingItems();
        }

        private async void GetTrendingItems()
        {
            var data = (await new WearingServicescs().GetTrendingWearingAsync());
            TrendingItems.Clear();
            foreach (var item in data)
            {
                TrendingItems.Add(item);
            }
        }

        public Command WishListCommand { get; private set; }
        public Command LogoutСommand { get; private set; }

        private async void GetLatestItems()
        {
            var data = (await new WearingServicescs().GetLatestWearingAsync());
            LatestWearings.Clear();
            foreach (var item in data)
            {
                LatestWearings.Add(item);
            }
        }

        private async void GetCategories()
        {
            var data = (await new CategoryDataService().GetCategoriesAsync());
            Categories.Clear();
            foreach(var item in data)
            {
                Categories.Add(item);  
            }
        }


        private async void LogoutAsync()
        {
            Preferences.Clear();
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        

    }
}
