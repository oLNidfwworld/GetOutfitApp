using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using GetOutfitApp.Models;
using System.Linq;
using Firebase.Database.Query;

namespace GetOutfitApp.Services
{
    internal  class UserServices
    {
        FirebaseClient client;
        public UserServices()
        {
            client = new FirebaseClient("https://getoutfitbase-default-rtdb.firebaseio.com/");
        }
        public async Task<bool> IsUserExists(string login)
        {
            var user = (await client.Child("Users").OnceAsync<UserModel>()).Where(u => u.Object.Login == login).FirstOrDefault();
            return (user != null);
        }
        public async Task<bool> RegisterUser(string login, string password, string email, string fullname)
        {
            if (await IsUserExists(login) == false)
            {
                await client.Child("Users").PostAsync(new UserModel()
                {
                    Id = new Random().Next(0, int.MaxValue),    
                    Login = login,
                    Password = password,
                    Email = email,
                    Fullname = fullname
                });
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<FirebaseObject<UserModel>> GetUser(string login)
        {
            if(await IsUserExists(login) != false)
            {
                var model = (await client.Child("Users").OnceAsync<UserModel>()).Where(u => u.Object.Login == login).FirstOrDefault();
                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> LoginUser(string login, string password)
        {
            var user = (await client.Child("Users").OnceAsync<UserModel>()).Where(u => u.Object.Login == login)
                .Where(u => u.Object.Password == password).FirstOrDefault();
            return (user != null);
        }
    }
}
