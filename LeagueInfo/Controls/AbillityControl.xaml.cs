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
                this.content.Inlines.Add(spell.Description);
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

        //private TextBlock TootTipTratado(string toolTip)
        //{
        //    TextBlock contentTratado = new TextBlock();
        //    //pegar span
            
        //}
    }
}
