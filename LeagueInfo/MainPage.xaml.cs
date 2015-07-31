﻿using System;
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

namespace LeagueInfo
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static Champion championSelected = new Champion();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void PanoramaItem_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ChampionListDto champions =  new ChampionListDto();
            champions =  await champions.LoadAllChampions();
            try
            {
                foreach (Champion champion in champions.Data.Values)
                {
                    ChampionSelected item = new ChampionSelected();
                    item.Champion = champion;
                    item.OnTouch += item_OnTouch;
                    ChampionsList.Children.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void item_OnTouch(object sender)
        {
            championSelected = (sender as ChampionSelected).Champion;
            NavigationService.Navigate(new Uri("/Pages/DetailChampion.xaml", UriKind.Relative));
        }

    }
}