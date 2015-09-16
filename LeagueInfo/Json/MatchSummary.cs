using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.Json
{
    class MatchSummary
    {
        [JsonProperty("mapId")]
        public int MapId { get; set; }

        [JsonProperty("matchCreation")]
        public int MatchCreation { get; set; }

        [JsonProperty("matchDuration")]
        public int MatchDuration { get; set; }

        [JsonProperty("matchId")]
        public long MatchId { get; set; }

        [JsonProperty("matchMode")]
        public string MatchMode { get; set; }

        [JsonProperty("matchType")]
        public string MatchType { get; set; }


    }
}
