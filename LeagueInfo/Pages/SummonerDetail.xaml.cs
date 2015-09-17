using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LeagueInfo.Json;
using System.Windows.Media.Imaging;

namespace LeagueInfo.Pages
{
    public partial class SummonerDetail : PhoneApplicationPage
    {
        public SummonerDetail()
        {
            InitializeComponent();
        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string nameSummoner = NavigationContext.QueryString["name"];
            SummonerDto summoner = new SummonerDto();
            summoner = await summoner.SearchSummoner(nameSummoner);
            textBlockNomeInv.Text = summoner.Nome;
            textBlockLevel.Text = summoner.SummonerLevel.ToString();
            imageInvocador.Source = new BitmapImage(new Uri(@"http://ddragon.leagueoflegends.com/cdn/5.18.1/img/profileicon/" + summoner.ProfileIconId.ToString() + ".png"));
        }
    }
}