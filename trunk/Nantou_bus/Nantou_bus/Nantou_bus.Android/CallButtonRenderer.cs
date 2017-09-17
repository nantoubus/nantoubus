using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
// using Android.OS;
// using Android.Runtime;
// using Android.Views;
// using Android.Widget;
using Nantou_bus;
using Nantou_bus.UI.View;
using Nantou_bus.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CallButton), typeof(CallButtonRenderer))]
namespace Nantou_bus.Droid
{
    class CallButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                ;
            }

            if (e.NewElement != null)
            {
                Control.Click += delegate {
                    var uri = Android.Net.Uri.Parse("tel:" + Control.Text);
                    var intent = new Intent(Intent.ActionDial, uri);
                    Context.StartActivity(intent);
                };
            }
        }
    }
}