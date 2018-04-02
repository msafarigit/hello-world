using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using XamarinMastering.UWP.Renderers;

[assembly: ExportRenderer(typeof(ContentPage), typeof(SimplePageRenderer))]
namespace XamarinMastering.UWP.Renderers
{
    public class SimplePageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
        }
    }
}
