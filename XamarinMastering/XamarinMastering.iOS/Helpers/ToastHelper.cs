using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;

namespace XamarinMastering.iOS.Helpers
{
    public static  class ToastHelper
    {
        public static void ProcessNotification(NSDictionary userInfo)
        {
            NSDictionary aps = userInfo.ObjectForKey(new NSString("aps")) as NSDictionary;

            string alert = string.Empty;
            if (aps.ContainsKey(new NSString("alert")))
                alert = (aps[new NSString("alert")] as NSString).ToString();
            
           
            if (!string.IsNullOrEmpty(alert))
            {
                UIAlertView avAlert = new UIAlertView("New Favorite added", alert, null, "OK", null);
                avAlert.Show();
            }
        }
    }
}
