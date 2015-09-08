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
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LeagueInfo.Pages
{
    public partial class DetailChampion : PhoneApplicationPage
    {
        public DetailChampion()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            Champion champion = ChampionListDto.AllChampions.Data[NavigationContext.QueryString["key"]];
            BitmapImage backGridInfo = new BitmapImage(new Uri(@"/Assets/champions/Splash/"+ champion.Key+"_Splash_0.png", UriKind.Relative));
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = backGridInfo;
            gridInfo.Background = brush;
            championName.Text = champion.Name;
            TextBlock loreDescription = new TextBlock();
            lore.Text = champion.Lore.Replace("<br>", "\n");
            AddInfoComponent(champion.AllyTips, allytips);
            AddInfoComponent(champion.EnimyTips, enimytips);
        }

        private void AddInfoComponent(List<string> strInfo, StackPanel component)
        {
            foreach (string str in strInfo)
            {
                TextBlock info = new TextBlock();
                info.Text = "\n\t" + str;
                info.TextWrapping = TextWrapping.Wrap;
                info.FontSize = 18;
                component.Children.Add(info);
            }
        }
    }
}