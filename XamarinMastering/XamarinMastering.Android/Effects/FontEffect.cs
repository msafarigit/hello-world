using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using XamarinMastering.Droid.Effects;

[assembly: ExportEffect(typeof(FontEffect), "FontEffect")]
namespace XamarinMastering.Droid.Effects
{
    public class FontEffect : PlatformEffect
    {
        TextView textViewControl;
        Context context = Android.App.Application.Context;

        protected override void OnAttached()
        {
            try
            {
                //Xamarin.Forms.PlatformEffect<TContainer, TControl> : Control
                textViewControl = Control as TextView;
                //Xamarin.Forms.Effect : Element
                string fontPath = "Fonts/" + CustomFontEffect.GetFontFileName(Element) + ".ttf";

                //Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, fontPath);
                Android.Graphics.Typeface font = Android.Graphics.Typeface.CreateFromAsset(context.Assets, fontPath);
                textViewControl.Typeface = font;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if(args.PropertyName == CustomFontEffect.FontFileNameProperty.PropertyName)
            {
                //Android.Graphics.Typeface font = Android.Graphics.Typeface.CreateFromAsset(Forms.Context.ApplicationContext.Assets, "Fonts/" + CustomFontEffect.GetFontFileName(Element) + ".ttf");
                string fontPath = "Fonts/" + CustomFontEffect.GetFontFileName(Element) + ".ttf";
                Android.Graphics.Typeface font = Android.Graphics.Typeface.CreateFromAsset(context.Assets, fontPath);
                textViewControl.Typeface = font;
            }
        }
    }
}