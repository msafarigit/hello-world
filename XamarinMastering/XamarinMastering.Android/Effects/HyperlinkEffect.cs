using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinMastering.Droid.Effects;
using XamarinMastering.Droid.Helpers;

[assembly: ExportEffect(typeof(HyperlinkEffect), "HyperlinkEffect")]
namespace XamarinMastering.Droid.Effects
{
    public class HyperlinkEffect : PlatformEffect
    {
        TextView textViewControl => Control as TextView;

        protected override void OnAttached()
        {
            try
            {
                textViewControl.SetTextColor(ColorHelper.PlatformAccentColor);
                textViewControl.SetTypeface(null, Android.Graphics.TypefaceStyle.Bold);

                SetUnderLine(true);

                textViewControl.Click += (sender, eventArgs) => { };
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnDetached()
        {
            SetUnderLine(false);
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            if (args.PropertyName == Label.TextProperty.PropertyName || args.PropertyName == Label.FormattedTextProperty.PropertyName)
                SetUnderLine(true);
        }

        private void SetUnderLine(bool underLined)
        {
            try
            {
                if (underLined)
                {
                    textViewControl.PaintFlags |= PaintFlags.UnderlineText;
                }
                else
                {
                    textViewControl.PaintFlags &= ~PaintFlags.UnderlineText;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot underline Label. Error: ", ex.Message);
            }
        }
    }
}