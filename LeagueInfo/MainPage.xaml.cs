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
        ChampionListDto listChampions;
        public MainPage()
        {
            InitializeComponent();
        }

        private  void PanoramaItem_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ChampionListDto champions =  new ChampionListDto();
            champions =  champions.LoadAllChampions();
            try
            {
                foreach (Champion champion in champions.Data.Values)
                {
                    TextBlock text = new TextBlock();
                    text.Text = champion.Name;
                    ChampionsList.Children.Add(text);
                }
            }
            catch { }
        }
    }
}