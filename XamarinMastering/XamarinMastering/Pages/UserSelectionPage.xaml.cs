using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinMastering.Data;

namespace XamarinMastering.Pages
{
    public partial class UserSelectionPage : ContentPage
    {
        public UserSelectionPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoadAvailableUsers();
        }

        private async void LoadAvailableUsers()
        {
            System.Collections.ObjectModel.ObservableCollection<Registration> registrations = await FavoritesManager.DefaultManager.GetRegistrationsAsync();
            this.BindingContext = registrations.Where(w => w.Id != App.ViewModel.CurrentUser.InstallationId);
        }

        private async void OnUserTapped(object sender, ItemTappedEventArgs e)
        {
            App.ViewModel.CurrentDiscussion.InDiscussionUser = e.Item as Registration;

            await App.MainNavigation.PopModalAsync(true);
            await App.MainNavigation.PushAsync(new Pages.DiscussionPage(), true);
        }
    }
}
