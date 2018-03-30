using System;
using System.Collections.Generic;
using System.Text;
using XamarinMastering.Interfaces;

namespace XamarinMastering.Helper
{
    public static class StorageHelper
    {
        public static List<string> GetSpecialFolders() => Xamarin.Forms.DependencyService.Get<IFileHelper>().GetSpecialFolders();
        public static string GetLocalFolderPath(string fileName) => Xamarin.Forms.DependencyService.Get<IFileHelper>().GetLocalFilePath(fileName);
    }
}
