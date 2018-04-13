using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using XamarinMastering.Data;
using Microsoft.WindowsAzure.MobileServices;
using Windows.Networking.PushNotifications;
using System.Net.Http;

namespace XamarinMastering.UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            //Part 9: Adding Tagging Support: Pre-provisioned
            Helpers.ToastHelper.RegisterPushListenerTask();

            //Part: 7 Push Notification
            //await InitNotificationsAsync();
            ////Helpers.ToastHelper.RegisterPushListenerTask();

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                Xamarin.Forms.Forms.Init(e);

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }

            //Part 9: Adding Tagging Support: Pre-provisioned
            await RegisterForPushNotificationsAsync(FavoritesManager.DefaultManager.CurrentClient);

            // Ensure the current window is active
            Window.Current.Activate();
        }

        //Part: 7 Push Notification
        //private async Task InitNotificationsAsync()
        //{
        //    PushNotificationChannel channel = await Windows.Networking.PushNotifications.PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();

        //    //messageParam: is defined in edit favorite script from azure
        //    const string templateBodyWNS = "{\"message\":\"$(messageParam)\"}";
        //    //const string templateBodyWNS = "<toast><visual><binding template=\"ToastText01\"><text id=\"1\">$(messageParam)</text></binding></visual></toast>";

        //    Push push = FavoritesManager.DefaultManager.CurrentClient.GetPush();

        //    JObject headers = new JObject();
        //    headers["X-WNS-Type"] = "wns/raw";

        //    JObject templates = new JObject();
        //    templates["genericMessage"] = new JObject
        //            {
        //                {"body", templateBodyWNS},
        //                {"headers", headers}
        //            };

        //    await push.RegisterAsync(channel.Uri, templates);
        //    channel.PushNotificationReceived += OnNotificationReceived;
        //}

        //Part: 7 Push Notification
        //private void OnNotificationReceived(PushNotificationChannel sender, PushNotificationReceivedEventArgs args)
        //{
        //    //args.NotificationType
        //    //args.RawNotification

        //    //responding to the notification: show to device
        //    Helpers.ToastHelper.ProcessNotification(args);
        //}

        //Part 9: Adding Tagging Support: Pre-provisioned
        public async Task RegisterForPushNotificationsAsync(MobileServiceClient client)
        {
            PushNotificationChannel channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();

            if (channel != null)
            {
                try
                {
                    string registrationId = channel.Uri.ToString();
                    DeviceInstallation installation = new DeviceInstallation
                    {
                        InstallationId = client.InstallationId,
                        Platform = "wns",
                        PushChannel = registrationId
                    };

                    //Template: Specify exact format for receive notification
                    //$(messageParam): define a variable which server would fill this
                    WindowsPushTemplate genericTemplate = new WindowsPushTemplate
                    {
                        Body = "{\"message\":\"$(messageParam)\"}"
                    };

                    genericTemplate.Headers.Add("X-WNS-Type", "wns/raw");
                    installation.Templates.Add("genericTemplate", genericTemplate);

                    WindowsPushTemplate discussionTemplate = new WindowsPushTemplate
                    {
                        Body = "{\"message\":\"$(content)\"}"
                    };

                    discussionTemplate.Headers.Add("X-WNS-Type", "wns/raw");
                    installation.Templates.Add("discussionTemplate", discussionTemplate);

                    //List<string> extraTags = new List<string>();
                    //Tag: specific device received this notification
                    //extraTags.Add("Windows");
                    //installation.Tags = extraTags;

                    DeviceInstallation recordedInstallation = await client.InvokeApiAsync<DeviceInstallation, DeviceInstallation>($"/push/installations/{client.InstallationId}", installation, HttpMethod.Put, new Dictionary<string, string>());

                    //dynamicTags: what the user want such as social news as notification
                    List<string> dynamicTags = new List<string>();
                    dynamicTags.Add(XamarinMastering.Helpers.RegistrationHelper.CurrentPlatformId);

                    await XamarinMastering.Helpers.RegistrationHelper.UpdateInstallationTagsAsync(client.InstallationId, dynamicTags);

                    channel.PushNotificationReceived += OnNotificationReceived;
                }
                catch (Exception ex)
                {
                }

                return;
            }
        }

        private void OnNotificationReceived(PushNotificationChannel sender, PushNotificationReceivedEventArgs args)
        {
            if (args.NotificationType == PushNotificationType.Raw)
                args.Cancel = true;

            Helpers.ToastHelper.ProcessNotification(args);
        }



        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            SuspendingDeferral deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
