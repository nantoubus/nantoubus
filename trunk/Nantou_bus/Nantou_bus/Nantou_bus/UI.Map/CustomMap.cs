using System.Collections.Generic;

namespace Nantou_bus.UI.Map
{
    public class CustomMap : Xamarin.Forms.Maps.Map
    {
        public List<CustomPin> CustomPins { get; set; }
        public List<CustomCircle> Circles { get; set; }
    }
}
