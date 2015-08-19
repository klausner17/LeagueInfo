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

namespace LeagueInfo
{
    public partial class ChampionSelected : UserControl
    {
        private Champion champion;
        private Point coordMouseDown;

        public delegate void OnClick(object sender);

        public event OnClick OnTouch;

        public Champion Champion
        {
            get { return this.champion; }
            set
            {
                this.champion = value;
                this.title.Text = value.Name;
            }
        }

        public Image Icon
        {
            get { return this.icon; }
            set { this.icon = value; }
        }

        public ChampionSelected()
        {
            InitializeComponent();
        }

        private void userControl_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            coordMouseDown = e.GetPosition(userControl); 
        }

        private void userControl_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point finalPosition = e.GetPosition(userControl);
            if (finalPosition == coordMouseDown)
                OnTouchEvent();
        }

        private void OnTouchEvent()
        {
            if (OnTouch != null)
                OnTouch(this);
        }
    }
}
