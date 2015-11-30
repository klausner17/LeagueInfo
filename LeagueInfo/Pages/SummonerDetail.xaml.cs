﻿using System;
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
using LeagueInfo.ClassApi.Request;

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
            try
            {
                string nameSummoner = NavigationContext.QueryString["name"];
                SummonerDto summoner = new SummonerDto();
                LeagueDto leagueSummoner = new LeagueDto();
                summoner = await summoner.SearchSummoner(nameSummoner);
                leagueSummoner = await leagueSummoner.SearchLeague(summoner.Id);
                textBlockNomeInv.Text = summoner.Nome;
                textBlockLevel.Text += summoner.SummonerLevel.ToString();
                if (leagueSummoner.Entries[0].Division != null)
                    textBlockElo.Text = leagueSummoner.Tier + " " + leagueSummoner.Entries[0].Division;
                else
                    textBlockElo.Text = "Unranked";
                textBlockVit.Text = leagueSummoner.Entries[0].Wins > 1 ? leagueSummoner.Entries[0].Wins.ToString() + " vitórias" : leagueSummoner.Entries[0].Wins.ToString() + " vitória";
                textBlockDer.Text = leagueSummoner.Entries[0].Losses > 1 ? leagueSummoner.Entries[0].Losses.ToString() + " derrotas" : leagueSummoner.Entries[0].Losses.ToString() + " derrota";
                imageInvocador.Source = await summoner.GetProfileIcon();
                RecentGamesDto gamesRecent = await new RecentGamesDto().GetLatestGamesById(summoner.Id);
                List<int> lastChampionsPlayed = new List<int>();
                foreach (GameDto game in gamesRecent.Games)
                {
                    lastChampionsPlayed.Add(game.ChampionId);
                    LastMatches controlMatch = new LastMatches(game);
                    controlMatch.Margin = new Thickness(0, 0, 0, 10);
                    controlMatch.Load();
                    listboxPartidas.Items.Add(controlMatch);
                }
                int idChampPref = lastChampionsPlayed[new Random().Next(lastChampionsPlayed.Count - 1)];
                ImageBrush imgBrush = new ImageBrush();
                BitmapImage source = (await new ChampionDto().SearchChampionAllData(idChampPref)).GetChampionSplash(0);
                imgBrush.ImageSource = source;
                imgBrush.Stretch = Stretch.UniformToFill;
                LayoutRoot.Background = imgBrush;
            }
            catch { }
        }
    }
}