using GetOutfitApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Linq;

namespace GetOutfitApp.Helpers
{
    internal class GetUserData
    {
        public FirebaseObject<UserModel> userData{get;set;}
        FirebaseClient client;

        public GetUserData(string login)
        {
            client = new FirebaseClient("https://getoutfitbase-default-rtdb.firebaseio.com/");
            this.GetUserDataAsync(login).Wait();
        }

        public async Task GetUserDataAsync(string login)
        {
            userData = (await client.Child("Users").OnceAsync<UserModel>()).Where(u => u.Object.Login == login).FirstOrDefault();


        }
    }
}
