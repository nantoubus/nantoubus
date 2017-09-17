using Xamarin.Forms;

namespace Nantou_bus
{
    public partial class MainPage : MasterDetailPage
    {
        MasterPage MasterPage = new MasterPage();

        public MainPage()
        {
            InitializeComponent();

            this.Master = MasterPage;
            this.Detail = new NavigationPage(new MapPage());

            MasterPage.MyListView.ItemSelected += OnItemSelected;

        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MasterPageItem item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                if (item.Title == "地圖查找")
                {
                    Detail = new NavigationPage(new MapPage());
                    Page Page = this.Master;

                    MasterPage.MyListView.SelectedItem = null;
                    IsPresented = false;
                }
                else if (item.Title == "路線明細")
                {
                    Detail = new NavigationPage(new NumberSearch());
                    Page Page = this.Master;

                    MasterPage.MyListView.SelectedItem = null;
                    IsPresented = false;
                }
                else if (item.Title == "起訖站查詢")
                {
                    Detail = new NavigationPage(new SearchHistory());
                    Page Page = this.Master;

                    MasterPage.MyListView.SelectedItem = null;
                    IsPresented = false;
                }
                else if (item.Title == "設定預存位置")
                {
                    Detail = new NavigationPage(new PreSet());
                    Page Page = this.Master;

                    MasterPage.MyListView.SelectedItem = null;
                    IsPresented = false;
                }
                else if (item.Title == "最新消息")
                {
                    Detail = new NavigationPage(new NewsPage());
                    Page Page = this.Master;

                    MasterPage.MyListView.SelectedItem = null;
                    IsPresented = false;
                }
                else if (item.Title == "快速聯繫")
                {
                    Detail = new NavigationPage(new ContactPage(null));
                    Page Page = this.Master;

                    MasterPage.MyListView.SelectedItem = null;
                    IsPresented = false;
                }
                else if (item.Title == "關於我們")
                {
                    Detail = new NavigationPage(new AboutUsPage());
                    Page Page = this.Master;

                    MasterPage.MyListView.SelectedItem = null;
                    IsPresented = false;
                }
            }
        }
    }
}