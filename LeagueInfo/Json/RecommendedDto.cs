using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.Json
{
    /// <summary>
    /// Esta classe representa as recomendações do campeão.
    /// </summary>
    public class RecommendedDto
    {
        [JsonProperty("blocks")]
        public List<BlocksDto> Blocks { get; set; }

        [JsonProperty("champion")]
        public string Champion { get; set; }

        [JsonProperty("map")]
        public string Map { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
