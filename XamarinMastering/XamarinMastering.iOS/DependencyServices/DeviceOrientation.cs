using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using XamarinMastering.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinMastering.iOS.DependencyServices.DeviceOrientation))]
namespace XamarinMastering.iOS.DependencyServices
{
    public class DeviceOrientation : IDeviceOrientation
    {
        public DeviceOrientation()
        {
        }

        public DeviceOrientations GetOrientation()
        {
            UIInterfaceOrientation currentOrientaion = UIApplication.SharedApplication.StatusBarOrientation;
            bool isPortrait = currentOrientaion == UIInterfaceOrientation.Portrait || currentOrientaion == UIInterfaceOrientation.PortraitUpsideDown;
            return isPortrait ? DeviceOrientations.Portrait : DeviceOrientations.Landscape;
        }
    }
}