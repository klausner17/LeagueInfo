using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueInfo.Json
{
    class ChampionListDto
    {
        [JsonProperty("data")]
        public Dictionary<string, Champion> Data { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("keys")]
        public Dictionary<string, string> Keys { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
