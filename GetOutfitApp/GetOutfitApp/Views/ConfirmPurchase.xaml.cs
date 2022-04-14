using GetOutfitApp.Models;
using GetOutfitApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetOutfitApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmPurchase : ContentPage
    {
        ConfirmPurchaseVM vm;
        public ConfirmPurchase(ObservableCollection<WishListModel> ITEMS)
        {
            InitializeComponent();
            vm = new ConfirmPurchaseVM(ITEMS);
            this.BindingContext = vm;
        }
    }
}