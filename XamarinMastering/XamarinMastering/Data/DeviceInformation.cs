﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinMastering.Data
{
    public class DeviceInstallation
    {
        public DeviceInstallation()
        {
            Tags = new List<string>();
            Templates = new Dictionary<string, PushTemplate>();
        }

        [JsonProperty(PropertyName = "installationId")]
        public string InstallationId { get; set; }

        [JsonProperty(PropertyName = "platform")]
        public string Platform { get; set; }

        [JsonProperty(PropertyName = "pushChannel")]
        public string PushChannel { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags { get; set; }

        [JsonProperty(PropertyName = "templates")]
        public Dictionary<string, PushTemplate> Templates { get; set; }
    }

    public class PushTemplate
    {
        public PushTemplate()
        {
            Tags = new List<string>();
        }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags { get; set; }
    }

    public class WindowsPushTemplate : PushTemplate
    {
        public WindowsPushTemplate() : base()
        {
            Headers = new Dictionary<string, string>();
        }

        [JsonProperty(PropertyName = "headers")]
        public Dictionary<string, string> Headers { get; set; }
    }
}
 