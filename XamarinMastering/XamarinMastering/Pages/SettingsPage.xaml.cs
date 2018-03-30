using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMastering.Helper;
using XamarinMastering.Interfaces;

namespace XamarinMastering.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            IntializeSettings();
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.Resources["ListTextColor"] = Color.Pink;
            //await Navigation.PushAsync(new WorldPage());
        }

        private void IntializeSettings()
        {

            this.BindingContext = App.ViewModel;

            //displayNameEntry.Text = "Mahdi";
            //bioEditor.Text = "Scott has been developing Microsoft Enterprise solutions for organizations around the world for the last 28 years, and the Senior Architect & Developer behind Liquid Daffodil";
            //profileImage.Source = "https://wintellectnow.blob.core.windows.net/public/Scott_Peterson.jpg";
            articleCountSlider.Value = 15;
            categoryPicker.SelectedIndex = 1;

            string label = GeneralHelper.GetLabel();
            string extendedLablel = GeneralHelper.GetLabel("Running on: ", true);
            DeviceOrientations orientation = GeneralHelper.GetOrientation();

            App.ViewModel.PlatformLabel = label;
            App.ViewModel.ExtendedPlatformLabel = extendedLablel;
            App.ViewModel.CurrentOrientation = orientation;
        }
    }
}