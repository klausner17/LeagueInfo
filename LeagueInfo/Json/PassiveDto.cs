using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.Json
{
    /// <summary>
    /// Classe que representa as passiva do campeão.
    /// </summary>
    public class PassiveDto
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image")]
        public ImageDto Image { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sanitizedDescription")]
        public string SanitizedDescription { get; set; }
    }
}
