using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    class ParticipantTimeline
    {
        [JsonProperty("ancientGolemAssistsPerMinCounts")]
        public ParticipantTimeLineData AncientGolemAssistsPerMinCounts { get; set; }

        [JsonProperty("ancientGolemKillsPerMinCounts")]
        public ParticipantTimeLineData AncientGolemKillsPerMinCounts { get; set; }

        [JsonProperty("assistedLaneDeathsPerMinDeltas")]
        public ParticipantTimeLineData AssistedLaneDeathsPerMinDeltas { get; set; }

        [JsonProperty("assistedLaneKillsPerMinDeltas")]
        public ParticipantTimeLineData AssistedLaneKillsPerMinDeltas { get; set; }

        [JsonProperty("baronAssistsPerMinCounts")]
        public ParticipantTimeLineData BaronAssistsPerMinCounts { get; set; }

        [JsonProperty("baronKillsPerMinCounts")]
        public ParticipantTimeLineData BaronKillsPerMinCounts { get; set; }

        [JsonProperty("creepsPerMinDeltas")]
        public ParticipantTimeLineData CreepsPerMinDeltas { get; set; }

        [JsonProperty("csDiffPerMinDeltas")]
        public ParticipantTimeLineData CsDiffPerMinDeltas { get; set; }

        [JsonProperty("damageTakenDiffPerMinDeltas")]
        public ParticipantTimeLineData DamageTakenDiffPerMinDeltas { get; set; }

        [JsonProperty("damageTakenPerMinDeltas")]
        public ParticipantTimeLineData DamageTakenPerMinDeltas { get; set; }

        [JsonProperty("dragonAssistsPerMinCounts")]
        public ParticipantTimeLineData DragonAssistsPerMinCounts { get; set; }

        [JsonProperty("dragonKillsPerMinCounts")]
        public ParticipantTimeLineData DragonKillsPerMinCounts { get; set; }

        [JsonProperty("elderLizardAssistsPerMinCounts")]
        public ParticipantTimeLineData ElderLizardAssistsPerMinCounts { get; set; }

        [JsonProperty("elderLizardKillsPerMinCounts")]
        public ParticipantTimeLineData ElderLizardKillsPerMinCounts { get; set; }

        [JsonProperty("goldPerMinDeltas")]
        public ParticipantTimeLineData GoldPerMinDeltas { get; set; }

        [JsonProperty("inhibitorAssistsPerMinCounts")]
        public ParticipantTimeLineData InhibitorAssistsPerMinCounts { get; set; }

        [JsonProperty("inhibitorKillsPerMinCounts")]
        public ParticipantTimeLineData InhibitorKillsPerMinCounts { get; set; }

        [JsonProperty("lane")]
        public string Lane { get; set; }

        [JsonProperty("lole")]
        public string Role { get; set; }

        [JsonProperty("towerAssistsPerMinCounts")]
        public ParticipantTimeLineData TowerAssistsPerMinCounts { get; set; }

        [JsonProperty("towerKillsPerMinCounts")]
        public ParticipantTimeLineData TowerKillsPerMinCounts { get; set; }

        [JsonProperty("towerKillsPerMinDeltas")]
        public ParticipantTimeLineData TowerKillsPerMinDeltas { get; set; }

        [JsonProperty("vilemawAssistsPerMinCounts")]
        public ParticipantTimeLineData VilemawAssistsPerMinCounts { get; set; }

        [JsonProperty("wardsPerMinDeltas")]
        public ParticipantTimeLineData WardsPerMinDeltas { get; set; }

        [JsonProperty("xpDiffPerMinDeltas")]
        public ParticipantTimeLineData XpDiffPerMinDeltas { get; set; }

        [JsonProperty("xpPerMinDeltas")]
        public ParticipantTimeLineData XpPerMinDeltas { get; set; }
    }
}
