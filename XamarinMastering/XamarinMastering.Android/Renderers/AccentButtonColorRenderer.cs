using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinMastering.Droid.Helpers;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(XamarinMastering.Droid.Renderers.AccentButtonColorRenderer))]
namespace XamarinMastering.Droid.Renderers
{
    public class AccentButtonColorRenderer : ButtonRenderer
    {
        public AccentButtonColorRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if(base.Control != null)
            {
                Xamarin.Forms.Button button = e.NewElement as Xamarin.Forms.Button;
                button.BackgroundColor = ColorHelper.PlatformColor;
                button.TextColor = Color.White;
                button.FontAttributes = FontAttributes.Bold;
                button.CornerRadius = 22;
            }
        }
    }
}