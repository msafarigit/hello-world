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
            base.OnAttachedTo(entry);
            entry.TextChanged += OnEntryTextChnaged;
        }

        protected override void OnDetachingFrom(SearchBar entry)
        {
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChnaged(object sender, TextChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

    }
}
