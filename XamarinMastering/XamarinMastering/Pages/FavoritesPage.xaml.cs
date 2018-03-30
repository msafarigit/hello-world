using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinMastering.Models;

namespace XamarinMastering.Pages
{
    public partial class FavoritesPage : ContentPage
    {
        public FavoritesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            LoadFavorites();

            base.OnAppearing();
        }

        private async void LoadFavorites()
        {
            this.BindingContext = App.ViewModel;

            await App.ViewModel.RefreshFavoritesAsync();
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            new Common.Commands.NavigateToDetailCommand().Execute(e.Item as FavoriteInformation);
        }
    }
}
