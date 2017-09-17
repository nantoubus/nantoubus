using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Support.V7.App;

namespace Nantou_bus.Droid
{
	[Activity (Label = "Nantou_bus", Icon = "@drawable/busicon", Theme="@style/splashscreen", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
        	protected override void OnCreate (Bundle bundle)
                {
                    TabLayoutResource = Resource.Layout.Tabbar;
                    ToolbarResource = Resource.Layout.Toolbar;

                    base.Window.RequestFeature(WindowFeatures.ActionBar);
                    // Name of the MainActivity theme you had there before.
                    // Or you can use global::Android.Resource.Style.ThemeHoloLight
                    base.SetTheme(Resource.Style.MainTheme);

                    base.OnCreate (bundle);

                    global::Xamarin.Forms.Forms.Init (this, bundle);
                    global::Xamarin.FormsMaps.Init(this, bundle);

                    string dbPath = FileAccessHelper.GetLocalFilePath("ibus_v6.db3");

                    LoadApplication (new Nantou_bus.App ());
                }
                
    }
}

