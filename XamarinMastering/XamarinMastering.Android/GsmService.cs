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

using Android.Media;
using Android.Support.V4.App;
using Android.Util;
using Gcm.Client;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using XamarinMastering;

using System.Diagnostics;
using XamarinMastering.Common;
using XamarinMastering.Droid;
using XamarinMastering.Droid.Helpers;
using XamarinMastering.Data;
using System.Net.Http;

//we can set this permissions in android manifest, but following permissions is required to set in assembly!
[assembly: Permission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "com.google.android.c2dm.permission.RECEIVE")]
[assembly: UsesPermission(Name = "android.permission.INTERNET")]
[assembly: UsesPermission(Name = "android.permission.WAKE_LOCK")]
//GET_ACCOUNTS is only needed for android versions 4.0.3 and below
[assembly: UsesPermission(Name = "android.permission.GET_ACCOUNTS")]
namespace XamarinMastering.Droid
{
    [BroadcastReceiver(Permission = Gcm.Client.Constants.PERMISSION_GCM_INTENTS)]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_MESSAGE }, Categories = new string[] { "@PACKAGE_NAME@" })]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_REGISTRATION_CALLBACK }, Categories = new string[] { "@PACKAGE_NAME@" })]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_LIBRARY_RETRY }, Categories = new string[] { "@PACKAGE_NAME@" })]
    public class PushHandlerBroadcastReceiver : GcmBroadcastReceiverBase<GcmService>
    {
        public static string[] SENDER_IDS = new string[] { CoreConstants.GcmRemoteId };
    }

    [Service]
    public class GcmService : GcmServiceBase
    {
        public static string RegistrationID { get; private set; }

        public GcmService()
            : base(PushHandlerBroadcastReceiver.SENDER_IDS) { }

        protected override void OnUnRegistered(Context context, string registrationId)
        {

        }

        protected override void OnError(Context context, string errorId)
        {

        }

        protected override void OnMessage(Context context, Intent intent)
        {
            StringBuilder msg = new StringBuilder();

            if (intent != null && intent.Extras != null)
            {
                foreach (var key in intent.Extras.KeySet())
                    msg.AppendLine(key + "=" + intent.Extras.Get(key).ToString());
            }

            string message = intent.Extras.Get("message").ToString();

            //Store the message
            ISharedPreferences prefs = GetSharedPreferences(context.PackageName, FileCreationMode.Private);
            ISharedPreferencesEditor edit = prefs.Edit();
            edit.PutString("last_msg", msg.ToString());
            edit.Commit();

            if (message.Contains("~"))
            {
                List<string> contents = message.Split('~').ToList();

                XamarinMastering.Helpers.DiscussionHelper.AddResponse(contents[0], contents[1], contents[2]);

            }
            else if (!string.IsNullOrEmpty(message))
            {
                //responding to the notification: show to device
                CreateNotification(message, "A new Favorite has been added");
            }

            return;
        }

        async void CreateNotification(string title, string description)
        {
            NotificationManager notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

            Intent uiIntent = new Intent(this, typeof(MainActivity));

            NotificationCompat.Builder builder = new NotificationCompat.Builder(this);

            Android.Graphics.BitmapFactory.Options options = new Android.Graphics.BitmapFactory.Options
            {
                InJustDecodeBounds = true
            };

            Android.Graphics.Bitmap largeIcon = await Android.Graphics.BitmapFactory.DecodeResourceAsync(Resources, XamarinMastering.Droid.Resource.Drawable.icon, options);

            //responding to the notification: show to device
            ToastHelper.ProcessNotification(this, notificationManager, uiIntent, builder, title, description, largeIcon);
        }

        protected override void OnRegistered(Context context, string registrationId)
        {
            RegistrationID = registrationId;
            //Part: 7 Push Notification
            //Push push = FavoritesManager.DefaultManager.CurrentClient.GetPush();
            //MainActivity.CurrentActivity.RunOnUiThread(() => Register(push, null));

            //Part 9: Adding Tagging Support:  Pre-provisioned
            MainActivity.CurrentActivity.RunOnUiThread(() => RegisterForPushNotifications(context, FavoritesManager.DefaultManager.CurrentClient));
        }

        //Part: 7 Push Notification
        public async void Register(Microsoft.WindowsAzure.MobileServices.Push push, IEnumerable<string> tags)
        {
            try
            {
                //messageParam: is defined in edit favorite script from azure
                const string templateBodyGCM = "{\"data\":{\"message\":\"$(messageParam)\"}}";

                JObject templates = new JObject();
                templates["genericMessage"] = new JObject
                {
                    {"body", templateBodyGCM}
                };

                await push.RegisterAsync(RegistrationID, templates);
            }
            catch (Exception ex)
            {
            }
        }

        //Part 9: Adding Tagging Support:  Pre-provisioned
        public async void RegisterForPushNotifications(Context context, MobileServiceClient client)
        {
            if (GcmClient.IsRegistered(context))
            {
                try
                {
                    string registrationId = GcmClient.GetRegistrationId(context);

                    DeviceInstallation installation = new DeviceInstallation
                    {
                        InstallationId = client.InstallationId,
                        Platform = "gcm",
                        PushChannel = registrationId
                    };

                    PushTemplate genericTemplate = new PushTemplate
                    {
                        Body = "{\"data\":{\"message\":\"$(messageParam)\"}}"
                    };

                    installation.Templates.Add("genericTemplate", genericTemplate);

                    PushTemplate discussionTemplate = new PushTemplate
                    {
                        Body = "{\"data\":{\"message\":\"$(content)\"}}"
                    };

                    installation.Templates.Add("discussionTemplate", discussionTemplate);

                    //List<string> extraTags = new List<string>();
                    //Tag: specific device received this notification
                    //extraTags.Add("Android");
                    //installation.Tags = extraTags;

                    DeviceInstallation response = await client.InvokeApiAsync<DeviceInstallation, DeviceInstallation>($"/push/installations/{client.InstallationId}", installation, HttpMethod.Put, new Dictionary<string, string>());

                    List<string> extraTags = new List<string>();
                    extraTags.Add(XamarinMastering.Helpers.RegistrationHelper.CurrentPlatformId);

                    await XamarinMastering.Helpers.RegistrationHelper.UpdateInstallationTagsAsync(client.InstallationId, extraTags);
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
            }
        }

    }

}