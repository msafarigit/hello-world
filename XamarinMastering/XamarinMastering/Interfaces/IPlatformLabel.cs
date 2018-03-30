using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMastering.Interfaces
{
    /// <summary>
    /// 01: Dependency Service Interface
    /// </summary>
    public interface IPlatformLabel
    {
        string GetLabel();

        string GetLabel(string additionalLabel);

        string GetLabel(string additionalLabel, bool addVersion);
    }
}
