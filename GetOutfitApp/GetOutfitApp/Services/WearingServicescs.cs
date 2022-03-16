using Firebase.Database;
using GetOutfitApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GetOutfitApp.Services
{
    internal class WearingServicescs
    {
        FirebaseClient client;

     
        public WearingServicescs()
        {
            client = new FirebaseClient("https://getoutfitbase-default-rtdb.firebaseio.com/");
        }

        public async Task<List<WearingModel>> GetWearingItemsAsync()
        {
            var products = (await client.Child("Wearing").OnceAsync<WearingModel>()).Select(f => new WearingModel
            {
                Id = f.Object.Id,
                CategoryId = f.Object.CategoryId,
                Name = f.Object.Name,
                Size = f.Object.Size,
                Watched = f.Object.Watched,
                ImageUrl = f.Object.ImageUrl,
                Price = f.Object.Price
            }).ToList();

            return products;
        }

        public async Task<ObservableCollection<WearingModel>> GetWearingByCategoryAsync(int Category)
        {
            var wearingByCategory = new ObservableCollection<WearingModel>();
            var items = (await GetWearingItemsAsync()).Where(p => p.CategoryId == Category).ToList();
            foreach(var item in items)
            {
                wearingByCategory.Add(item); 
            }
            return wearingByCategory;
        }

        public async Task<ObservableCollection<WearingModel>> GetTrendingWearingAsync()
        {
            var trendingWearings = new ObservableCollection<WearingModel>();
            var items = (await GetWearingItemsAsync()).OrderBy(f => f.Watched).Take(5);
            foreach (var item in items)
            {
                trendingWearings.Add(item);
            }
            return trendingWearings;
        }

        public async Task<ObservableCollection<WearingModel>> GetLatestWearingAsync()
        {
            var latestWearing = new ObservableCollection<WearingModel>();
            var items = (await GetWearingItemsAsync()).OrderByDescending(f => f.Id).Take(3);
            foreach (var item in items)
            {
                latestWearing.Add(item);
            }
            return latestWearing;
        }

        public async Task<ObservableCollection<WearingModel>> GetWearingByIdAsync()
        {
            var wearingById = new ObservableCollection<WearingModel>();
            wearingById.Clear();
            bool find = true;
            int wishlistitem = 0;
            var item = (await GetWearingItemsAsync());
            while (find)
                {
                    if (Preferences.ContainsKey($"WishListItem{wishlistitem}") != false)
                    {
                        
                        wearingById.Add(item.Where(p => p.Id == Preferences.Get($"WishListItem{wishlistitem}", 0)).FirstOrDefault());
                        wishlistitem++;
                    }
                    else
                    {
                        find = false;
                    }
                }
          
            return wearingById;
        }
    }
}
