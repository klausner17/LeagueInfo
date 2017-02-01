using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LeagueInfo.ClassApi;
using System.Windows.Media.Imaging;
using LeagueInfo.Controls;
using System.Windows.Media;

namespace LeagueInfo.Pages
{
    public partial class SummonerDetail : PhoneApplicationPage
    {
        private void ProgressBarVisibility(bool status)
        {
            if (status)
                loadProgress.Visibility = Visibility.Visible;
            else
                loadProgress.Visibility = Visibility.Collapsed;
        }

        public SummonerDetail()
        {
            InitializeComponent();
            Requester.OnGettingData += Requester_OnGettingData;
        }

        private void Requester_OnGettingData(int status)
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

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string nameSummoner = NavigationContext.QueryString["name"];
            SummonerDto summoner = new SummonerDto();
            try
            {
                summoner = await summoner.SearchSummoner(nameSummoner);
                textBlockNomeInv.Text = summoner.Nome;
            }
            catch
            {
                MessageBox.Show("Não existe um invocador com esse nome.");
                NavigationService.GoBack();
                return;
            }
            textBlockLevel.Text += summoner.SummonerLevel.ToString();
            try
            {
                LeagueDto leagueSummoner = new LeagueDto();
                leagueSummoner = await leagueSummoner.SearchLeague(summoner.Id);
                textBlockElo.Text = leagueSummoner.Tier + " " + leagueSummoner.Entries[0].Division;
                textBlockVit.Text = leagueSummoner.Entries[0].Wins > 1 ? leagueSummoner.Entries[0].Wins.ToString() + " vitórias" : leagueSummoner.Entries[0].Wins.ToString() + " vitória";
                textBlockDer.Text = leagueSummoner.Entries[0].Losses > 1 ? leagueSummoner.Entries[0].Losses.ToString() + " derrotas" : leagueSummoner.Entries[0].Losses.ToString() + " derrota";
            }
            catch
            {
                MessageBox.Show("Informações de derrotas e vitórias são apenas para jogadores ranqueados.", "Informação", MessageBoxButton.OK);
                textBlockElo.Text = "Unranked";
                textBlockVit.Text = "0 vitória";
                textBlockDer.Text = "0 derrota";
            }
            imageInvocador.Source = await summoner.GetProfileIcon();
            listboxPartidas.ItemsSource = (await new RecentGamesDto().GetLatestGamesById(summoner.Id)).Games;
        }
    }
}