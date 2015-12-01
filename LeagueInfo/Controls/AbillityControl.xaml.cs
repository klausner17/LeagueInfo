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
    public partial class ControlAbillity : UserControl
    {
        private ChampionSpellDto spell;

        public ChampionSpellDto Spell
        {
            get { return spell; }
            set
            {
                spell = value;
                this.title.Text = spell.Name;
                this.content.Text = Code.HtmlRemoval.StripTagsCharArray(spell.Description);
                LoadIconSpell();
            }
        }

        public ControlAbillity()
        {
            InitializeComponent();
        }

        public ControlAbillity(ChampionSpellDto spell)
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
