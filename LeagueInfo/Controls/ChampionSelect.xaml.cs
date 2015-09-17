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
using System.Windows.Media.Imaging;

namespace LeagueInfo
{
    public partial class ChampionSelected : UserControl
    {
        private ChampionDto champion;
        private Point coordMouseDown;

        public delegate void OnClick(object sender);

        public event OnClick OnTouch;

        public ChampionDto Champion
        {
            get { return this.champion; }
            set
            {
                this.champion = value;
                this.title.Text = value.Name;
                this.description.Text = value.Title;
                this.tags.Text = string.Empty;
                this.icon.Source = new BitmapImage(new Uri("http://ddragon.leagueoflegends.com/cdn/5.18.1/img/champion/" + champion.Key + ".png"));
                foreach (string tag in value.Tags)
                {
                    switch(tag)
                    {
                        case "Fighter":
                            this.tags.Text += ", lutador";
                            break;
                        case "Support":
                            this.tags.Text += ", suporte";
                            break;
                        case "Tank":
                            this.tags.Text += ", tanque";
                            break;
                        case "Mage":
                            this.tags.Text += ", mago";
                            break;
                        case "Assassin":
                            this.tags.Text += ", assassino";
                            break;
                        case "Marksman":
                            this.tags.Text += ", atirador";
                            break;
                        default:
                            this.tags.Text += ", desconhecido";
                            break;
                    }
                }
                tags.Text = tags.Text.Remove(0, 2);

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
