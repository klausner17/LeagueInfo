using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace LeagueInfo.Controls
{
    public partial class BuildControl : UserControl
    {
        private LeagueWS.championbuild championBuild;

        public List<int> IdItem0 { get; set; }
        public int IdItem1 { get; set; }
        public int IdItem2 { get; set; }
        public int IdItem3 { get; set; }
        public int IdItem4 { get; set; }
        public int IdItem5 { get; set; }
        public int IdItem6 { get; set; }
        public int IdItem7 { get; set; }

        public String Description
        {
            get { return this.textBlockDescription.Text; }
            set { this.textBlockDescription.Text = value; }
        }

        public int QtdeLike
        {
            get { return Convert.ToInt16(textBlockQtdeGostei.Text); }
            set { this.textBlockQtdeGostei.Text = value.ToString(); }
        }

        public LeagueWS.championbuild ChampionBuild
        {
            get { return championBuild; }
            set
            {
                championBuild = value;
                
            }
        }

        public BuildControl()
        {
            InitializeComponent();
        }

        public BuildControl(LeagueWS.championbuild cb)
        {
            InitializeComponent();
            ChampionBuild = cb;
        }

        
    }
}
