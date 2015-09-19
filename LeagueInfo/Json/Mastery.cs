using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.Json
{
    class Mastery
    {
        [JsonProperty("masteryId")]
        public long MasteryId { get; set; }

        [JsonProperty("rank")]
        public long Rank { get; set; }
    }
}
