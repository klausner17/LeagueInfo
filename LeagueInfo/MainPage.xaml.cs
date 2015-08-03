using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LeagueInfo.Resources;
using LeagueInfo.Json;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Media.Imaging;
using LeagueInfo.Json.Request;
using System.Threading;
using System.Threading.Tasks;

namespace LeagueInfo
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static Champion championSelected = new Champion();
        private delegate void ProgressCallBack(bool status);
		private bool loadedChampions = false;
        private bool loadingChampions = false;

        private void ProgressBarVisibility(bool status)
        {
            if (status)
                loadProgress.Visibility = Visibility.Visible;
            else
                loadProgress.Visibility = Visibility.Collapsed;
        }

        public MainPage()
        {
            InitializeComponent();
            Requester.OnGettingData += Requester_OnGettingData;
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

        private async void PanoramaItem_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if ((!loadedChampions && !loadingChampions) || !loadedChampions)
            {
                ChampionsList.Children.Clear();
                loadingChampions = true;
                ChampionListDto champions = new ChampionListDto();
                champions = await champions.LoadAllChampions();
                try
                {
                    foreach (Champion champion in champions.Data.Values)
                    {
                        ChampionSelected item = new ChampionSelected();
                        item.Champion = champion;
                        item.icon.Source = new BitmapImage(new Uri(@"/Assets/champions/" + champion.Key + "_Square_0.png", UriKind.Relative));
                        item.OnTouch += item_OnTouch;
                        ChampionsList.Children.Add(item);
                        loadedChampions = true;
                        await Task.Delay(50);
                    }
                    loadingChampions = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    loadingChampions = false;
                }
                loadingChampions = false;
            }
        }

        void item_OnTouch(object sender)
        {
            championSelected = (sender as ChampionSelected).Champion;
            NavigationService.Navigate(new Uri("/Pages/DetailChampion.xaml", UriKind.Relative));
        }

    }
}