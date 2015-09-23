using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using LeagueInfo.ClassApi;
using System.Windows.Media.Imaging;
using System;

namespace LeagueInfo.Controls
{
    public partial class LastMatches : UserControl
    {
        private List<int> idItems;
        private int idChampion;

        public LastMatches()
        {
            InitializeComponent();
        }

        public LastMatches(int idChampion, List<int> idItems)
        {
            InitializeComponent();
            this.idItems = idItems;
            this.idChampion = idChampion;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ChampionDto champion = await new ChampionDto().SearchChampion(idChampion);
            foreach(int idItem in idItems)
            {
                ItemDto item = await new ItemDto().SearchItemByID(idItem);
                Image img = new Image();
                img.Source = new BitmapImage(new Uri("http://ddragon.leagueoflegends.com/cdn/5.18.1/img/item/" + item.Image.Full));
                itemsMatch.Items.Add(img);
            }
            this.imageChampion.Source =new BitmapImage(new Uri("http://ddragon.leagueoflegends.com/cdn/5.18.1/img/champion/" + champion.Key + ".png"));
        }
    }
}
