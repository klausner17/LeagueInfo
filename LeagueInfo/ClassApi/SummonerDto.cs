using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LeagueInfo.ClassApi.Request;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LeagueInfo.ClassApi
{
    class SummonerDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Nome { get; set; }

        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }

        [JsonProperty("revisionDate")]
        public long RevisionDate { get; set; }

        [JsonProperty("summonerLevel")]
        public long SummonerLevel { get; set; }

        public async Task<SummonerDto> SearchSummoner(string nameSummoner)
        {
            nameSummoner = nameSummoner.Replace(" ", "");
            string json = await new Requester(@"https://br.api.pvp.net/api/lol/br/v1.4/summoner/by-name/" + nameSummoner + "?api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33").GetJson();
            Dictionary<string, SummonerDto> summoner = JsonConvert.DeserializeObject<Dictionary<string, SummonerDto>>(json);
            return summoner.First().Value;
        }

        public async Task<BitmapImage> GetProfileIcon()
        {
            return new BitmapImage(new Uri(@"http://ddragon.leagueoflegends.com/cdn/" + (await EndPointDDragon.GetVersions()).GeralVersion.ProfileIcon + "/img/profileicon/" + this.ProfileIconId.ToString() + ".png"));
        }
    }
}
