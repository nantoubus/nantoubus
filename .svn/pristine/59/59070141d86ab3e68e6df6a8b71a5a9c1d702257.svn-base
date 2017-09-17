using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Nantou_bus.Model.TransportData;
using Nantou_bus.Repository;
using Nantou_bus.Model;

namespace Nantou_bus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchHistory : ContentPage

    {
        public SearchHistory()
        {
            InitializeComponent();
            mainstack.Children.Add(scroll);
        }
        ScrollView scroll = new ScrollView { };

        String History1;
        String History2;
        String History3;
        int x;
        List<string> stops = new List<string>();
        private async void SearchH_Clicked(object sender, EventArgs e)
        {
            var localHistory2 = MapPage.localDatabase.GetItemsH();
            var localHistory = MapPage.localDatabase.GetItemsH().LastOrDefault();

            if (localHistory2.Count() >= 1)
            {
                x = localHistory.ID;
            }

            if (x >= 3)
            {
                History1 = $"{localHistory.HistoryRecord} ";
                localHistory = MapPage.localDatabase.GetItemH(x - 1);
                History2 = $"{localHistory.HistoryRecord}";
                localHistory = MapPage.localDatabase.GetItemH(x - 2);
                History3 = $"{localHistory.HistoryRecord}";
            }
            else
            {
                History1 = "暫無查詢記錄1";
                History2 = "暫無查詢記錄2";
                History3 = "暫無查詢記錄3";
            }
            var action = await DisplayActionSheet("查詢記錄-起站", "Cancel", null, History1, History2, History3);
            if (action == History1)
            {
                StartRouteSearchBar.Text = History1;
            }
            else if (action == History2)
            {
                StartRouteSearchBar.Text = History2;
            }
            else if (action == History3)
            {
                StartRouteSearchBar.Text = History3;
            }
        }

        private async void SearchF_Clicked(object sender, EventArgs e)
        {
            var Home = MapPage.localDatabase.GetItems();
            var Home2 = MapPage.localDatabase.GetItems().LastOrDefault();
            var Office = MapPage.localDatabase.GetItemsO();
            var Office2 = MapPage.localDatabase.GetItemsO().LastOrDefault();
            var School = MapPage.localDatabase.GetItemsS();
            var School2 = MapPage.localDatabase.GetItemsS().LastOrDefault();


            if (Home.Count() >= 1)
            {
                History1 = $"{Home2.HomeRecord} ";
            }
            else
            {
                History1 = "尚未設定住家喜好站牌";
            }

            if (Office.Count() >= 1)
            {
                History2 = $"{Office2.Office} ";
            }
            else
            {
                History2 = "尚未設定公司喜好站牌";
            }

            if (School.Count() >= 1)
            {
                History3 = $"{School2.School} ";
            }
            else
            {
                History3 = "尚未設定住家喜好站牌";
            }

            var action = await DisplayActionSheet("預存位置-起站", "Cancel", null, History1, History2, History3);
            if (action == History1) { StartRouteSearchBar.Text = History1; }
            if (action == History2) { StartRouteSearchBar.Text = History2; }
            if (action == History3) { StartRouteSearchBar.Text = History3; }
        
        }


        private async void SearchH2_Clicked(object sender, EventArgs e)
        {
            var localHistory2 = MapPage.localDatabase.GetItemsH();
            var localHistory = MapPage.localDatabase.GetItemsH().LastOrDefault();

            if (localHistory2.Count() >= 1)
            {
                x = localHistory.ID;
            }

            if (x >= 3)
            {
                History1 = $"{localHistory.HistoryRecord} ";
                localHistory = MapPage.localDatabase.GetItemH(x - 1);
                History2 = $"{localHistory.HistoryRecord}";
                localHistory = MapPage.localDatabase.GetItemH(x - 2);
                History3 = $"{localHistory.HistoryRecord}";
            }
            else
            {
                History1 = "暫無查詢記錄1";
                History2 = "暫無查詢記錄2";
                History3 = "暫無查詢記錄3";
            }

            var action = await DisplayActionSheet("查詢記錄-訖站", "Cancel", null, History1, History2, History3);
            if (action == History1) { ReachRouteSearchBar.Text = History1; }
            if (action == History2) { ReachRouteSearchBar.Text = History2; }
            if (action == History3) { ReachRouteSearchBar.Text = History3; }
        }

        private async void SearchF2_Clicked(object sender, EventArgs e)
        {
            //scroll.clear();
            var Home = MapPage.localDatabase.GetItems();
            var Home2 = MapPage.localDatabase.GetItems().LastOrDefault();
            var Office = MapPage.localDatabase.GetItemsO();
            var Office2 = MapPage.localDatabase.GetItemsO().LastOrDefault();
            var School = MapPage.localDatabase.GetItemsS();
            var School2 = MapPage.localDatabase.GetItemsS().LastOrDefault();


            if (Home.Count() >= 1)
            {
                History1 =  $"{Home2.HomeRecord} ";
            }
            else
            {
                History1 = "尚未設定住家喜好站牌";
            }

            if (Office.Count() >= 1)
            {
                History2 =  $"{Office2.Office} ";
            }
            else
            {
                History2 = "尚未設定公司喜好站牌";
            }

            if (School.Count() >= 1)
            {
                History3 =  $"{School2.School} ";
            }
            else
            {
                History3 = "尚未設定住家喜好站牌";
            }

            var action = await DisplayActionSheet("預存位置-訖站", "Cancel", null, History1, History2, History3);
            if (action == History1) { ReachRouteSearchBar.Text = History1; }
            if (action == History2) { ReachRouteSearchBar.Text = History2; }
            if (action == History3) { ReachRouteSearchBar.Text = History3; }
        }

        private void SearchNOW_Clicked(object sender, EventArgs e)
        {
            MapPage.localDatabase.SaveItemH(new History
            {
                HistoryRecord = StartRouteSearchBar.Text,
            });

            MapPage.localDatabase.SaveItemH(new History
            {
                HistoryRecord = ReachRouteSearchBar.Text,
            });

            var stack = new StackLayout();

            IEnumerable<Stop> stops = StopSQLiteRepository.Instance.Get(StartRouteSearchBar.Text);
            List<string> stopuid1 = new List<string>();
            foreach (Stop stop in stops)
            {
                stopuid1.Add(stop.StopID);
            }

            IEnumerable<Stop> stops2 = StopSQLiteRepository.Instance.Get(ReachRouteSearchBar.Text);
            List<string> stopuid2 = new List<string>();
            foreach (Stop stop in stops2)
            {
                stopuid2.Add(stop.StopID);
            }

            if (stopuid1.Count <= 0 || stopuid2.Count <= 0)
            { 
                DisplayAlert("提醒", "查無此站牌", "重新輸入");
                stopuid1.Clear();
                stopuid2.Clear();
                StartRouteSearchBar.Text = "";
                ReachRouteSearchBar.Text = "";
            }

            List<string> routeuid1 = new List<string>();
            List<string> routeuid2 = new List<string>();
            List<string> temp_result = new List<string>();
            for (int i = 0; i < stopuid1.Count; i++)
            {
                IEnumerable<StopOnRoute> RouteUID = StopOnRouteSQLiteRepository.Instance.Retrieve(stopuid1[i]);
                foreach (StopOnRoute routeuid in RouteUID)
                {
                    routeuid1.Add(routeuid.RouteUID);
                }

            }

            for (int j = 0; j < stopuid2.Count; j++)
            {
                 IEnumerable<StopOnRoute> RouteUID2 = StopOnRouteSQLiteRepository.Instance.Retrieve(stopuid2[j]);
                foreach (StopOnRoute routeuidd in RouteUID2)
                {
                    routeuid2.Add(routeuidd.RouteUID);
                }
            }

            for (int k = 0; k < routeuid1.Count; k++)
            {
                for (int l = 0; l < routeuid2.Count; l++)
                {
                    if (routeuid1[k] == routeuid2[l])
                    {
                        temp_result.Add(routeuid2[l]);
                    }
                }
            }


            int y = temp_result.Count;
            for (int i = 0; i < y; i++)
            {
                for (int j = i + 1; j < y; j++)
                {
                    if (temp_result[i] == temp_result[j])
                    {
                        temp_result.Remove(temp_result[j]);
                        j--;
                        y--;
                    }

                }
            }
            for (int i = 0; i < temp_result.Count; i++)
            {


                IEnumerable<Route> BusInfo  = RouteSQLiteRepository.Instance.Retrieve(temp_result[i]);
                foreach (Route businfo in BusInfo)
                {
                    String RouteID2 = businfo.Number;
                    String Headsign = businfo.HeadSign;

                    Button label = new Button();
                    label.Text = RouteID2 + " " + Headsign;
                    String SubRouteUID = businfo.UID.ToString();   
                    String SubRouteName = businfo.Name.En.ToString();   
                    String SubBouteHead = businfo.HeadSign.ToString();
                    RouteView.RouteViewConfig Config = new RouteView.RouteViewConfig(RouteID2, SubRouteUID, SubRouteName, SubBouteHead, null);
                    label.Clicked += (object sender2, EventArgs e2) => { this.Navigation.PushAsync(new RouteView(Config)); };
                    stack.Children.Add(label);
                }

                
            }
            temp_result.Clear();
            stopuid1.Clear();
            stopuid2.Clear();
            routeuid1.Clear();
            routeuid2.Clear();
            scroll.Content= stack;
            

        }

    }
}