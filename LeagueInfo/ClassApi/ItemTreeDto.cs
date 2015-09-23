using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeagueInfo.ClassApi
{
    public class ItemTreeDto
    {
        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}