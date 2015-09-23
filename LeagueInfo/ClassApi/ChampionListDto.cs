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

        public async Task<ChampionListDto> LoadAllChampions()
        {
            string json = await new Requester(URLALLCHAMPS).GetJson();
            if (json == string.Empty)
                json = new StreamReader(@"Assets\Cache\jsonchampions.txt", UnicodeEncoding.UTF8).ReadLine();
            ChampionListDto allChampions = new ChampionListDto();
            allChampions =  JsonConvert.DeserializeObject<ChampionListDto>(json);
            var championsByName = from championData in allChampions.Data
                                  orderby championData.Value.Name ascending
                                  select championData;
            ChampionListDto championsByOrderName = new ChampionListDto();
            championsByOrderName.Data = new Dictionary<string, ChampionDto>();
            int count = championsByName.Count();
            foreach (KeyValuePair<string, ChampionDto> champ in championsByName)
            {
                championsByOrderName.Data.Add(champ.Key, champ.Value);
            }
            allChampions.Dispose();
            return championsByOrderName;
        }
    }
}
