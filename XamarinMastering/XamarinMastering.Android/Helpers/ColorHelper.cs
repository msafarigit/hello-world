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

namespace XamarinMastering.Droid.Helpers
{
   public static class ColorHelper
    {
        public static Android.Graphics.Color PlatformAccentColor => Android.Graphics.Color.Argb(255, 142, 198, 63);

        public static Xamarin.Forms.Color PlatformColor => Xamarin.Forms.Color.FromHex("#8EC63F");
    }
}