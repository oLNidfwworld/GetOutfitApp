using GetOutfitApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace GetOutfitApp.ViewModel
{
    internal class WearingDetailViewModel:BaseViewModel
    {

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


        public WearingDetailViewModel(WearingModel w)
        {
            _SelectedWearing = w;
            AddToWishListCommand = new Command(AddToWishListAsync);
        }

        private WearingModel _SelectedWearing;
        public WearingModel SelectedWearing
        {
            get { return _SelectedWearing; }
            set
            {
                _SelectedWearing = value;
                OnPropertyChanged();
            }
        }

        public Command AddToWishListCommand { get;private set; }

        private async void AddToWishListAsync()
        {
            if (Isbusy)
                return;
                Isbusy = true;
            int wishlistitem = 0;
            bool find = true;
            while (find)
            {
                if (Preferences.ContainsKey($"WishListItem{wishlistitem}"))
                {
                    wishlistitem++;
                }
                else
                {
                    Preferences.Set($"WishListItem{wishlistitem}",SelectedWearing.Id);
                    find = false;
                    await Shell.Current.DisplayAlert("^^", "Добавлено в корзину", "Ok");
                }
            }
        }

    }
}
