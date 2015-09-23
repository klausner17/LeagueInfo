using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    class MatchSummary
    {
        [JsonProperty("mapId")]
        public int MapId { get; set; }

        [JsonProperty("matchCreation")]
        public int MatchCreation { get; set; }

        [JsonProperty("matchDuration")]
        public int MatchDuration { get; set; }

        [JsonProperty("matchId")]
        public long MatchId { get; set; }

        [JsonProperty("matchMode")]
        public string MatchMode { get; set; }

        [JsonProperty("matchType")]
        public string MatchType { get; set; }

        [JsonProperty("matchVersion")]
        public string MatchVersion { get; set; }

        [JsonProperty("participantIdenties")]
        public List<ParticipantIdentity> ParticipantIdentities { get; set; }

        [JsonProperty("participants")]
        public List<Participant> Participants { get; set; }

        [JsonProperty("platformId")]
        public string PlatformId { get; set; }

        [JsonProperty("queueTypr")]
        public string QueueType { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }


    }
}
