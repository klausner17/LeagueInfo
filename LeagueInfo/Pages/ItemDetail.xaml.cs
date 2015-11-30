using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LeagueInfo.ClassApi.Request;
using LeagueInfo.ClassApi;

namespace LeagueInfo.Pages
{
    public partial class ItemDetail : PhoneApplicationPage
    {

        public ItemDetail()
        {
            InitializeComponent();
            Requester.OnGettingData += Requester_OnGettingData;
        }

        private delegate void ProgressCallBack(bool status);

        private void ProgressBarVisibility(bool status)
        {
            if (status)
                loadProgress.Visibility = Visibility.Visible;
            else
                loadProgress.Visibility = Visibility.Collapsed;
        }

        void Requester_OnGettingData(int status)
        {
            switch (status)
            {
                case Requester.BEGINDOWNLOAD:
                    ProgressBarVisibility(true);
                    break;
                case Requester.ENDDOWNLOAD:
                    ProgressBarVisibility(false);
                    break;
            }
        }

        private async void pageItemDetail_Loaded(object sender, RoutedEventArgs e)
        {
            ItemDto item = await new ItemDto().SearchItemByIDAllData(Convert.ToInt16(NavigationContext.QueryString["id"]));
            imageItem.Source = await item.GetImage();
            textBlockNameItem.Text = item.Name;
            textBlockGoldItem.Text = item.Gold.Total.ToString() + " gold";
            textBlockItemEffect.Text = item.SanitizedDescriprion;
        }
    }
}