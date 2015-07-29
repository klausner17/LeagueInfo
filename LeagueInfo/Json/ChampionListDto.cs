using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LeagueInfo.Json.Request;

namespace LeagueInfo.Json
{
    class ChampionListDto
    {
        [JsonProperty("data")]
        public Dictionary<string, Champion> Data { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("keys")]
        public Dictionary<string, string> Keys { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        public async Task<ChampionListDto> LoadAllChampions()
        {
            string json = await new Requester().GetJson();
            ChampionListDto champions = new ChampionListDto();
            try
            {
                champions = JsonConvert.DeserializeObject<ChampionListDto>(json);
            }
            catch
            {
            }
            return champions;
        }
    }
}
