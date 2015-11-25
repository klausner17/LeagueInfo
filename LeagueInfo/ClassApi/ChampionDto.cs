using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using LeagueInfo.ClassApi.Request;
using System.Threading.Tasks;

namespace LeagueInfo.ClassApi
{
	public class ChampionDto
    {
        const String URLCHAMPS = @"https://global.api.pvp.net/api/lol/static-data/br/v1.2/champion/412?champData=all&api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33";
   
        #region ChampionDto
        [JsonProperty("allytips")]
        public List<string> AllyTips { get; set; }

        [JsonProperty("blurb")]
        public string Blurb { get; set; }

        [JsonProperty("enemytips")]
        public List<string> EnimyTips { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("image")]
        public ImageDto Image { get; set; }

        [JsonProperty("info")]
        public InfoDto Info { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lore")]
        public string Lore { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("partype")]
        public string Partype { get; set; }

        [JsonProperty("passive")]
        public PassiveDto Passive { get; set; }

        [JsonProperty("recommended")]
        public List<RecommendedDto> Recommended { get; set; }

        [JsonProperty("skins")]
        public List<SkinDto> Skins { get; set; }

        [JsonProperty("spells")]
        public List<ChampionSpellDto> Spells { get; set; }

        [JsonProperty("stats")]
        public StatsDto Stats { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        public async Task<ChampionDto> SearchChampionAllData(long idChampion)
        {
            string json = await new Requester(@"https://global.api.pvp.net/api/lol/static-data/br/v1.2/champion/" + idChampion.ToString() + 
                "?champData=all&api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33").GetJson();
            return JsonConvert.DeserializeObject<ChampionDto>(json);
        }

        public async Task<ChampionDto> SearchChampionLowData(long idChampiom)
        {
            string json = await new Requester(@"https://global.api.pvp.net/api/lol/static-data/br/v1.2/champion/" + idChampiom.ToString() + 
                "?champData=image&api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33").GetJson();
            return JsonConvert.DeserializeObject<ChampionDto>(json);
        }

        public BitmapImage GetChampionSquare()
        {
            return new BitmapImage(new Uri("http://ddragon.leagueoflegends.com/cdn/5.23.1/img/champion/" + this.Image.Full));
        }
        #endregion

        public BitmapImage GetChampionSplash(int idSkin)
        {
            return new BitmapImage(new Uri("http://ddragon.leagueoflegends.com/cdn/img/champion/splash/" + this.Key + "_" + idSkin.ToString() + ".jpg"));
        }
    }
}
