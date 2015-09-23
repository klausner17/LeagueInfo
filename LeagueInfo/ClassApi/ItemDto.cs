using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using LeagueInfo.ClassApi.Request;
using System.Threading.Tasks;

namespace LeagueInfo.ClassApi
{
    public class ItemDto : BasicDataDto
    {
        public async Task<ItemDto> SearchItemByID(int id)
        {
            string json = await new Requester(@"https://global.api.pvp.net/api/lol/static-data/br/v1.2/item/" + id.ToString() + "?api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33").GetJson();
            ItemDto item = JsonConvert.DeserializeObject<ItemDto>(json);
            return item;
        }
    }
}
