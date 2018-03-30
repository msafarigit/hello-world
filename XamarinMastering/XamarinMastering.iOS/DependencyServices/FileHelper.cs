using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using XamarinMastering.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinMastering.iOS.DependencyServices.FileHelper))]
namespace XamarinMastering.iOS.DependencyServices
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = System.IO.Path.Combine(docFolder, "..", "Library", "Databases");

            if (!System.IO.Directory.Exists(libFolder))
                System.IO.Directory.CreateDirectory(libFolder);

            return System.IO.Path.Combine(libFolder, filename);
        }

        public List<string> GetSpecialFolders()
        {
            List<string> folders = new List<string>();
            foreach (var folder in Enum.GetValues(typeof(Environment.SpecialFolder)))
            {
                if (!string.IsNullOrEmpty(Environment.GetFolderPath((Environment.SpecialFolder)folder)))
                    folders.Add($"{folder}={Environment.GetFolderPath((Environment.SpecialFolder)folder)}");
            }
            return folders;
        }
    }
}