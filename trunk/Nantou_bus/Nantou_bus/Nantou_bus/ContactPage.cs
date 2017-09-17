using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Nantou_bus.UI.View;
using Nantou_bus.Model.TransportData;

namespace Nantou_bus
{
	public class ContactPage : ContentPage
    {
        private Layout<Xamarin.Forms.View> PageLayout;
        public string ResultAuthority = "";
        public string ResultOperator = "";
        public string NumberAuthority = "";
        ScrollView ResultView = new ScrollView { };
        StackLayout ResultStack = new StackLayout { };
        Dictionary<string, string> IDToOperator = new Dictionary<string, string>
        {
            { "56", "台中客運" }, { "54", "全航客運" },
            { "63", "杉林溪遊樂事業" }, { "46", "花蓮客運" },
            { "64", "南投客運" }, { "61", "員林客運" }, { "45", "國光客運" },
            { "34", "統聯客運" }, { "60", "彰化客運" }, { "53", "總達客運" },
            { "21", "臺西客運" }, { "58", "豐原客運" }, { "62", "豐榮客運" },
        };
        Dictionary<string, string> OperatorToTel = new Dictionary<string, string>
        {
            { "台中客運", "0800-800-126" }, { "全航客運", "04-22129715" },
            { "杉林溪遊樂事業", "049-2611211" }, { "花蓮客運", "0800322816" },
            { "南投客運", "(049)2984-031" }, { "員林客運", "0800-785-688" }, { "國光客運", "0800-010-138" },
            { "統聯客運", "0800-241560" }, { "彰化客運", "04-7225111" }, { "總達客運", "0800-021-258" },
            { "臺西客運", "0800-200079" }, { "豐原客運", "(0800)034175" }, { "豐榮客運", "0800-280-008" },
        };
        Dictionary<string, string> OperatorToAuthority = new Dictionary<string, string>
        {
            { "台中客運", "臺中區監理所" }, { "全航客運", "臺中區監理所" },
            { "杉林溪遊樂事業", "臺中區監理所" }, { "花蓮客運", "臺北區監理所" },
            { "南投客運", "臺中區監理所" }, { "員林客運", "臺中區監理所" }, { "國光客運", "臺北區監理所" },
            { "統聯客運", "臺北區監理所" }, { "彰化客運", "臺中區監理所" }, { "總達客運", "臺中區監理所" },
            { "臺西客運", "嘉義區監理所" }, { "豐原客運", "臺中區監理所" }, { "豐榮客運", "臺中區監理所" },
        };
        public ContactPage() : base()
        {
            Title = "快速聯繫";
            PageLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 10
            };
        }
        public ContactPage(string routeID) : this()
        {
            PopulatePicker(routeID);
            PageLayout.Children.Add(ResultView);
            Content = PageLayout;
        }
        private void PopulatePicker(string routeID)
        {
            Label label01 = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Text = "\n查詢客運之管轄監理單位 : ",
            };
            Picker picker = MakePicker();
            PageLayout.Children.Add(label01);
            PageLayout.Children.Add(picker);
            if (routeID != null)
            {
                IList<BusRoute> Routes = (BusRoute.RetrieveFromJson("http://ptx.transportdata.tw/MOTC/v2/Bus/Route/InterCity/" + routeID + "?$format=JSON"));
                if (Routes.Count > 0)
                {
                    BusRoute Route = Routes[0];
                    List<string> OperatorIDs = Route.OperatorIDs;
                    picker.SelectedItem = IDToOperator[OperatorIDs[0]];
                    ResultStack = new StackLayout { };
                    for (int i = 1; i < OperatorIDs.Count; i++)
                    {
                        ResultOperator = IDToOperator[OperatorIDs[i]];
                        ResultAuthority = OperatorToAuthority[ResultOperator];
                        PopulateResult();
                        PopulateCall();
                    }
                    PageLayout.Children.Add(ResultStack);
                }
            }
        }
        private Picker MakePicker()
        {
            Picker picker = new Picker
            {
                Title = "-- 請選擇客運業者 --    ﹀",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            foreach (string OperatorName in OperatorToAuthority.Keys)
            {
                picker.Items.Add(OperatorName);
            }
            picker.SelectedIndexChanged += (sender, args) =>
            {
                if (picker.SelectedIndex == -1)
                {
                    ResultOperator = "";
                }
                else
                {
                    ResultOperator = picker.Items[picker.SelectedIndex];
                    ResultAuthority = OperatorToAuthority[ResultOperator];
                }
                ResultStack = new StackLayout { };
                PopulateResult();
                PopulateCall();
                ResultView.Content = ResultStack;
            };

            return picker;
        }
        private void PopulateResult()
        {
            Label operatorLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Text = ResultOperator + "：",
            };
            CallButton callOperatorButton = new CallButton
            {
                HorizontalOptions = LayoutOptions.End,
                Text = OperatorToTel[ResultOperator],
            };
            Label resultLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Text = "聯絡電話"
            };
            var image = new Image
            {
                Source = "manager.png",
                WidthRequest = 40,
                HeightRequest = 40,
            };
            var resultStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
            };
            ResultStack.Children.Add(operatorLabel);
            resultStack.Children.Add(image);
            resultStack.Children.Add(resultLabel);
            resultStack.Children.Add(callOperatorButton);
            ResultStack.Children.Add(resultStack);
        }
        private void PopulateCall()
        {
            IEnumerable<Authorities> authorities = Authorities.RetrieveFromJson("http://www.taiwanbus.tw/APP_API/TreeInfo.ashx");
            foreach (Authorities Authority in authorities)
            {
                if (Authority.name == ResultAuthority)
                    NumberAuthority = Authority.tel;
            }
            var image = new Image
            {
                Source = "manager.png",
                WidthRequest = 40,
                HeightRequest = 40,
            };
            Label authorityLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Text = ResultAuthority + "",
            };
            CallButton callAuthorityButton = new CallButton
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = NumberAuthority,
            };
            var callStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Start,
            };
            callStack.Children.Add(image);
            callStack.Children.Add(authorityLabel);
            callStack.Children.Add(callAuthorityButton);
            ResultStack.Children.Add(callStack);
        }
    }
}