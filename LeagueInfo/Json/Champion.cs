using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace LeagueInfo.Json
{
	public class Champion
	{       
        #region ChampionDto
        [JsonProperty("allytips")]
        public List<string> AllyTips { get; set; }

        [JsonProperty("blurb")]
        public string Blurb { get; set; }

        [JsonProperty("enemytips")]
        public List<string> EnimyTips { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("image")]
        public ImageDto Image { get; set; }

        [JsonProperty("info")]
        public InfoDto Info { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lore")]
        public string Lore { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("partype")]
        public string Partype { get; set; }

        [JsonProperty("passive")]
        public PassiveDto Passive { get; set; }

        [JsonProperty("recommended")]
        public List<RecommendedDto> Recommended { get; set; }

        [JsonProperty("skins")]
        public List<SkinDto> Skins { get; set; }

        [JsonProperty("spells")]
        public List<ChampionSpellDto> Spells { get; set; }

        [JsonProperty("stats")]
        public StatsDto Stats { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        #endregion
	}
}
