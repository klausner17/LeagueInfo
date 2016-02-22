using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace LeagueInfo.ClassApi
{
    public class ChampionTag
    {
        public string Description { get; set; }
        public SolidColorBrush Background { get; set; }

        public ChampionTag(string description, SolidColorBrush background)
        {
            Description = description;
            Background = background;
        }
    }
}
