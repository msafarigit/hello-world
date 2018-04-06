using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinMastering
{
    public class Registration
    {
        string id;
        string installationId;
        string displayName;
        string description;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        [JsonProperty(PropertyName = "description")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [JsonProperty(PropertyName = "installationId")]
        public string InstallationId
        {
            get { return installationId; }
            set { installationId = value; }
        }


        [Version]
        public string Version { get; set; }
    }
}
