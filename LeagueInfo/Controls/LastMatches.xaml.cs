using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using LeagueInfo.ClassApi;
using System.Windows.Media.Imaging;
using System;
using System.Threading.Tasks;

namespace LeagueInfo.Controls
{
    public partial class LastMatches : UserControl
    {
        private List<int> idItems;
        private long idChampion;

        public LastMatches()
        {
            InitializeComponent();
        }

        public LastMatches(long idChampion, List<int> idItems)
        {
            InitializeComponent();
            this.idItems = idItems;
            this.idChampion = idChampion;
        }


        public async Task Load()
        {
            ChampionDto champion = await new ChampionDto().SearchChampion(idChampion);
            foreach (int idItem in idItems)
            {
                ItemDto item = await new ItemDto().SearchItemByID(idItem);
                Image img = new Image();
                img.Width = 50;
                img.Height = 50;
                img.Source = item.GetImage();
                itemsMatch.Children.Add(img);
            }
            this.imageChampion.Source = champion.GetChampionSquare();
        }
    }
}
