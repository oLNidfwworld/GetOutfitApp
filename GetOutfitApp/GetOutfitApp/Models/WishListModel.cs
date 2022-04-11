using System;
using System.Collections.Generic;
using System.Text;

namespace GetOutfitApp.Models
{
    public class WishListModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WearingId { get; set; }
        public int Count { get; set; }

        public string Name { get; set; }
        public string Size { get; set; }
        public int CategoryId { get; set; }
        public int Watched { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
    }
}
