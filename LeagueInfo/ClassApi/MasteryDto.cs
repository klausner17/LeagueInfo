using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    class MasteryDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}
