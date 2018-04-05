using System;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using System.ComponentModel;
using XamarinMastering.UWP.Effects;

//same as XamarinMastering.Effects:effectId
[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(FocusEffect), "FocusEffect")]
namespace XamarinMastering.UWP.Effects
{
    public class FocusEffect : PlatformEffect
    {
        Windows.UI.Color backgroundColor;

        protected override void OnAttached()
        {
            try
            {
                backgroundColor = Helpers.ColorHelper.PlatformAccentColor;
                //Control from Xamarin.Forms.PlatformEffect<TContainer, TControl>
                (Control as Windows.UI.Xaml.Controls.Control).Background = new SolidColorBrush(Windows.UI.Colors.White);
                (Control as FormsTextBox).BackgroundFocusBrush = new SolidColorBrush(backgroundColor);
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    if (((Control as FormsTextBox).BackgroundFocusBrush as SolidColorBrush).Color == backgroundColor)
                    {
                        (Control as FormsTextBox).SelectAll();
                    }
                    else
                    {
                        
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
} 