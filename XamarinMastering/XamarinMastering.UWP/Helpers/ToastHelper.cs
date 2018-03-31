using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.Networking.PushNotifications;
using Windows.UI.Notifications;

namespace XamarinMastering.UWP.Helpers
{
    public static class ToastHelper
    {
        public static void SendWelcomeToast()
        {
            XmlDocument payload = new XmlDocument();

            string content = "<toast>" +
                                "<visual>" +
                                    "<binding template=\"ToastGeneric\">" +
                                    "<image placement=\"appLogoOverride\" hint-crop=\"circle\" src=\"ms-appx:///Assets/pb_toastlogo.png\"/>" +
                                        "<text>Welcome to Paperboy!</text>" +
                                        "<text>The coolest Xamarin Forms news reader in the Universe!</text>" +
                                        "<text placement=\"attribution\">WintellectNOW</text>" +
                                    "</binding>" +
                                "</visual>" +
                            "</toast>";

            payload.LoadXml(content);

            ToastNotification toast = new ToastNotification(payload);

            ToastNotifier notifier = Windows.UI.Notifications.ToastNotificationManager.CreateToastNotifier();

            notifier.Show(toast);
        }

        public static void SendNotificationToast(string title, string description)
        {
            XmlDocument payload = new XmlDocument();

            string content = "<toast>" +
                    "<visual>" +
                        "<binding template=\"ToastGeneric\">" +
                        "<image placement=\"appLogoOverride\" hint-crop=\"circle\" src=\"ms-appx:///Assets/pb_toastlogo.png\"/>" +
                            $"<text>{title}</text>" +
                            $"<text>{description}</text>" +
                            "<text placement=\"attribution\">WintellectNOW</text>" +
                        "</binding>" +
                    "</visual>" +
                "</toast>";

            payload.LoadXml(content);

            ToastNotification toast = new ToastNotification(payload);

            ToastNotifier notifier = Windows.UI.Notifications.ToastNotificationManager.CreateToastNotifier();

            notifier.Show(toast);
        }

        public static void RegisterPushListenerTask()
        {
            string taskName = "PushListenerTask";

            foreach (KeyValuePair<Guid, IBackgroundTaskRegistration> cur in BackgroundTaskRegistration.AllTasks)
                if (cur.Value.Name == taskName)
                    return;

            BackgroundTaskBuilder builder = new BackgroundTaskBuilder();

            builder.Name = taskName;

            builder.TaskEntryPoint = "Paperboy.UWP.Services.Background.PushListener";

            builder.SetTrigger(new PushNotificationTrigger());

            BackgroundTaskRegistration task = builder.Register();
        }

        public static void ProcessNotification(PushNotificationReceivedEventArgs args)
        {
            try
            {
                JObject message = JObject.Parse(args.RawNotification.Content);

                string title = message["message"].ToString();

                Helpers.ToastHelper.SendNotificationToast("New Favorite added", title);
            }
            catch
            {
            }
        }
    }
}
