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
            LeagueDto leagueSummoner = new LeagueDto();
            summoner = await summoner.SearchSummoner(nameSummoner);
            leagueSummoner = await leagueSummoner.SearchLeague(summoner.Id);
            textBlockNomeInv.Text = summoner.Nome;
            textBlockLevel.Text += summoner.SummonerLevel.ToString();
            textBlockElo.Text = leagueSummoner.Tier + " " + leagueSummoner.Entries[0].Division;
            textBlockVit.Text = leagueSummoner.Entries[0].Wins > 1 ? leagueSummoner.Entries[0].Wins.ToString() + " vitórias" : leagueSummoner.Entries[0].Wins.ToString() + " vitória";
            textBlockDer.Text = leagueSummoner.Entries[0].Losses > 1 ? leagueSummoner.Entries[0].Losses.ToString() + " derrotas" : leagueSummoner.Entries[0].Losses.ToString() + " derrota";
            imageInvocador.Source = new BitmapImage(new Uri(@"http://ddragon.leagueoflegends.com/cdn/5.18.1/img/profileicon/" + summoner.ProfileIconId.ToString() + ".png"));
            RecentGamesDto gamesRecent = await new RecentGamesDto().GetLatestGamesById(summoner.Id);
            foreach(GameDto game in gamesRecent.Games)
            {
                LastMatches controlMatch = new LastMatches(game.ChampionId, new List<int>() { game.Stats.Item0, game.Stats.Item1, game.Stats.Item2, game.Stats.Item3, game.Stats.Item4, game.Stats.Item5, game.Stats.Item6 });
                await controlMatch.Load();
                listboxPartidas.Items.Add(controlMatch);
            }
        }
    }
}