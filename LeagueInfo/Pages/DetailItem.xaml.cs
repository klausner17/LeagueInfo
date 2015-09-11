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
    public partial class DetailItem : PhoneApplicationPage
    {
        public DetailItem()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            ItemDto item = MainPage.ItemSelected;
            itemName.Text = item.Name;
            description.Text = item.Description;
        }
    }
}