using System.Collections.Generic;
using Xamarin.Forms;

namespace Nantou_bus
{
    public partial class MasterPage : ContentPage
    {
        public ListView MyListView{ get{ return listView;} }

        public MasterPage()
        {
            InitializeComponent();

            List<MasterPageItem> masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "地圖查找",
                Icon = "\uf279"
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "起訖站查詢",
                Icon = "\uf277",
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "路線明細",
                Icon = "\uf124",
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "設定預存位置",
                Icon = "\uf015",
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "最新消息",
                Icon = "\uf1ea",
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "快速聯繫",
                Icon = "\uf2a0",
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "關於我們"
            });

            listView.ItemsSource = masterPageItems;
        }
    }
}