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
    public partial class TrendingPage : ContentPage
    {
        public TrendingPage()
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
        //    newsListView.IsRefreshing = true;
        //    var news = await Helpers.NewsHelper.GetTrendingAsync();
        //    this.BindingContext = news;
        //    newsListView.IsRefreshing = false;
        //}

        private void newsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //App.Current.Resources["ListTextColor"] = Color.Turquoise; 
        }

        //protected override void OnSizeAllocated(double width, double height)
        //{
        //    base.OnSizeAllocated(width, height);

        //    if (width > height)
        //    {
        //        outerStack.Orientation = StackOrientation.Horizontal;
        //    }
        //    else
        //    {
        //        outerStack.Orientation = StackOrientation.Vertical;
        //    }
        //}

        public void NewsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            new NavigateToDetailCommand().Execute(e.Item as NewsInformation);
        }
    }
}