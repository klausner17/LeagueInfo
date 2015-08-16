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
            Champion champion = MainPage.championSelected;
            championName.Text = champion.Name;
            TextBlock loreDescription = new TextBlock();
            lore.Text = champion.Lore.Replace("<br>", "\n");
            foreach (string strAlly in champion.AllyTips)
            {
                TextBlock tipAlly = new TextBlock();
                tipAlly.TextWrapping = TextWrapping.Wrap;
                tipAlly.FontSize = 18;
                tipAlly.Text = "\n\t" + strAlly;
                allytips.Children.Add(tipAlly);
            }
            foreach (string strEnemy in champion.EnimyTips)
            {
                TextBlock tipEnimy = new TextBlock();
                tipEnimy.TextWrapping = TextWrapping.Wrap;
                tipEnimy.FontSize = 18;
                tipEnimy.Text = "\n\t" + strEnemy;
                enimytips.Children.Add(tipEnimy);
            }
        }

        private void AddInfoComponent(List<string> strInfo, StackPanel component)
        {
            foreach (string str in strInfo)
            {
                TextBlock info = new TextBlock();
                info.Text = "\n\t" + str;
                info.TextWrapping = TextWrapping.Wrap;
                info.FontSize = 168;
                component.Children.Add(info);
            }
        }
    }
}