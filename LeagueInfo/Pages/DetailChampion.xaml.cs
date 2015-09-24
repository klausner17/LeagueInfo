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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LeagueInfo.Controls;
using LeagueInfo.ClassApi;

namespace LeagueInfo.Pages
{
    public partial class DetailChampion : PhoneApplicationPage
    {
        public DetailChampion()
        {
            InitializeComponent();
        }

        private void AddInfoComponent(List<string> strInfo, StackPanel component)
        {
            foreach (string str in strInfo)
            {
                TextBlock info = new TextBlock();
                info.Text = "\n\t" + str;
                info.TextWrapping = TextWrapping.Wrap;
                info.FontSize = 22;
                component.Children.Add(info);
            }
        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            ChampionDto champion = new ChampionDto();
            champion = await champion.SearchChampionAllData(Convert.ToInt32(NavigationContext.QueryString["id"]));
            Random randNumSkin = new Random();
            int num = randNumSkin.Next(champion.Skins.Count);
            BitmapImage backGridInfo = champion.GetChampionSplash(num);
            ImageBrush brush = new ImageBrush();
            brush.Stretch = Stretch.UniformToFill;
            brush.ImageSource = backGridInfo;
            panorama.Background = brush;
            championName.Text = champion.Name;
            TextBlock loreDescription = new TextBlock();
            lore.Text = champion.Lore.Replace("<br>", "\n");
            AddInfoComponent(champion.AllyTips, allytips);
            AddInfoComponent(champion.EnimyTips, enimytips);
            attackInfo.Value = champion.Info.Attack;
            defenseInfo.Value = champion.Info.Defense;
            magicInfo.Value = champion.Info.Magic;
            difficultyInfo.Value = champion.Info.Difficulty;
            //incluir habilidades
            foreach (ChampionSpellDto spell in champion.Spells)
            {
                Abillity controlAbillity = new Abillity(spell);
                abillityChampions.Children.Add(controlAbillity);
            }
        }
    }
}