using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMastering.Interfaces
{
    public interface IFileHelper
    {

        string GetLocalFilePath(string filename);

        /// <summary>
        /// Get available folders for us, It doesn't mean we have permission to them
        /// </summary>
        /// <returns></returns>
        List<string> GetSpecialFolders();
    }
}
