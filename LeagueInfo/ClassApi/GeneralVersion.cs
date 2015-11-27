using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    /// <summary>
    /// Versões gerais do data dragon referente a versão de itens, campeões, runas, etc.
    /// </summary>
    class GeneralVersion
    {
        [JsonProperty("item")]
        public string Item { get; set; }

        [JsonProperty("rune")]
        public string Rune { get; set; }

        [JsonProperty("mastery")]
        public string Mastery { get; set; }

        [JsonProperty("summoner")]
        public string Summoner { get; set; }

        [JsonProperty("champion")]
        public string Champion { get; set; }

        [JsonProperty("profileicon")]
        public string ProfileIcon { get; set; }

        [JsonProperty("map")]
        public string Map { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }
}
