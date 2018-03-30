using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinMastering.Data;
using XamarinMastering.Interfaces;
using XamarinMastering.ViewModels;

namespace XamarinMastering
{
	public partial class App : Application
	{
        //private static volatile FavoritesDatabase _database;
        //private static object _lockObject = new object();

        //public static FavoritesDatabase DataBase
        //{
        //    get
        //    {
        //        if (_database == null)
        //        {
        //            lock (_lockObject)
        //            {
        //                string databasePath = DependencyService.Get<IFileHelper>().GetLocalFilePath("Favorites.db3");
        //                _database = new FavoritesDatabase(databasePath);
        //            }
        //        }
        //        return _database; 
        //    }
        //}

        public static MainViewModel ViewModel { get; set; }
        public static INavigation MainNavigation { get; set; }
		public App ()
		{
            InitializeComponent();

            //MainPage = new XamarinMastering.Pages.ListViewPage1();
            //MainPage = new XamarinMastering.MainPage(); When we don't want to use Navigation
            MainPage = new NavigationPage(new MainPage()); //When use Navigation as root page
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
