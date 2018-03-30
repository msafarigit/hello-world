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

[assembly: Xamarin.Forms.Dependency(typeof(XamarinMastering.Droid.DependencyServices.DeviceOrientation))]
namespace XamarinMastering.Droid.DependencyServices
{
    public class DeviceOrientation : IDeviceOrientation
    {
        public DeviceOrientation()
        {
        }

        public static void Init()
        {
        }

        public DeviceOrientations GetOrientation()
        {
            IWindowManager windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
            SurfaceOrientation rotation = windowManager.DefaultDisplay.Rotation;
            bool isLandscape = rotation == SurfaceOrientation.Rotation90 || rotation == SurfaceOrientation.Rotation270;
            return isLandscape ? DeviceOrientations.Landscape : DeviceOrientations.Portrait; 
        }
    }
}