using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinMastering
{
    //SearchBar: A Xamarin.Forms.View control that provides a search box.
    public class AlphaNumericOnlyBehavior : Behavior<SearchBar>
    {
        protected override void OnAttachedTo(SearchBar entry)
        {
            entry.TextChanged += OnEntryTextChnaged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(SearchBar entry)
        {
            entry.TextChanged -= OnEntryTextChnaged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChnaged(object sender, TextChangedEventArgs e)
        {
            bool isValid = System.Text.RegularExpressions.Regex.IsMatch(e.NewTextValue, @"^[a-zA-Z-0-9\s]+$");
            SearchBar searchBar = sender as SearchBar;
            searchBar.TextColor = isValid ? Color.Default : Color.Red;
        }

    }
}
