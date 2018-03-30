using System;
using System.Collections.Generic;
using System.Text;
using XamarinMastering.Interfaces;

namespace XamarinMastering.Helper
{
    /// <summary>
    /// 04: Call Dependency Service
    /// </summary>
    public static class GeneralHelper
    {
        public static void Speak(string text) => Xamarin.Forms.DependencyService.Get<ITextSpeecher>().Speak(text);

        public static DeviceOrientations GetOrientation() => Xamarin.Forms.DependencyService.Get<IDeviceOrientation>().GetOrientation();

        public static string GetLabel() => Xamarin.Forms.DependencyService.Get<IPlatformLabel>().GetLabel();

        public static string GetLabel(string additionalLabel) => Xamarin.Forms.DependencyService.Get<IPlatformLabel>().GetLabel(additionalLabel: additionalLabel);

        public static string GetLabel(string additionalLabel, bool addVersion) => Xamarin.Forms.DependencyService.Get<IPlatformLabel>().GetLabel(additionalLabel, addVersion);
    }
}
