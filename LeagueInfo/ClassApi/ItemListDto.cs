using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace LeagueInfo.ClassApi
{
    public class ItemListDto
    {
        const string URLALLITENS = @"https://global.api.pvp.net/api/lol/static-data/br/v1.2/item?itemListData=gold,image,maps,tags&api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33";

        public static List<ItemDto> AllItems { get; set; }

        [JsonProperty("basic")]
        public BasicDataDto Basic { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, ItemDto> Data { get; set; }

        [JsonProperty("groups")]
        public List<GroupDto> Groups { get; set; }

        [JsonProperty("tree")]
        public List<ItemDto> Tree { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        public static async Task LoadAllItens()
        {
            string json = await new Requester().GetJson(URLALLITENS);
            ItemListDto dataItens = JsonConvert.DeserializeObject<ItemListDto>(json);
            AllItems = (from itens in dataItens.Data
                        orderby itens.Value.Name ascending
                        select itens.Value).ToList();
        }
    }
}
