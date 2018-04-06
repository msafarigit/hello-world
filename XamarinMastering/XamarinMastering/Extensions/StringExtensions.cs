using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinMastering
{
    public static class StringExtensions
    {
        public static List<string> ToStringList(this JArray array)
        {
            List<string> list = new List<string>();
            foreach(var a in array)
                list.Add(((JValue)a).Value.ToString());

            return list;
        }

        public static JArray ToJArray(this List<string> list)
        {
            JArray array = new JArray();
            foreach (var l in list)
                array.Add(l);

            return array;
        }
    }
}
