using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    class MiniSeriesDto
    {
        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("progress")]
        public string Progress { get; set; }

        [JsonProperty("target")]
        public int Target { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}
