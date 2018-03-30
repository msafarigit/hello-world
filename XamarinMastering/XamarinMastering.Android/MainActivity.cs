using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XamarinMastering.Droid
{
    /// <summary>
    /// Activity might be one of the single most important concepts in Android development. 
    /// At its simplest, an Activity represents a screen in an application.
    /// And because of Android's application architecture, which doesn't have a single application instance,
    /// an Application is an agreggation of one or more activities.
    /// 
    /// ActivityAttribute: Generates a /manifest/application/activity element within AndroidManifest.xml.
    /// The //activity element is used to declare an activity that implements part of the application's visual user interface. 
    /// The ActivityAttribute custom attribute is used by monodroid.exe when generating AndroidManifest.xml to to declaratively generate //activity elements.
    /// Public Properties:
    /// AllowEmbedded	Boolean.
    /// AllowTaskReparenting Boolean.Whether or not the activity can move from the tasdk that started it to the task it has an affinity for.
    /// AlwaysRetainTaskState Boolean. Whether or not the state of the task that the activity is in will always be maintained by the system.
    /// ClearTaskOnLaunch Boolean. Whether or not all activities will be removed from the task, except for the root activity, whenever it is re-launched from the home screen.
    /// ConfigurationChanges ConfigChanges. The configuration changes that the activity will handle itself.
    /// Enabled Boolean. Whether or not the activity can be instantiated by the system.
    /// ExcludeFromRecents Boolean. Whether or not the activity should be excluded from the list of recently launched activities.
    /// Exported Boolean. Whether or not the activity can be launched by components of other applications.
    /// FinishOnTaskLaunch Boolean. Whether or not an existing instance of the activity should be shut down whenever the user again launches its task.
    /// HardwareAccelerated Boolean.
    /// Icon String. An icon representing the activity.
    /// Label String. A user-readable label for the activity.
    /// LaunchMode LaunchMode. How the activity should be launched.
    /// LayoutDirection LayoutDirection.
    /// MainLauncher Boolean. Whether or not the activity should be the main launcher for an application.
    /// MultiProcess Boolean. Whether an instance of the activity can be launched into the process of the component that started it.
    /// Name String. The name of the class that implements the activity.
    /// NoHistory Boolean.Whether or not the activity should be removed from the activity stack and finished when the user navigates away.
    /// ParentActivity Type.
    /// Permission String. The name of a permission that clients must have to launch the activity.
    /// Process String. The name of the process in which the activity should run.
    /// ScreenOrientation ScreenOrientation. The orientation of the activity's display on the device.
    /// StateNotNeeded Boolean. Whether or not the activity can be killed and successfully restarted without having saved its state.
    /// TaskAffinity String. The task that the activity has an affinity for.
    /// Theme String. A reference to a style resource defining an overall theme for the activity.
    /// UiOptions UiOptions.
    /// WindowSoftInputMode SoftInput. How the main window of the activity interacts with the window containing hte on-screen soft keyboard.
    /// </summary>

    //Default MainLauncher = true, and when create splash screen MainLauncher must be false
    //[Activity(Label = "XamarinMastering", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    //public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    //{
    //    protected override void OnCreate(Bundle bundle)
    //    {
    //        try
    //        {
    //            TabLayoutResource = Resource.Layout.Tabbar;
    //            ToolbarResource = Resource.Layout.Toolbar;
    //            base.OnCreate(bundle);
    //            global::Xamarin.Forms.Forms.Init(this, bundle);
    //            LoadApplication(new App());
    //            //var x = typeof(Xamarin.Forms.Themes.DarkThemeResources);
    //            //x = typeof(Xamarin.Forms.Themes.LightThemeResources);
    //            //x = typeof(Xamarin.Forms.Themes.Android.UnderlineEffect);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw;
    //        }
    //    }
    //}

    //Splash Screen
    [Activity(Label = "XamarinMastering", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;

                base.OnCreate(bundle);

                global::Xamarin.Forms.Forms.Init(this, bundle);

                LoadApplication(new App());

                //var x = typeof(Xamarin.Forms.Themes.DarkThemeResources);
                //x = typeof(Xamarin.Forms.Themes.LightThemeResources);
                //x = typeof(Xamarin.Forms.Themes.Android.UnderlineEffect);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

