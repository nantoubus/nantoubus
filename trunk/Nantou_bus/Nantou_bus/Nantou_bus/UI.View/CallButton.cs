using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Nantou_bus.UI.View
{
    public class CallButton : Button
    {
        public CallButton()
        {
            var image = new Image
            {
                Source = "call.png",
                WidthRequest = 40,
                HeightRequest = 40,
            };
            Image = "call2.png";
        }
    }
}
