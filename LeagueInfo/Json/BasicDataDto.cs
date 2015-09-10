using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    public class BasicDataDto
    {
        [JsonProperty("colloq")]
        public string Colloq { get; set; }

        [JsonProperty("consumeOnFull")]
        public bool ConsumeOnFull { get; set; }

        [JsonProperty("consumed")]
        public bool Consumed { get; set; }

        [JsonProperty("depth")]
        public int Depth { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("from")]
        public List<string> From { get; set; }

        [JsonProperty("gold")]
        public GoldDto Gold { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("hideFromAll")]
        public bool HideFromAll { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("image")]
        public ImageDto Image { get; set; }

        [JsonProperty("intStore")]
        public bool InStore { get; set; }

        [JsonProperty("into")]
        public List<String> Into { get; set; }

        [JsonProperty("maps")]
        public Dictionary<string, bool> Maps { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("plaintext")]
        public string PlainText { get; set; }

        [JsonProperty("requiredChampion")]
        public string RequiredChampion { get; set; }

        [JsonProperty("rune")]
        public MetaDataDto Rune { get; set; }

        [JsonProperty("sanitizedDescription")]
        public string SanitizedDescriprion { get; set; }

        [JsonProperty("specialRecipe")]
        public int SpecialRecipe { get; set; }

        [JsonProperty("stacks")]
        public int Stacks { get; set; }

        [JsonProperty("stats")]
        public BasicDataStatsDto Stats { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
