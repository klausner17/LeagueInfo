using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    public class BlockItemDto
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
