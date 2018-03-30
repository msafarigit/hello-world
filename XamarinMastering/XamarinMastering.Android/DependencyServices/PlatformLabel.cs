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
using XamarinMastering.Interfaces;

/// <summary>
/// 03: Dependency Service Register
/// </summary>
[assembly: Xamarin.Forms.Dependency(typeof(XamarinMastering.Droid.DependencyServices.PlatformLabel))]
namespace XamarinMastering.Droid.DependencyServices
{
    /// <summary>
    /// 02: Dependency Service Implementation
    /// </summary>
    public class PlatformLabel : IPlatformLabel
    {

        public PlatformLabel()
        {
        }

        public static void Init()
        {
        }

        public string GetLabel()
        {
            return "Android";
        }

        public string GetLabel(string additionalLabel) => additionalLabel + " Android";

        public string GetLabel(string additionalLabel, bool addVersion)
        {
            string label = addVersion ? $"{additionalLabel} Android {GetOSVersion()}" : $"{additionalLabel} Android";
            return label;
        }

        private string GetOSVersion() => Android.OS.Build.VERSION.Release;
    }
}