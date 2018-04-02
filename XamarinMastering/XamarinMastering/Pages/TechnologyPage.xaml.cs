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
	public partial class TechnologyPage : ContentPage
	{
		public TechnologyPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            //LoadNewsAsync();
            this.BindingContext = App.ViewModel;
            base.OnAppearing();
        }

        //private async void LoadNewsAsync()
        //{
        //    newsListView.IsRefreshing = true;
        //    var news = await Helpers.NewsHelper.GetByCategoryAsync(News.NewsCategoryType.ScienceAndTechnology);
        //    this.BindingContext = news;
        //    newsListView.IsRefreshing = false;
        //}

        //public void NewsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    new NavigateToDetailCommand().Execute(e.Item as NewsInformation);
        //}
    }
}