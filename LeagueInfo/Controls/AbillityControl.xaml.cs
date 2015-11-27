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

namespace LeagueInfo.Controls
{
    public partial class Abillity : UserControl
    {
        private ChampionSpellDto spell;
        public ChampionSpellDto Spell
        {
            get { return spell; }
            set
            {
                spell = value;
                this.title.Text = spell.Name;
                this.content.Text = spell.Description;
                LoadIconSpell();
            }
        }
        public Abillity()
        {
            InitializeComponent();
        }

        public Abillity(ChampionSpellDto spell)
        {
            InitializeComponent();
            Spell = spell;
        }

        private async void LoadIconSpell()
        {
            this.iconAbillity.Source = await spell.GetImageSpell();
        }

    }
}
