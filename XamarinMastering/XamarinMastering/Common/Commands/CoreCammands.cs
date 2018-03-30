using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using XamarinMastering.Extensions;
using XamarinMastering.Helper;
using XamarinMastering.Models;
using XamarinMastering.News;
using XamarinMastering.Pages;

namespace XamarinMastering.Common.Commands
{
    public class ToggleFavoriteCommand : ICommand
    {
        private bool _isBusy = false;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !_isBusy;
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            ToggleFavoriteAsync(parameter as News.NewsInformation);
        }

        private async void ToggleFavoriteAsync(News.NewsInformation article)
        {
            this._isBusy = true;
            this.RaiseCanExecuteChanged();
            App.ViewModel.IsBusy = true;

            //TODO: Here
            FavoriteInformation favoriteInformation = await article.AsFavorite("Technology");
            await App.ViewModel.Favorites.AddAsync(favoriteInformation);

            this._isBusy = false;
            this.RaiseCanExecuteChanged();
            App.ViewModel.IsBusy = false;

        }
    }

    public class SpeakCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void RaiseCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            GeneralHelper.Speak(parameter.ToString());
        }
    }

    public class NavigateToDetailCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void RaiseCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            NavigateToDetailAsync(parameter as NewsInformation);
        }

        private async void NavigateToDetailAsync(NewsInformation newsInformation)
        {
            await App.MainNavigation.PushAsync(new ItemDetailPage(newsInformation), true);
        }
    }

    public class RefreshNewsCommand : ICommand
    {
        public bool _isBusy = false;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !_isBusy;
        }

        public void RaiseCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            PageName pageName;
            if (Enum.TryParse((string)parameter, out pageName))
                RefereshNewsAsync(pageName);
        }

        private async void RefereshNewsAsync(PageName pageName)
        {
            this._isBusy = true;
            this.RaiseCanExecuteChanged();
            App.ViewModel.IsBusy = true;
            switch (pageName)
            {
                case PageName.World:
                    await App.ViewModel.RefreshWorldNewsAsync();
                    break;
                case PageName.Technology:
                    await App.ViewModel.RefreshTrendingNewsAsync();
                    break;
                case PageName.Trending:
                    await App.ViewModel.RefreshTechnologyNewsAsync();
                    break;
                default:
                    break;
            }
            this._isBusy = false;
            this.RaiseCanExecuteChanged();
            App.ViewModel.IsBusy = false;
        }
    }

    public enum PageName
    {
        World,
        Technology,
        Trending
    }

    public class NavigateToSettingsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true; //navigate always need to be enabled
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            NavigateAsync();
        }

        private async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new SettingsPage(), true);
        }

    }
}
