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
    class ChampionListDto : IDisposable
    {
        const String URLALLCHAMPS = @"https://global.api.pvp.net/api/lol/static-data/br/v1.2/champion?champData=image,tags&api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33";

        public static List<ChampionDto> AllChampions { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, ChampionDto> Data { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("keys")]
        public Dictionary<string, string> Keys { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        public void Dispose()
        {
            GC.Collect();
        }

        public static async Task LoadAllChampions()
        {
            string json = await new Requester(URLALLCHAMPS).GetJson();
            if (json == string.Empty)
                json = new StreamReader(@"Assets\Cache\jsonchampions.txt", UnicodeEncoding.UTF8).ReadLine();
            ChampionListDto championData = new ChampionListDto();
            championData =  JsonConvert.DeserializeObject<ChampionListDto>(json);
            AllChampions = (from cd in championData.Data
                                  orderby cd.Value.Name ascending
                                  select cd.Value).ToList();
        }
    }
}
