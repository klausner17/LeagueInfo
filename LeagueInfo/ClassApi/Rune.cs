using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    class Rune
    {
        [JsonProperty("rank")]
        public long Rank { get; set; }

        [JsonProperty("runeId")]
        public long RuneId { get; set; }
    }
}
