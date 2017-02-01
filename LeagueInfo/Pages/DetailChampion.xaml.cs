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
using LeagueInfo.Resources;
using System.Windows.Documents;

namespace LeagueInfo.Pages
{
    public partial class DetailChampion : PhoneApplicationPage
    {
        private bool carregado = false;

        public DetailChampion()
        {
            InitializeComponent();
            Requester.OnGettingData += Requester_OnGettingData;
        }

        private delegate void ProgressCallBack(bool status);

        private void ProgressBarVisibility(bool status)
        {
            if (status)
                loadProgress.Visibility = Visibility.Visible;
            else
                loadProgress.Visibility = Visibility.Collapsed;
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

        private void AddInfoComponent(List<string> strInfo, StackPanel component)
        {
            foreach (string str in strInfo)
            {
                TextBlock info = new TextBlock();
                info.Text = "\n\t" + Code.HtmlRemoval.StripTagsCharArray(str);
                info.TextWrapping = TextWrapping.Wrap;
                info.FontSize = 22;
                component.Children.Add(info);
            }
        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!carregado)
            {
                ChampionDto champion = new ChampionDto();
                champion = await ChampionDto.SearchChampionAllData(Convert.ToInt32(NavigationContext.QueryString["id"]));
                iconChampion.Source = new BitmapImage(new Uri(champion.SquareChampion, UriKind.RelativeOrAbsolute));
                for (int i = 0; i < champion.Skins.Count; i++)
                    champion.Skins[i].Champion = champion;
                ListBoxSkins.ItemsSource = champion.Skins;
                championName.Text = champion.Name;
                RichTextBox r = new RichTextBox();
                lore.NavigateToString(champion.Lore);
                AddInfoComponent(champion.AllyTips, allytips);
                AddInfoComponent(champion.EnimyTips, enimytips);
                attackInfo.Value = champion.Info.Attack;
                defenseInfo.Value = champion.Info.Defense;
                magicInfo.Value = champion.Info.Magic;
                difficultyInfo.Value = champion.Info.Difficulty;
                abillityChampions.ItemsSource = champion.Spells;
            }
        }
    }
}