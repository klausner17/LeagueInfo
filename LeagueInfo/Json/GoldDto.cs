using Newtonsoft.Json;
namespace LeagueInfo.ClassApi
{
    /// <summary>
    /// This class contain item gold data.
    /// </summary>
    public class GoldDto
    {
        [JsonProperty("base")]
        public int Base { get; set; }

        [JsonProperty("purchasable")]
        public bool Purchasable { get; set; }

        [JsonProperty("sell")]
        public int Sell { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}