using Firebase.Database;
using Firebase.Database.Query;
using GetOutfitApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace GetOutfitApp.Services
{
    internal class WishListServices
    {
        FirebaseClient client;


        public WishListServices()
        {
            client = new FirebaseClient("https://getoutfitbase-default-rtdb.firebaseio.com/");
        }

        public async Task<bool> IsItemInWishList(int userid, int wearingid)
        {
            var itemincart = (await client.Child("WishList").OnceAsync<WishListModel>()).Where(u => u.Object.UserId== userid && u.Object.WearingId == wearingid).FirstOrDefault();
            return (itemincart != null);
        }

        public async Task AddToCart(int userid,int wearingid)
        {

            if (await IsItemInWishList(userid,wearingid))
            {
                var itemincart = (await client.Child("WishList").OnceAsync<WishListModel>()).Where(u => u.Object.UserId == userid && u.Object.WearingId == wearingid).FirstOrDefault();
                itemincart.Object.Count += 1;
                await client.Child("WishList").Child(itemincart.Key).PutAsync(itemincart.Object);
            }
            else
            {
                await client.Child("WishList").PostAsync(new WishListModel()
                {
                    Id = new Random().Next(0, int.MaxValue),
                    UserId = userid,
                    WearingId = wearingid,
                    Count = 1,
                    CategoryId = (await client.Child("Wearing").OnceAsync<WearingModel>()).Where(i => i.Object.Id == wearingid).FirstOrDefault().Object.CategoryId,
                    ImageUrl = (await client.Child("Wearing").OnceAsync<WearingModel>()).Where(i => i.Object.Id == wearingid).FirstOrDefault().Object.ImageUrl,
                    Name = (await client.Child("Wearing").OnceAsync<WearingModel>()).Where(i => i.Object.Id == wearingid).FirstOrDefault().Object.Name,
                    Price = (await client.Child("Wearing").OnceAsync<WearingModel>()).Where(i => i.Object.Id == wearingid).FirstOrDefault().Object.Price,
                    Size = (await client.Child("Wearing").OnceAsync<WearingModel>()).Where(i => i.Object.Id == wearingid).FirstOrDefault().Object.Size,
                    Watched = (await client.Child("Wearing").OnceAsync<WearingModel>()).Where(i => i.Object.Id == wearingid).FirstOrDefault().Object.Watched
                }) ;
            }

        }

        public async Task<ObservableCollection<WishListModel>> GetWishListItemsAsync()
        {
            var itemslist = new ObservableCollection<WishListModel>();
            itemslist.Clear();
            var items = (await client.Child("WishList").OnceAsync<WishListModel>()).Where(i => i.Object.UserId == Preferences.Get("UserId", 0)).ToList() ;
            foreach(var item in items)
            {
                itemslist.Add(item.Object);
            }
            return itemslist;
        }
    }
}
