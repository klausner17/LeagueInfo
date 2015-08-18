using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeagueInfo.Json
{
    public class ItemTreeDto
    {
        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}