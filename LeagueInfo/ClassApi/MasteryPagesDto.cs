using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    class MasteryPagesDto
    {
        [JsonProperty("pages")]
        public List<MasteryPageDto> Pages { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        public static async Task<MasteryPagesDto> SearchMateryPages(long idSummoner)
        {
            string json = await new Requester().GetJson(@"https://br.api.pvp.net/api/lol/br/v1.4/summoner/" + idSummoner.ToString() + "/masteries?api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33");
            Dictionary<string, MasteryPagesDto> materyPages = JsonConvert.DeserializeObject<Dictionary<string, MasteryPagesDto>>(json);
            return materyPages.First().Value;
        }
    }
}
