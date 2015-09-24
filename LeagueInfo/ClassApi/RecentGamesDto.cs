using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LeagueInfo.ClassApi.Request;

namespace LeagueInfo.ClassApi
{
    class RecentGamesDto
    {
        [JsonProperty("games")]
        public List<GameDto> Games { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        public async Task<RecentGamesDto> GetLatestGamesById(long idSummoner)
        {
            string json = await new Requester(@"https://br.api.pvp.net/api/lol/br/v1.3/game/by-summoner/" + idSummoner + 
                "/recent?api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33").GetJson();
            RecentGamesDto recentGames = JsonConvert.DeserializeObject<RecentGamesDto>(json);
            return recentGames;
        }
    }
}
