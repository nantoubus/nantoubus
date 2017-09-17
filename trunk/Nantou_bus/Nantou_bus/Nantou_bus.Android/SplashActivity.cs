using System;
using System.IO;


using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using System.Threading.Tasks;
using Android.Content;

namespace Nantou_bus.Droid
{
    [Activity(Label = "南投客運通", Icon = "@drawable/busicon", Theme = "@style/splashscreen", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }
    }
}