using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    class PlayerDto
    {
        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }
    }
}
