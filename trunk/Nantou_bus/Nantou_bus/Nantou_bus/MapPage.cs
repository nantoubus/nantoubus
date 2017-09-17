using Nantou_bus.Model;
using Nantou_bus.Repository;
using Nantou_bus.UI.Map;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Nantou_bus
{
    public class MapPage : ContentPage
    {
        private Layout<Xamarin.Forms.View> PageLayout;
        public static LocalDatabase localDatabase;
        public MapPage() : base()
        {
            Title = "地圖查找";
            PageLayout = new StackLayout { Spacing = 10 };
            localDatabase = new LocalDatabase();
            CustomMap customMap = new CustomMap
            {
                MapType = MapType.Street,
                IsShowingUser = true
            };
            PopulateMap(customMap);
            Content = PageLayout;
        }

        private void PopulateMap(CustomMap customMap)
        {
            Position startPosition = new Position(23.949644, 120.934703);

            customMap.CustomPins = new List<CustomPin>();

            IEnumerable<Stop> stops = StopSQLiteRepository.Instance.List();
            IEnumerable<CustomPin> stopsPins = stops.Select(stop => CreateStopPin(stop, customMap));
            foreach (CustomPin pin in stopsPins) { customMap.CustomPins.Add(pin); };
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(startPosition, Distance.FromMiles(0.5)));

            PageLayout.Children.Add(customMap);
        }


        private CustomPin CreateStopPin(Stop stop, CustomMap customMap)
        {
            CustomPinModel customPinModel = new CustomPinModel();
            CustomPin customPin = new CustomPin();
            customPin.Position = new Position(stop.Latitude, stop.Longitude);
            customPin.Label = string.Format("{0}", stop.StopName);
            customPin.InfoTapped += (sender, e) =>
            {
                this.Navigation.PushAsync(new StopDetailsView(stop.Latitude, stop.Longitude, stop.StopID, stop.StopName));
            };
            return customPin;
        }  
    }
}