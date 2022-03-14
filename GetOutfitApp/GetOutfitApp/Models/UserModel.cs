using System;
using System.Collections.Generic;
using System.Text;

namespace GetOutfitApp.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Fullname { get; set; }    
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
