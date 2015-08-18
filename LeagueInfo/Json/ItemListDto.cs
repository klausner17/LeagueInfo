using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LeagueInfo.Json.Request;

namespace LeagueInfo.Json
{
    public class ItemListDto
    {
        const string URLALLITENS = @"https://global.api.pvp.net/api/lol/static-data/br/v1.2/item?itemListData=all&api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33";

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

        public async Task<ItemListDto> LoadAllItens()
        {
            string json = await new Requester(URLALLITENS).GetJson();
            ItemListDto itens = new ItemListDto();
            try
            {
                itens = JsonConvert.DeserializeObject<ItemListDto>(json);
            }
            catch
            {
            }
            return itens;
        }
    }
}
