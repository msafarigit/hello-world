﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinMastering.UWP.Helpers
{
   public static class ColorHelper
    {
        public static Xamarin.Forms.Color PlatformColor =>  Xamarin.Forms.Color.FromHex("#8EC63F");

        public static Windows.UI.Color PlatformAccentColor => new Windows.UI.Color() { A = 255, R = 1, G = 174, B = 242 };
    }
}
