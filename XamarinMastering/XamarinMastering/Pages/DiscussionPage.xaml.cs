using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinMastering.Pages
{
    public partial class DiscussionPage : ContentPage
    {
        public DiscussionPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            IntializeIntraAppCommunication();

            LoadDiscussion();
        }

        private void IntializeIntraAppCommunication()
        {
            App.CurrentDiscussionPage = this;

            Xamarin.Forms.MessagingCenter.Subscribe<DiscussionPage, string>(this, "NewMessage", (sender, arg) =>
            {
                discussionListView.ScrollTo(App.ViewModel.CurrentDiscussion.Last(), ScrollToPosition.End, true);
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            App.CurrentDiscussionPage = null;
            Xamarin.Forms.MessagingCenter.Unsubscribe<DiscussionPage>(this, "NewMessage");
            Xamarin.Forms.MessagingCenter.Unsubscribe<DiscussionPage, string>(this, "NewMessage");
        }

        private void LoadDiscussion()
        {
            BindingContext = App.ViewModel;

            if (App.ViewModel.CurrentDiscussion.Count > 0)
                discussionListView.ScrollTo(App.ViewModel.CurrentDiscussion.Last(), ScrollToPosition.End, true);

            TapGestureRecognizer sendRecognizer = new TapGestureRecognizer();
            sendRecognizer.Tapped += OnSendTapped;
            sendButton.GestureRecognizers.Add(sendRecognizer);
        }

        private async void OnSendTapped(object sender, EventArgs e)
        {
            await Helpers.DiscussionHelper.SendMessageAsync(App.ViewModel.CurrentDiscussion.InDiscussionUser.Id, App.ViewModel.CurrentMessage);
        }

    }
}
