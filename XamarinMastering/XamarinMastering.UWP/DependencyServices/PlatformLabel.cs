using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinMastering.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinMastering.UWP.DependencyServices.PlatformLabel))]
namespace XamarinMastering.UWP.DependencyServices
{
    public class PlatformLabel : IPlatformLabel
    {
        public PlatformLabel()
        {
        }

        public string GetLabel()
        {
            return "Universal Windows Platform";
        }

        public string GetLabel(string additionalLabel) => $"{additionalLabel} Universal Windows Platform";

        public string GetLabel(string additionalLabel, bool addVersion)
        {
            string label = (addVersion) ? $"{additionalLabel} Universal Windows Platform {GetOSVersion()}" : $"{additionalLabel} Universal Windows Platform";

            return label;
        }

        private string GetOSVersion()
        {
            string systemVersion = Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamilyVersion;

            ulong v = ulong.Parse(systemVersion);
            ulong v1 = (v & 0xFFFF000000000000L) >> 48;
            ulong v2 = (v & 0x0000FFFF00000000L) >> 32;
            ulong v3 = (v & 0x00000000FFFF0000L) >> 16;
            ulong v4 = (v & 0x000000000000FFFFL);
            string version = $"{v1}.{v2}.{v3}.{v4}";

            return version;
        }
    }
}
