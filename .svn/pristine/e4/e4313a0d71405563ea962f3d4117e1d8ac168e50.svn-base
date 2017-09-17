using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nantou_bus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreSet : ContentPage
    {
        public PreSet()
        {
            InitializeComponent();

            //顯示住家
            var HomeHistory = MapPage.localDatabase.GetItems();
            if (HomeHistory.Count() > 0)
            {
                var HomeHistory2 = MapPage.localDatabase.GetItems().Last();
                HomeEntry.Text = $"{HomeHistory2.HomeRecord} ";
            }
            else
            {
                HomeEntry.Text = "尚未設定站牌 ";
            }

            //顯示公司
            var OfficeHistory = MapPage.localDatabase.GetItemsO();
            if (OfficeHistory.Count() > 0)
            {
                var OfficeHistory2 = MapPage.localDatabase.GetItemsO().Last();
                OfficeEntry.Text = $"{OfficeHistory2.Office} ";
            }
            else
            {
                OfficeEntry.Text = "尚未設定站牌 ";
            }


            //顯示學校
            var SchoolHistory = MapPage.localDatabase.GetItemsS();
            if (SchoolHistory.Count() > 0)
            {
                var SchoolHistory2 = MapPage.localDatabase.GetItemsS().Last();
                SchoolEntry.Text = $"{SchoolHistory2.School} ";

            }
            else
            {
                SchoolEntry.Text = "尚未設定站牌 ";
            }
        }

        //設住家
        public void HomeButton_Clicked(object sender, EventArgs e)
        {
            if (HomeEntry.Text == null)
            {
                DisplayAlert("系統提醒", "請輸入站牌名稱", "重新輸入");
            }
            else
            {
                MapPage.localDatabase.SaveItem(new MyRecord
                {
                    HomeRecord = HomeEntry.Text,
                });

                DisplayAlert("系統提醒", "設定成功", "確定");
            }
        }

        //設公司
        public void OfficeButton_Clicked(object sender, EventArgs e)
        {
            if (HomeEntry.Text == null)
            {
                DisplayAlert("系統提醒", "請輸入站牌名稱", "重新輸入");
            }
            else
            {
                MapPage.localDatabase.SaveItemO(new OfficeRecord
                {
                    Office = OfficeEntry.Text,
                });

                DisplayAlert("系統提醒", "設定成功", "確定");
            }
        }

        //設學校
        public void SchoolButton_Clicked(object sender, EventArgs e)
        {
            if (SchoolEntry.Text == null)
            {
                DisplayAlert("系統提醒", "請輸入站牌名稱", "重新輸入");
            }
            else
            {
                MapPage.localDatabase.SaveItemS(new SchoolRecord
                {
                    School = SchoolEntry.Text,
                });

                DisplayAlert("系統提醒", "設定成功", "確定");
            }

        }
    }
}