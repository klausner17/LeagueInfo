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
using LeagueInfo.Json;

namespace LeagueInfo
{
    public partial class MainPage : PhoneApplicationPage
    {
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
                    ItemSelect item = new ItemSelect();
                    item.Title = champion.Name;
                    item.Description = champion.Title;
                    ChampionsList.Children.Add(item);
                }
            }
            catch { }
        }
    }
}