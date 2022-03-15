using GetOutfitApp.Models;
using GetOutfitApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetOutfitApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WearingDetail : ContentPage
    {
        WearingDetailViewModel wvm;
        public WearingDetail(WearingModel wm)
        {
            InitializeComponent();
            wvm = new WearingDetailViewModel(wm);
            this.BindingContext = wvm;
        }

        
        
    }
}