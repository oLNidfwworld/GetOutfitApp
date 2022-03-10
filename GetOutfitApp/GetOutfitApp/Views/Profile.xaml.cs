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
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
            brand1.Source = ImageSource.FromResource("GetOutfitApp.Resources.chanel.jpg");
            brand2.Source = ImageSource.FromResource("GetOutfitApp.Resources.chanel.jpg");
            brand3.Source = ImageSource.FromResource("GetOutfitApp.Resources.chanel.jpg");
            brand4.Source = ImageSource.FromResource("GetOutfitApp.Resources.chanel.jpg");
            brand5.Source = ImageSource.FromResource("GetOutfitApp.Resources.chanel.jpg");
            brand6.Source = ImageSource.FromResource("GetOutfitApp.Resources.chanel.jpg");
            brand7.Source = ImageSource.FromResource("GetOutfitApp.Resources.chanel.jpg");
            brand8.Source = ImageSource.FromResource("GetOutfitApp.Resources.chanel.jpg");
            brand9.Source = ImageSource.FromResource("GetOutfitApp.Resources.chanel.jpg");
            brand10.Source = ImageSource.FromResource("GetOutfitApp.Resources.chanel.jpg");
            brand11.Source = ImageSource.FromResource("GetOutfitApp.Resources.chanel.jpg");
            brand12.Source = ImageSource.FromResource("GetOutfitApp.Resources.chanel.jpg");
        }
    }
}