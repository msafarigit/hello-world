using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMastering.Interfaces
{
    public interface IDeviceOrientation
    {

        DeviceOrientations GetOrientation();
    }

    public enum DeviceOrientations
    {
        Undefined,
        Landscape,
        Portrait
    }
}
