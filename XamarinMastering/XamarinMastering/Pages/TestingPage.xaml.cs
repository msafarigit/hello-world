using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinMastering.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestingPage : ContentPage
	{
		public TestingPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            this.BindingContext = App.ViewModel.CurrentUser;
            base.OnAppearing();
        }
    }
}