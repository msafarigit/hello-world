using System;
using System.Collections.Generic;
using System.Text;
using XamarinMastering.Common;

namespace XamarinMastering
{
    public class UserInformation : ObservableBase
    {
        private string _dispalyName;
        public string DisplayName
        {
            get { return _dispalyName; }
            set { this.SetProperty(ref this._dispalyName, value); }
        }

        private string _description;
        public string Description
        {
            get { return this._description; }
            set { this.SetProperty(ref this._description, value); }
        }

        private string _bioContent;
        public string BioContent
        {
            get { return _bioContent; }
            set { this.SetProperty(ref this._bioContent, value); }
        }

        private string _profileImageUrl;
        public string ProfileImageUrl
        {
            get { return _profileImageUrl; }
            set { this.SetProperty(ref this._profileImageUrl, value); }
        }

        private string _installationId;
        public string InstallationId
        {
            get { return this._installationId; }
            set { this.SetProperty(ref this._installationId, value); }
        }
    }
}
