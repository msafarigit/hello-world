using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Foundation;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using UIKit;
using XamarinMastering.Data;

namespace XamarinMastering.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //

        public static NSData PushDeviceToken { get; private set; } = null;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            //The Specific Apple UIKit
            UIColor accentColor = UIColor.FromRGB(0, 89, 178);

            UISlider.Appearance.TintColor = accentColor;
            UISlider.Appearance.ThumbTintColor = accentColor;

            UITabBar.Appearance.TintColor = accentColor;
            UITabBar.Appearance.SelectedImageTintColor = accentColor;

            UINavigationBar.Appearance.BarTintColor = accentColor;
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.White });

            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            SQLitePCL.CurrentPlatform.Init();

            RegisterForPushNotifications();

            LoadApplication(new App());

            //var x = typeof(Xamarin.Forms.Themes.DarkThemeResources);
            //x = typeof(Xamarin.Forms.Themes.LightThemeResources);
            //x = typeof(Xamarin.Forms.Themes.iOS.UnderlineEffect);

            return base.FinishedLaunching(app, options);
        }


        private void RegisterForPushNotifications()
        {
            UIUserNotificationSettings settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, new NSSet());

            UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            UIApplication.SharedApplication.RegisterForRemoteNotifications();
        }

        public override async void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            //Part: 7 Push Notification
            //            //messageParam: is defined in edit favorite script from azure
            //            const string templateBodyAPNS = "{\"aps\":{\"alert\":\"$(messageParam)\"}}";

            //            JObject templates = new JObject();
            //            templates["genericMessage"] = new JObject
            //                        {
            //                           {"body", templateBodyAPNS}
            //                        };

            //            Push push = FavoritesManager.DefaultManager.CurrentClient.GetPush();

            //#pragma warning disable CS1701 // Assuming assembly reference matches identity
            //            push.RegisterAsync(deviceToken, templates);
            //#pragma warning restore CS1701 // Assuming assembly reference matches identity

            //Part 9: Adding Tagging Support:  Pre-provisioned
            AppDelegate.PushDeviceToken = deviceToken;
            await RegisterForPushNotifications(FavoritesManager.DefaultManager.CurrentClient);
        }

        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            UpdateRegistration(FavoritesManager.DefaultManager.CurrentClient.InstallationId);
        }

        private async void UpdateRegistration(string installationId)
        {
            List<string> extraTags = new List<string>();
            extraTags.Add(XamarinMastering.Helpers.RegistrationHelper.CurrentPlatformId);
            await XamarinMastering.Helpers.RegistrationHelper.UpdateInstallationTagsAsync(installationId, extraTags);
        }

        public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
        {
            //responding to the notification: show to device
            Helpers.ToastHelper.ProcessNotification(userInfo);
        }

        //Part 9: Adding Tagging Support: Pre-provisioned
        public async Task RegisterForPushNotifications(MobileServiceClient client)
        {
            if (AppDelegate.PushDeviceToken != null)
            {
                try
                {
                    string registrationId = AppDelegate.PushDeviceToken
                                                       .Description
                                                       .Trim('<', '>')
                                                       .Replace(" ", string.Empty)
                                                       .ToUpperInvariant();

                    DeviceInstallation installation = new DeviceInstallation
                    {
                        InstallationId = client.InstallationId,
                        Platform = "apns",
                        PushChannel = registrationId
                    };

                    //Template: Specify exact format for receive notification
                    //$(messageParam): define a variable which server would fill this
                    PushTemplate genericTemplate = new PushTemplate
                    {
                        Body = "{\"aps\":{\"alert\":\"$(messageParam)\"}}"
                    };

                    //Tag: specific device received this notification
                    //installation.Tags.Add("iOS");
                    //installation.Tags.Add("Texas");
                    installation.Templates.Add("genericTemplate", genericTemplate);

                    PushTemplate discussionTemplate = new PushTemplate
                    {
                        Body = "{\"aps\":{\"alert\":\"$(content)\"}}"
                    };

                    installation.Templates.Add("discussionTemplate", discussionTemplate);

                    DeviceInstallation response = await client.InvokeApiAsync<DeviceInstallation, DeviceInstallation>($"/push/installations/{client.InstallationId}", installation, HttpMethod.Put, new Dictionary<string, string>());

                    //dynamicTags: what the user want such as social news as notification
                    List<string> dynamicTags = new List<string>();
                    dynamicTags.Add(XamarinMastering.Helpers.RegistrationHelper.CurrentPlatformId);

                    await XamarinMastering.Helpers.RegistrationHelper.UpdateInstallationTagsAsync(client.InstallationId, dynamicTags);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
