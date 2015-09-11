using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    public class BlocksDto
    {
        [JsonProperty("items")]
        public List<BlockItemDto> Items { get; set; }

        [JsonProperty("recMath")]
        public bool RecMath { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
