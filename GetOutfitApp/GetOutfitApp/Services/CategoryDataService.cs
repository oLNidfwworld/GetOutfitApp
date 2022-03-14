using Firebase.Database;
using GetOutfitApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetOutfitApp.Services
{
    internal class CategoryDataService
    {
        FirebaseClient client;
        public CategoryDataService()
        {
            client = new FirebaseClient("https://getoutfitbase-default-rtdb.firebaseio.com/");
        }

        public async Task<List<CategoriesModel>> GetCategoriesAsync(){
            var categories = (await client.Child("Categories").OnceAsync<CategoriesModel >()).Select(f => new CategoriesModel
            {
                Id = f.Object.Id,
                Name= f.Object.Name,
                ImageUrl = f.Object.ImageUrl,


            }).ToList();

            return categories;
        }

    }
}
