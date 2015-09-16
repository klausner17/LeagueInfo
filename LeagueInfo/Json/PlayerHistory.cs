using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueInfo.Json
{
    class PlayerHistory
    {
        [JsonProperty("matches")]
        List<MatchSummary> Matches { get; set; }
    }
}
