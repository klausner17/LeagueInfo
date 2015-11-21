using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    class MasteryPageDto
    {
        [JsonProperty("current")]
        public bool Current { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("masteries")]
        public List<MasteryDto> Masteries { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }
    }
}
