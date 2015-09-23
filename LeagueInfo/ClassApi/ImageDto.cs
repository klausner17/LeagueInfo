using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    public class ImageDto
    {
        [JsonProperty("full")]
        public string Full { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("h")]
        public int H { get; set; }

        [JsonProperty("sprite")]
        public string Sprite { get; set; }

        [JsonProperty("w")]
        public int W { get; set; }

        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }
    }
}
