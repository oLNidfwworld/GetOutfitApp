using GetOutfitApp.Models;
using GetOutfitApp.ViewModel;
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
    public partial class Category : ContentPage
    {
        CategoryViewModel cvm;
        public Category(CategoriesModel cat)
        {
            InitializeComponent();
            cvm = new CategoryViewModel(cat);
            this.BindingContext = cvm;
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedproduct = e.CurrentSelection.FirstOrDefault() as WearingModel;
            if (selectedproduct == null)
                return;

            //await Navigation.PushModalAsync(new Category(cat));

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}