using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LeagueInfo.Json.Request;
using System.IO;

namespace LeagueInfo.Json
{
    public class ItemListDto
    {
        const string URLALLITENS = @"https://global.api.pvp.net/api/lol/static-data/br/v1.2/item?itemListData=all&api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33";
        public ItemListDto AllItems;

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
            if (json == string.Empty)
                json = new StreamReader(@"Assets\Cache\jsonitems.txt", UnicodeEncoding.UTF8).ReadLine();
            AllItems = JsonConvert.DeserializeObject<ItemListDto>(json);
            return AllItems;
        }
    }
}
