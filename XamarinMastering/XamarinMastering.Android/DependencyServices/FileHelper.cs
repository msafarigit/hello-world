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
using Xamarin.Forms;
using XamarinMastering.Droid.DependencyServices;
using XamarinMastering.Interfaces;

[assembly: Dependency(typeof(FileHelper))]
namespace XamarinMastering.Droid.DependencyServices
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename);
        }

        public List<string> GetSpecialFolders()
        {
            List<string> folders = new List<string>();
            foreach (object folder in Enum.GetValues(typeof(System.Environment.SpecialFolder)))
                if (!string.IsNullOrEmpty(System.Environment.GetFolderPath((System.Environment.SpecialFolder)folder)))
                    folders.Add($"{folder}={System.Environment.GetFolderPath((System.Environment.SpecialFolder)folder)}");

            return folders;
        }
    }
}