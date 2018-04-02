using System;
using Xamarin.Forms;

namespace XamarinMastering
{
    // Summary BindableObject:
    //     Provides a mechanism by which application developers can propagate changes that
    //     are made to data in one object to another, by enabling validation, type coercion,
    //     and an event system. Xamarin.Forms.BindableProperty.

    public class BehaviorBase<T> : Behavior<T> 
        where T : BindableObject
    {
        public T AssociatedObject { get; private set; }

        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;

            if (bindable.BindingContext != null)
                BindingContext = bindable.BindingContext;

            bindable.BindingContextChanged += OnBindingContextChanged;
        }

        protected override void OnDetachingFrom(T bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            AssociatedObject = null;
        }

        //OnAppearing Call this!
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }

        private void OnBindingContextChanged(object sender, EventArgs e) => OnBindingContextChanged();
    }
}

