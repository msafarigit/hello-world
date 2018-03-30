using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinMastering.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinMastering.UWP.DependencyServices.FileHelper))]
namespace XamarinMastering.UWP.DependencyServices
{
    public class FileHelper : IFileHelper
    {
        //Windows.Storage.ApplicationData.Current.TemporaryFolder or Windows.Storage.ApplicationData.Current.RoamingFolder
        public string GetLocalFilePath(string fileName) => Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, fileName);

        public List<string> GetSpecialFolders()
        {
            //Windows.Storage.KnownFolders
            return new List<string>();
        }
    }
}
