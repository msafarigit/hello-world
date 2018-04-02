using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using XamarinMastering.UWP.Helpers;
using XamarinMastering.UWP.Renderers;

[assembly:ExportRenderer(typeof(Xamarin.Forms.Button), typeof(AccentButtonColorRenderer))]
namespace XamarinMastering.UWP.Renderers
{
    public class AccentButtonColorRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if(Control != null) //from VisualElementRenderer
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
