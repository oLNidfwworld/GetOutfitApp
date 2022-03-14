using System;
using System.Collections.Generic;
using System.Text;

namespace GetOutfitApp.Models
{
    public class WearingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public int CategoryId { get; set; }
        public int Watched { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
    }
}
