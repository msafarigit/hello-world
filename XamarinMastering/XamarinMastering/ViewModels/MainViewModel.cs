using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using XamarinMastering.Common;
using XamarinMastering.Data;
using XamarinMastering.Extensions;
using XamarinMastering.Helpers;
using XamarinMastering.Interfaces;
using XamarinMastering.Models;
using XamarinMastering.News;

namespace XamarinMastering.ViewModels
{
    public class MainViewModel : ObservableBase
    {
        //ObservableCollection:
        //  Represents a dynamic data collection that provides notifications when items get added, removed, or when the whole list is refreshed.

        private static volatile MainViewModel _viewModel;
        private static object _lockObject = new object();

        private MainViewModel()
        {
            this.WorldNews = new ObservableCollection<NewsInformation>();
            this.SearchResults = new ObservableCollection<News.NewsInformation>();
            this.TechnologyNews = new ObservableCollection<NewsInformation>();
            this.TrendingNews = new ObservableCollection<NewsInformation>();
            this.Favorites = new FavoritesCollection();

            this.CurrentUser = new UserInformation
            {
                DisplayName = "Mahdi",
                BioContent = "Scott has been developing Microsoft Enterprise solutions for organizations around the world for the last 28 years, and the Senior Architect & Developer behind Liquid Daffodil",
                ProfileImageUrl = "https://wintellectnow.blob.core.windows.net/public/Scott_Peterson.jpg"
            };

            this.SearchQuery = "Microsoft";
        }

        private string searchQuery;
        public string SearchQuery
        {
            get { return this.searchQuery; }
            set { this.SetProperty(ref this.searchQuery, value); }
        }

        public static MainViewModel GetViewModel()
        {
            if(_viewModel == null)
            {
                lock (_lockObject)
                    _viewModel = new MainViewModel();
            }
            return _viewModel;
        }

        private FavoritesCollection _favorites;
        public FavoritesCollection Favorites
        {
            get { return this._favorites; }
            set { this.SetProperty(ref this._favorites, value); }
        }

        private ObservableCollection<NewsInformation> _worldNews;
        public ObservableCollection<NewsInformation> WorldNews
        {
            get { return this._worldNews; }
            set { this.SetProperty(ref this._worldNews, value); }
        }

        private ObservableCollection<News.NewsInformation> _searchResults;
        public ObservableCollection<News.NewsInformation> SearchResults
        {
            get { return this._searchResults; }
            set { this.SetProperty(ref this._searchResults, value); }
        }

        private ObservableCollection<NewsInformation> _technologyNews;
        public ObservableCollection<NewsInformation> TechnologyNews
        {
            get { return this._technologyNews; }
            set { this.SetProperty(ref this._technologyNews, value); }
        }

        private ObservableCollection<NewsInformation> _trendingNews;
        public ObservableCollection<NewsInformation> TrendingNews
        {
            get { return this._trendingNews; }
            set { this.SetProperty(ref this._trendingNews, value); }
        }

        private UserInformation _currentUser;
        public UserInformation CurrentUser
        {
            get { return _currentUser; }
            set { this.SetProperty(ref this._currentUser, value); }
        }

        private string _platformLabel;
        public string PlatformLabel
        {
            get { return _platformLabel; }
            set { this.SetProperty(ref this._platformLabel, value); }
        }

        private string _extendedPlatformLabel;
        public string ExtendedPlatformLabel
        {
            get { return this._extendedPlatformLabel; }
            set { this.SetProperty(ref this._extendedPlatformLabel, value); }
        }

        private DeviceOrientations _currentOrientation;
        public DeviceOrientations CurrentOrientation
        {
            get { return this._currentOrientation; }
            set { this.SetProperty(ref this._currentOrientation, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return this._isBusy; }
            set { this.SetProperty(ref this._isBusy, value); }
        }

        public async void RefreshNewsAsync()
        {
            this.IsBusy = true;

            await RefreshWorldNewsAsync();
            await RefreshTechnologyNewsAsync();
            await RefreshTrendingNewsAsync();

            this.IsBusy = false;
        }
        
        public async Task RefreshFavoritesAsync()
        {
            this.IsBusy = true;
            this.Favorites.Clear();
            //List<Favorite> favorites = await App.DataBase.GetItemsAsync();
            ObservableCollection<Favorite> favorites = await FavoritesManager.DefaultManager.GetFavoritesAsync();

            foreach (Favorite favorite in favorites)
                this.Favorites.Add(favorite.AsFavorite(categoryTitle: "Technology"));

            this.IsBusy = false;
        }

        public async Task RefreshTrendingNewsAsync()
        {
            this.TrendingNews.Clear();
            var trendingNews = await NewsHelper.GetTrendingAsync();
            foreach (var news in trendingNews)
                this.TrendingNews.Add(news);
        }

        public async Task RefreshSearchResults()
        {
            this.IsBusy = true;
            this.SearchResults.Clear();
            string query = this.SearchQuery;

            var news = await Helpers.NewsHelper.SearchAsync(query);
            foreach (var item in news)
                this.SearchResults.Add(item);

            this.IsBusy = false;
        }

        public async Task RefreshTechnologyNewsAsync()
        {
            this.TechnologyNews.Clear();
            var technologyNews = await NewsHelper.GetByCategoryAsync(NewsCategoryType.ScienceAndTechnology);
            foreach (var news in technologyNews)
                this.TechnologyNews.Add(news);
        }

        public async Task RefreshWorldNewsAsync()
        {
            this.WorldNews.Clear();
            var worldNews = await NewsHelper.GetByCategoryAsync(NewsCategoryType.World);
            foreach (var news in worldNews)
                this.WorldNews.Add(news);
        }
    }
}
