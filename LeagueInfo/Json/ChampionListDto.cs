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
        const String URLALLCHAMPS = @"https://global.api.pvp.net/api/lol/static-data/br/v1.2/champion?champData=all&api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33";

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
            string json = await new Requester(URLALLCHAMPS).GetJson();
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
