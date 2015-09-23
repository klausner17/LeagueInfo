using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    public class MetaDataDto
    {
        [JsonProperty("isRune")]
        public bool IsRune { get; set; }

        [JsonProperty("tier")]
        public string Tier { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}