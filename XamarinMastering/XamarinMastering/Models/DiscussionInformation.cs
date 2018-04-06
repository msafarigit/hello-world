using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinMastering
{
    public class DiscussionCollection : ObservableCollection<DiscussionInformation>
    {
        public Registration InDiscussionUser { get; set; }

        public void AddEntry(DiscussionInformation discussion)
        {
            this.Add(discussion);
        }
    }

    public class DiscussionInformation : Common.ObservableBase
    {
        private string _senderId;
        public string SenderId
        {
            get { return this._senderId; }
            set { this.SetProperty(ref this._senderId, value); }
        }

        private string _receiverId;
        public string ReceiverId
        {
            get { return this._receiverId; }
            set { this.SetProperty(ref this._receiverId, value); }
        }

        private string _content;
        public string Content
        {
            get { return this._content; }
            set { this.SetProperty(ref this._content, value); }
        }

        private DateTime _timestamp;
        public DateTime Timestamp
        {
            get { return this._timestamp; }
            set { this.SetProperty(ref this._timestamp, value); }
        }
    }
}
