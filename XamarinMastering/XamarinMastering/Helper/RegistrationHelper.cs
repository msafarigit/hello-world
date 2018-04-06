using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinMastering.Data;

namespace XamarinMastering.Helpers
{
    public static class RegistrationHelper
    {
        public static string CurrentPlatformDescription
        {
            get
            {
                if (Xamarin.Forms.Device.OS == Xamarin.Forms.TargetPlatform.Windows && Xamarin.Forms.Device.Idiom == Xamarin.Forms.TargetIdiom.Phone)
                {
                    return $"{CurrentDisplayName} on Windows Phone";
                }
                else
                {
                    return $"{CurrentDisplayName} on {Xamarin.Forms.Device.OS}";
                }
            }
        }

        public static string CurrentDisplayName
        {
            get
            {
                return "Scott";
            }
        }

        public static string CurrentPlatformId
        {
            get
            {
                if (Xamarin.Forms.Device.OS == Xamarin.Forms.TargetPlatform.Windows && Xamarin.Forms.Device.Idiom == Xamarin.Forms.TargetIdiom.Phone)
                {
                    return ($"{CurrentDisplayName}_WINDOWSPHONE").ToUpper();
                }
                else
                {
                    return ($"{CurrentDisplayName}_{Xamarin.Forms.Device.OS}").ToUpper();
                }
            }
        }

        public async static Task<bool> UpdateInstallationTagsAsync(string installationId, List<string> tags)
        {
            bool successful = false;
            JArray tagContent = tags.ToJArray();
            HttpClient client = new HttpClient();
            HttpResponseMessage result = await client.PostAsync($"https://traininglabservices.azurewebsites.net/api/Registrations?installationId={installationId}", new StringContent(tagContent.ToString(), Encoding.UTF8, "application/json"));

            try
            {
                await FavoritesManager.DefaultManager.SaveRegistrationAsync(new Registration()
                {
                    Id = CurrentPlatformId,
                    Description = CurrentPlatformDescription,
                    DisplayName = CurrentDisplayName,
                    InstallationId = installationId,
                });
                
                App.ViewModel.CurrentUser = new UserInformation()
                {
                    InstallationId = CurrentPlatformId,
                    Description = CurrentPlatformDescription,
                    DisplayName = CurrentDisplayName,
                };
            }
            catch (Exception ex)
            {

            }

            return successful;
        }
    }
}
