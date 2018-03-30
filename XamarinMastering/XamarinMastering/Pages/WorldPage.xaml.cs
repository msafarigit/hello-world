using XamarinMastering.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMastering.Common.Commands;
using XamarinMastering.News;

namespace XamarinMastering.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorldPage : ContentPage
    {
        public WorldPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            this.BindingContext = App.ViewModel;
            //LoadNewsAsync();
            base.OnAppearing();
        }

        //private async void LoadNewsAsync()
        //{
        //    NewsListView.IsRefreshing = true;
        //    var news = await NewsHelper.GetTrendingAsync();
        //    this.BindingContext = news;
        //    NewsListView.IsRefreshing = false;
        //}

        public void NewsListView_ItemSelected(object sender, EventArgs e)
        {
            //App : Application
            App.Current.Resources["ListTextColor"] = Color.Blue;
        }

        public void NewsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            new NavigateToDetailCommand().Execute(e.Item as NewsInformation);
        }
    }
}