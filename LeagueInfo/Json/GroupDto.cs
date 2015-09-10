using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    public class GroupDto
    {
        [JsonProperty("MaxGroupOwnable")]
        public string MaxGroupOwnable { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }
}