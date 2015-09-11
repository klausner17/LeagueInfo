using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    /// <summary>
    /// Esta classe representa a dica do level.
    /// </summary>
    public class LevelTipDto
    {
        [JsonProperty("effect")]
        public List<string> Effect { get; set; }

        [JsonProperty("label")]
        public List<string> Label { get; set; }
    }
}
