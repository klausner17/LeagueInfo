using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using LeagueInfo.ClassApi;
using System.Windows.Media.Imaging;
using System;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LeagueInfo.Controls
{
    public partial class LastMatches : UserControl
    {
        private GameDto game;

        public LastMatches()
        {
            InitializeComponent();
        }

        public LastMatches(GameDto game)
        {
            InitializeComponent();
            this.game = game;
        }

        public async void Load()
        {
            SolidColorBrush solidColor = new SolidColorBrush();
            solidColor.Color = game.Stats.Win ? Colors.Green : Colors.Red;
            solidColor.Opacity = 0.5;
            LayoutRoot.Background = solidColor;
            textBlockAbates.Text += game.Stats.ChampionsKilled.ToString();
            textBlockMortes.Text += game.Stats.NumDeaths.ToString();
            textBlockAssistencias.Text += game.Stats.Assists.ToString();
            textBlockFarm.Text += game.Stats.MinionsKilled.ToString();
            textBlockOuro.Text += game.Stats.GoldEarned.ToString();
            textBlockTempo.Text += ((int)(game.Stats.TimePlayed / 60)).ToString();
            textBlockModo.Text += game.SubType;
            //ChampionDto champion = await ChampionDto.SearchChampionLowData(game.Champion);
            //this.imageChampion.Source = await champion.GetChampionSquare();
            //List<int> idItems = new List<int>() { game.Stats.Item0, game.Stats.Item1, game.Stats.Item2, game.Stats.Item3, game.Stats.Item4, game.Stats.Item5, game.Stats.Item6 };
            //for (int i = 0; i < 7; i++)
            //{
            //    try
            //    {
            //        if (idItems[i] != 0)
            //        {
            //            ItemDto item = await new ItemDto().SearchItemLowData(idItems[i]);
            //            ImageBrush brush = new ImageBrush();
            //            brush.ImageSource = await item.GetImage();
            //            ((Ellipse)itemsMatch.Children[i]).Fill = brush;
            //        }
            //        else
            //            ((Ellipse)itemsMatch.Children[i]).Stroke = new SolidColorBrush(SystemColors.ActiveBorderColor);
            //    }catch{}
            //}
        }
    }
}
