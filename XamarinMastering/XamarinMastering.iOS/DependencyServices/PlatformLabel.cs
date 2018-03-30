using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using XamarinMastering.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinMastering.iOS.DependencyServices.PlatformLabel))]
namespace XamarinMastering.iOS.DependencyServices
{
    public class PlatformLabel : IPlatformLabel
    {
        public PlatformLabel()
        {
        }

        public string GetLabel()
        {
            return "iOS";
        }

        public string GetLabel(string additionalLabel) => $"{additionalLabel} iOS";

        public string GetLabel(string additionalLabel, bool addVersion)
        {
            string label = addVersion ? $"{additionalLabel} iOS {GetOSVersion()}" : $"{additionalLabel} iOS";
            return label;
        }

        private string GetOSVersion() => UIDevice.CurrentDevice.SystemVersion;
    }
}
