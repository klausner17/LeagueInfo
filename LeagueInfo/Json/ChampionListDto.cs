using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LeagueInfo.ClassApi.Request;
using System.IO;

namespace LeagueInfo.ClassApi
{
    class ChampionListDto
    {
        const String URLALLCHAMPS = @"https://global.api.pvp.net/api/lol/static-data/br/v1.2/champion?champData=all&api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33";
        public static ChampionListDto AllChampions;

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
            if (json == string.Empty)
                json = new StreamReader(@"Assets\Cache\jsonchampions.txt", UnicodeEncoding.UTF8).ReadLine();
            AllChampions = new ChampionListDto();
            return AllChampions = JsonConvert.DeserializeObject<ChampionListDto>(json);
        }
    }
}
