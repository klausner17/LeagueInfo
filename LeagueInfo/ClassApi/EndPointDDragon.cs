using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    /// <summary>
    /// Verifica as versões do Data Dragon
    /// </summary>
    class EndPointDDragon
    {
        [JsonProperty("n")]
        public GeneralVersion GeralVersion { get; set; }

        [JsonProperty("v")]
        public string Version { get; set; }

        [JsonProperty("l")]
        public string Language { get; set; }

        [JsonProperty("cdn")]
        public string CDN { get; set; }

        [JsonProperty("dd")]
        public string DataDragon { get; set; }

        [JsonProperty("lg")]
        public string Lg { get; set; }

        [JsonProperty("css")]
        public string Css { get; set; }

        [JsonProperty("profileiconmax")]
        public int ProfileIconMax { get; set; }

        [JsonProperty("store")]
        public string Store { get; set; }

        private static EndPointDDragon instance;

        private EndPointDDragon() { }

        public async static Task<EndPointDDragon> GetVersions()
        {
            if (instance == null)
            {
                string json = await new Requester().GetJson(@"https://ddragon.leagueoflegends.com/realms/br.json");
                instance = JsonConvert.DeserializeObject<EndPointDDragon>(json);
            }
            return instance;
        }
    }
}
