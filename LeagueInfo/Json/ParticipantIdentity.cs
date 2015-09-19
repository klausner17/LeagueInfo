using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.Json
{
    class ParticipantIdentity
    {
        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }

        [JsonProperty("player")]
        public Player Player { get; set; }
    }
}
