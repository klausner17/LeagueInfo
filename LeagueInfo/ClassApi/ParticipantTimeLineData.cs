using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    class ParticipantTimeLineData
    {
        [JsonProperty("tenToTwenty")]
        public double TenToTwenty { get; set; }

        [JsonProperty("thirtyToEnd")]
        public double ThirtyToEnd { get; set; }

        [JsonProperty("twentyToThirty")]
        public double TwentyToThirty { get; set; }

        [JsonProperty("zeroToTen")]
        public double ZeroToTen { get; set; }
    }
}
