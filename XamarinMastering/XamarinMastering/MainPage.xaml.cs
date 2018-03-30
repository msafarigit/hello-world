using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinMastering.Helper;
using XamarinMastering.Pages;
using XamarinMastering.ViewModels;

namespace XamarinMastering
{
	public partial class MainPage : TabbedPage //ContentPage
    {
		public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            App.ViewModel = MainViewModel.GetViewModel();
            App.ViewModel.RefreshNewsAsync();

            App.MainNavigation = Navigation;

            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
            //this.Content = new StackLayout
            //{
            //};

            string label = GeneralHelper.GetLabel("Hello ", true);

            List<string> folders = StorageHelper.GetSpecialFolders();
            string databasePath = StorageHelper.GetLocalFolderPath("xamarinmastering.db3");

            base.OnAppearing();
        }

        private void Current_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            bool isConnectedToInternet = e.IsConnected;
        }

        //private async void ToolbarItem_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new SettingsPage(), true);
        //}

        private async void StyleTest_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TestingPage());
        }
    }
}
