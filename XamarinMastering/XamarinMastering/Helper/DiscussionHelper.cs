using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinMastering.Data;

namespace XamarinMastering.Helpers
{
    public static class DiscussionHelper
    {
        public static void AddResponse(string receiverId, string content)
        {
            Device.BeginInvokeOnMainThread(() =>
            {

                App.ViewModel.CurrentDiscussion.Add(new DiscussionInformation()
                {
                    Content = content,
                    ReceiverId = receiverId,
                    SenderId = App.ViewModel.CurrentUser.InstallationId,
                    Timestamp = DateTime.Now,
                });

            });

        }

        public static void AddResponse(string senderId, string receiverId, string content)
        {
            Device.BeginInvokeOnMainThread(() =>
            {

                if (receiverId == App.ViewModel.CurrentUser.InstallationId)
                {
                    App.ViewModel.CurrentDiscussion.Add(new DiscussionInformation()
                    {
                        Content = content,
                        ReceiverId = receiverId,
                        SenderId = senderId,
                        Timestamp = DateTime.Now,

                    });

                    if (App.CurrentDiscussionPage != null)
                    {
                        MessagingCenter.Send<Pages.DiscussionPage, string>(App.CurrentDiscussionPage, "NewMessage", senderId);
                    }
                }

            });

        }

        public async static Task<bool> SendMessageAsync(string receiverId, string message)
        {
            try
            {
                AddResponse(receiverId, message);

                var updateInformation = new Newtonsoft.Json.Linq.JObject();

                updateInformation.Add("SenderId", App.ViewModel.CurrentUser.InstallationId);
                updateInformation.Add("ReceiverId", receiverId);
                updateInformation.Add("Message", message);

                Newtonsoft.Json.Linq.JArray tags = new Newtonsoft.Json.Linq.JArray();

                tags.Add(receiverId);

                updateInformation.Add("Tags", tags);

                JToken result = await FavoritesManager.DefaultManager.CurrentClient.InvokeApiAsync("sendShortMessageToTag", updateInformation);
            }
            catch (Exception ex)
            {

            }


            return true;
        }
    }
}
