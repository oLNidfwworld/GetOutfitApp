﻿using GetOutfitApp.Models;
using GetOutfitApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;

namespace GetOutfitApp.ViewModel
{
    class WishListViewModel:BaseViewModel
    {

        private ObservableCollection<WearingModel> _ItemsCart;
        public ObservableCollection<WearingModel> ItemsCart
        {
            get { return _ItemsCart; }
            set
            {
                _ItemsCart = value;
                OnPropertyChanged();
            }
        }

        private bool _Isbusy;
        public bool Isbusy
        {
            get
            {
                return this._Isbusy;
            }
            set
            {
                this._Isbusy = value;
                OnPropertyChanged();
            }
        }

        public WishListViewModel()
        {
            GetItems();
        }
        private  async  void GetItems()
        {
            var data = (await new WearingServicescs().GetWearingByIdAsync());
            ItemsCart.Clear();
            foreach (var item in data)
            {
                ItemsCart.Add(item);
            }

        }
    
    }
}
