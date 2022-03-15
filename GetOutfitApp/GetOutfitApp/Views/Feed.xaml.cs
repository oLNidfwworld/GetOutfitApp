using GetOutfitApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetOutfitApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Feed : ContentPage
    {
        public Feed()
        {
            InitializeComponent();
        }

        async void CollectionView_SelectionChanged(System.Object sender,SelectionChangedEventArgs e)
        {
            var cat = e.CurrentSelection.FirstOrDefault() as CategoriesModel;
            if (cat == null)
                return;

            await Navigation.PushModalAsync(new Category(cat));

            ((CollectionView)sender).SelectedItem = null;
        }

        private async void CollectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var cat = e.CurrentSelection.FirstOrDefault() as WearingModel;
            if (cat == null)
                return;

            await Navigation.PushModalAsync(new WearingDetail(cat));

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}