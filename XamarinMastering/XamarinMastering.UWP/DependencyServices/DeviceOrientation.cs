using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;
using XamarinMastering.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinMastering.UWP.DependencyServices.DeviceOrientation))]
namespace XamarinMastering.UWP.DependencyServices
{
    public class DeviceOrientation : IDeviceOrientation
    {
        public DeviceOrientation()
        {
        }

        public DeviceOrientations GetOrientation()
        {
            ApplicationView currentView = ApplicationView.GetForCurrentView();
            return currentView.Orientation == ApplicationViewOrientation.Landscape ? DeviceOrientations.Landscape : DeviceOrientations.Portrait;
        }
    }
}
