using GetOutfitApp.Models;
using GetOutfitApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GetOutfitApp.ViewModel
{
    internal class CategoryViewModel:BaseViewModel
    {
        private CategoriesModel _SelectedCategory;
        public CategoriesModel SelectedCategory
        {
            get { return _SelectedCategory; }
            set {
                _SelectedCategory = value;
                OnPropertyChanged();
            }
        }


        private int _TotalItems;
        public int TotalItems
        {
            get { return _TotalItems; }
            set
            {
                _TotalItems = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<WearingModel> WearingByCategory { get; set; }

        public CategoryViewModel(CategoriesModel cat)
        {
            SelectedCategory = cat;
            WearingByCategory = new ObservableCollection<WearingModel>();
            GetItems(cat.Id);
        }   

        private async void GetItems(int id)
        {
            var data = await new WearingServicescs().GetWearingByCategoryAsync(id);
            WearingByCategory.Clear();
            foreach(var item in data)
            {
                WearingByCategory.Add(item);
            }
            TotalItems = WearingByCategory.Count;
        }
    }
}
