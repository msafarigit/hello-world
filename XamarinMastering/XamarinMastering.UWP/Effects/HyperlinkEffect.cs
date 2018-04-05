 using System;
using Xamarin.Forms;
using System.ComponentModel;
using XamarinMastering.UWP.Effects;
using Xamarin.Forms.Platform.UWP;
using Windows.UI.Xaml.Documents;
using XamarinMastering.UWP.Helpers;

[assembly: ExportEffect(typeof(HyperlinkEffect), "HyperlinkEffect")]
namespace XamarinMastering.UWP.Effects
{
    public class HyperlinkEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            Windows.UI.Xaml.Controls.TextBlock control = Control as Windows.UI.Xaml.Controls.TextBlock;
            
            control.Foreground = new Windows.UI.Xaml.Media.SolidColorBrush(ColorHelper.PlatformAccentColor);
            control.FontWeight = Windows.UI.Text.FontWeights.Bold;

            control.IsTapEnabled = true;
            control.Tapped += (s, e) =>
            {

            };

            UnderlineText(control, control.Text);
        }

        protected override void OnDetached()
        {
        }

        void UnderlineText(Windows.UI.Xaml.Controls.TextBlock control, string originalText)
        {
            control.Text = string.Empty;
            Underline ul = new Underline();
            Run run = new Run();
            run.Text = originalText;
            ul.Inlines.Add(run);
            control.Inlines.Add(ul);
        }
    }
}