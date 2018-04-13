using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMastering.Extensions;
using XamarinMastering.Models;
using XamarinMastering.News;

namespace XamarinMastering.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        public NewsInformation CurrentArticle { get; set; }
        public ItemDetailPage ()
		{
			InitializeComponent();
		}

        public ItemDetailPage(NewsInformation currentArticle)
        {
            InitializeComponent();
            this.CurrentArticle = currentArticle;
        }

        public ItemDetailPage(FavoriteInformation currentArticle)
        {
            InitializeComponent();
            this.CurrentArticle = currentArticle.AsArticle();
        }

        protected override void OnAppearing()
        {
            this.BindingContext = this.CurrentArticle;

            base.OnAppearing();
        }

        private async void discussToolbar_Clicked(object sender, EventArgs e)
        {
            await App.MainNavigation.PushModalAsync(new UserSelectionPage(), true);
        }
    }
}