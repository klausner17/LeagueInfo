using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LeagueInfo.ClassApi.Request;

namespace LeagueInfo.Json
{
    class LeagueDto
    {
        [JsonProperty("entries")]
        public List<LeagueEntryDto> Entries { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("participantId")]
        public string ParticipantId { get; set; }

        [JsonProperty("queue")]
        public string Queue { get; set; }

        [JsonProperty("tier")]
        public string Tier { get; set; }

        public async Task<LeagueDto> SearchLeague(int id)
        {
            Requester req = new Requester(@"https://br.api.pvp.net/api/lol/br/v2.5/league/by-summoner/" + id.ToString() + "/entry?api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33");
            string json = await req.GetJson();
            LeagueDto league = new LeagueDto();
            league = JsonConvert.DeserializeObject<this.GetType()>
        }

    }
}
