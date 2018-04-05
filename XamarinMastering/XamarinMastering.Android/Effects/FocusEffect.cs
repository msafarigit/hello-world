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

//same as XamarinMastering.Effects:effectId
[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(XamarinMastering.Effect.Droid.FocusEffect), "FocusEffect")]
namespace XamarinMastering.Effect.Droid
{
    //public abstract class PlatformEffect : PlatformEffect<ViewGroup, global::Android.Views.View>
    public class FocusEffect : Xamarin.Forms.Platform.Android.PlatformEffect
    {
        Android.Graphics.Color backgroundColor => XamarinMastering.Droid.Helpers.ColorHelper.PlatformAccentColor;
        protected override void OnAttached()
        {
            try
            {
                //Control from Xamarin.Forms.PlatformEffect<TContainer, TControl>
                Control.SetBackgroundColor(backgroundColor);
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
            base.OnElementPropertyChanged(args);

            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    Android.Graphics.Drawables.ColorDrawable controlBackground = Control.Background as Android.Graphics.Drawables.ColorDrawable;
                    if (controlBackground.Color == backgroundColor)
                    {
                        Control.SetBackgroundColor(Android.Graphics.Color.Wheat);
                        EditText nativeEditText = Control as global::Android.Widget.EditText;
                        nativeEditText.SetSelectAllOnFocus(true);
                    }
                    else
                    {
                        Control.SetBackgroundColor(backgroundColor);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}