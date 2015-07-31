using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

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
            championName.Text = MainPage.championSelected.Name;
            TextBlock loreDescription = new TextBlock();
            lore.Text = MainPage.championSelected.Lore.Replace("<br>", "\n");
        }
    }
}