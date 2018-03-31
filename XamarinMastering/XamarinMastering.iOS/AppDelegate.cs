﻿using System;
using System.Collections.Generic;
using System.Linq;

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

        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            //messageParam: is defined in edit favorite script from azure
            const string templateBodyAPNS = "{\"aps\":{\"alert\":\"$(messageParam)\"}}";

            JObject templates = new JObject();
            templates["genericMessage"] = new JObject
             {
               {"body", templateBodyAPNS}
             };

            Push push = FavoritesManager.DefaultManager.CurrentClient.GetPush();

#pragma warning disable CS1701 // Assuming assembly reference matches identity
            //push.RegisterAsync(deviceToken, templates);
            push.RegisterTemplateAsync(deviceToken, templates.ToString(), string.Empty, "body");
#pragma warning restore CS1701 // Assuming assembly reference matches identity
        }

        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {

        }

        public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
        {
            //responding to the notification: show to device
            Helpers.ToastHelper.ProcessNotification(userInfo);
        }

    }
}
