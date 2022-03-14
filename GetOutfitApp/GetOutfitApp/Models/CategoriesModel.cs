using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace GetOutfitApp.Models
{
    public class CategoriesModel
    {
        public int Id { get; set;}
        public string Name { get; set;}
        
        public string ImageUrl { get; set;}
    }
}
