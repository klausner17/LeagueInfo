using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    public class SpellVarsData
    {
        [JsonProperty("coeff")]
        public List<double> Coeff { get; set; }

        [JsonProperty("dyn")]
        public string Dyn { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("ranksWith")]
        public string RanksWith { get; set; }
    }
}
