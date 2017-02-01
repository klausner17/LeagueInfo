using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace LeagueInfo.ClassApi
{
    class ChampionListDto : IDisposable
    {
        const String URLALLCHAMPS = @"https://global.api.pvp.net/api/lol/static-data/br/v1.2/champion?champData=image,tags,skins&api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33";

        public static List<ChampionDto> AllChampions { get; set; }

        [JsonProperty("champions")]
        public List<ChampionDto> ChampionsFreeWeek { get; set; }

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
            string json = await new Requester().GetJson(URLALLCHAMPS);
            List<ChampionDto> champsFree = await LoadFreeWeek();
            var championData =  JsonConvert.DeserializeObject<ChampionListDto>(json);
            AllChampions = (from cd in championData.Data
                                  orderby cd.Value.Name ascending
                                  select cd.Value).ToList();
            for (int i = 0; i < AllChampions.Count; i++)
                foreach (ChampionDto fw in champsFree)
                    if (AllChampions[i].Id == fw.Id)
                        AllChampions[i].SetFree(true);
        }

        private static async Task<List<ChampionDto>> LoadFreeWeek()
        {
            string json = await new Requester().GetJson(@"https://br.api.pvp.net/api/lol/br/v1.2/champion?freeToPlay=true&api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33");
            return JsonConvert.DeserializeObject<ChampionListDto>(json).ChampionsFreeWeek;
        }
    }
}
