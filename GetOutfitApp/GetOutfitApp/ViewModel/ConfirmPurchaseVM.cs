using GetOutfitApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GetOutfitApp.ViewModel
{
    class ConfirmPurchaseVM:BaseViewModel
    {
        public ConfirmPurchaseVM(ObservableCollection<WishListModel> ITEMS)
        {
            ConfirmCommand = new Command(async () =>await ConfirmAsync());
            Summary = 0;
            foreach(var item in ITEMS)
            {
                Summary += item.Count * item.Price;
            }
        }

        private async Task ConfirmAsync()
        {
            await Shell.Current.DisplayAlert("Успешно", "Заказ оформлен", "Ok");
            await Shell.Current.Navigation.PopModalAsync(true);
        }

        public Command ConfirmCommand { get; set; }

        private int _Summary;

        public int Summary
        {
            get { return _Summary; }
            set { _Summary = value; OnPropertyChanged(); }
        }

    }
}
