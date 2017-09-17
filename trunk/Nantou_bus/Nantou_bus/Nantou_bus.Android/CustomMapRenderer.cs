using System;
using System.Collections.Generic;
using System.ComponentModel;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Widget;
using Nantou_bus.UI.Map;
using Nantou_bus.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace Nantou_bus.Droid
{
    public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter, IOnMapReadyCallback
    {
        GoogleMap map;
        List<CustomPin> customPins;
        bool isDrawn;
        CustomMap formsMap;

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                map.InfoWindowClick -= OnInfoWindowClick;
            }

            if (e.NewElement != null)
            {
                formsMap = (CustomMap)e.NewElement;
                customPins = formsMap.CustomPins;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals("VisibleRegion") && !isDrawn)
            {
                map.Clear();
                foreach (CustomPin customPin in customPins)
                {
                    MarkerOptions marker = new MarkerOptions();
                    marker.SetPosition(new LatLng(customPin.Position.Latitude, customPin.Position.Longitude));
                    marker.SetTitle(customPin.Label);
                    marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.newpin));
                    map.AddMarker(marker);
                }
                isDrawn = true;
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            if (changed)
            {
                isDrawn = false;
            }
        }

        public void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            CustomPin customPin = GetCustomPin(e.Marker);
            if (customPin == null)
            {
                throw new Exception("Custom pin not found");
            }
            customPin.OnInfoTapped(e);
        }

        void IOnMapReadyCallback.OnMapReady(GoogleMap googleMap)
        {
            InvokeOnMapReadyBaseClassHack(googleMap);
            map = googleMap;
            map.SetInfoWindowAdapter(this);
            map.InfoWindowClick += OnInfoWindowClick;
            map.UiSettings.ZoomControlsEnabled = Map.HasZoomEnabled;
            map.UiSettings.ZoomGesturesEnabled = Map.HasZoomEnabled;
            map.UiSettings.ScrollGesturesEnabled = Map.HasScrollEnabled;
        }

        public Android.Views.View GetInfoContents(Marker marker)
        {
            Android.Views.LayoutInflater inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;

            if (inflater != null)
            {
                Android.Views.View view;

                CustomPin customPin = GetCustomPin(marker);
                if (customPin == null)
                {
                    throw new Exception("Custom pin not found");
                }

                view = inflater.Inflate(Resource.Layout.MapInfoWindow, null);

                TextView infoTitle = view.FindViewById<TextView>(Resource.Id.InfoWindowTitle);
                TextView infoSubtitle = view.FindViewById<TextView>(Resource.Id.InfoWindowSubtitle);

                if (infoTitle != null)
                {
                    infoTitle.Text = marker.Title;
                }
                if (infoSubtitle != null)
                {
                    infoSubtitle.Text = marker.Snippet;
                }

                return view;
            }
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }

        public CustomPin GetCustomPin(Marker annotation)
        {
            Position position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);
            foreach (CustomPin pin in customPins)
            {
                if (pin.Position == position)
                {
                    return pin;
                }
            }
            return null;
        }

        public void InvokeOnMapReadyBaseClassHack(GoogleMap googleMap)
        {
            System.Reflection.MethodInfo onMapReadyMethodInfo = null;

            Type baseType = typeof(MapRenderer);
            foreach (System.Reflection.MethodInfo currentMethod in baseType.GetMethods(System.Reflection.BindingFlags.NonPublic |
                                                             System.Reflection.BindingFlags.Instance |
                                                              System.Reflection.BindingFlags.DeclaredOnly))
            {
                if (currentMethod.IsFinal && currentMethod.IsPrivate)
                {
                    if (string.Equals(currentMethod.Name, "OnMapReady", StringComparison.Ordinal))
                    {
                        onMapReadyMethodInfo = currentMethod;
                        break;
                    }

                    if (currentMethod.Name.EndsWith(".OnMapReady", StringComparison.Ordinal))
                    {
                        onMapReadyMethodInfo = currentMethod;
                        break;
                    }
                }
            }

            if (onMapReadyMethodInfo != null)
            {
                onMapReadyMethodInfo.Invoke(this, new[] { googleMap });
            }
        }
    }
}