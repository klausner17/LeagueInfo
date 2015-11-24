﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LeagueInfo.ClassApi;
using System.Windows.Media.Imaging;

namespace LeagueInfo.Controls
{
    public partial class CounterControl : UserControl
    {
        private ChampionDto champion;

        public ChampionDto Champion
        {
            get { return champion; }
            set
            {
                champion = value;
                textBlockChampionName.Text = champion.Name;
                imageSquareChampion.Source = champion.GetChampionSquare();
            }
        }

        public Boolean IsSelected{get;set;}

        public Boolean CanSelect { get; set; }

        public CounterControl()
        {
            InitializeComponent();
        }

        public CounterControl(ChampionDto champion, Boolean canSelect, Boolean isSelected)
        {
            InitializeComponent();
            Champion = champion;
            CanSelect = canSelect;
            if(canSelect)
                IsSelected = IsSelected;
        }

        private void UserControl_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (CanSelect)
            {
                if (IsSelected)
                {
                    IsSelected = false;
                    Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    IsSelected = true;
                    Visibility = System.Windows.Visibility.Collapsed;
                }
            }
        }
    }
}
