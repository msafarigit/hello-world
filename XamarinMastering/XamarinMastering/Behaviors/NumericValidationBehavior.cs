using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinMastering
{
    public class NumericValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            double result = default(double);
            bool isValid = double.TryParse(e.NewTextValue, out result);
            Entry entry = sender as Entry;
            entry.TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}
