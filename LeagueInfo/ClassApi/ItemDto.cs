using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using LeagueInfo.ClassApi.Request;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace LeagueInfo.ClassApi
{
    public class ItemDto : BasicDataDto
    {
        public string ImageSource
        {
            get
            {
                return "http://ddragon.leagueoflegends.com/cdn/" + EndPointDDragon.GetVersions().Result.GeralVersion.Item + "/img/item/" + this.Image.Full;
            }
        }

        public async Task<ItemDto> SearchItemByIDAllData(int id)
        {
            string json = await new Requester(@"https://global.api.pvp.net/api/lol/static-data/br/v1.2/item/" + id + "?itemData=all&api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33").GetJson();
            ItemDto item = JsonConvert.DeserializeObject<ItemDto>(json);
            return item;
        }

        public async Task<ItemDto> SearchItemLowData(int id)
        {
            string json = await new Requester(@"https://global.api.pvp.net/api/lol/static-data/br/v1.2/item/" + id.ToString() + "?itemData=gold,image&api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33").GetJson();
            ItemDto item = JsonConvert.DeserializeObject<ItemDto>(json);
            return item;
        }

        public async Task<BitmapImage> GetImage()
        {
            return new BitmapImage(new Uri("http://ddragon.leagueoflegends.com/cdn/" + (await EndPointDDragon.GetVersions()).GeralVersion.Item + "/img/item/" + this.Image.Full));
        }
    }
}
