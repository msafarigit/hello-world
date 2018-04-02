using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinMastering.iOS.Helpers;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(XamarinMastering.iOS.Renderer.AccentButtonColorRenderer))]
namespace XamarinMastering.iOS.Renderer
{
    public class AccentButtonColorRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if(Control != null) //from ViewRenderer
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
