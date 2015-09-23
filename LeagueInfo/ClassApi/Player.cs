using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    class Player
    {
        [JsonProperty("matchHistoryUri")]
        public string MatchHistoryUri { get; set; }

        [JsonProperty("profileIcon")]
        public int ProfileIcon { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }
    }
}
