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
        #region BasicDataDto

        [JsonProperty("colloq")]
        public string colloq;

        [JsonProperty("consumeOnFull")]
        public bool consumeOnFull;

        [JsonProperty("consumed")]
        public bool consumed;

        [JsonProperty("depth")]
        public int depth;

        [JsonProperty("description")]
        public string description;

        [JsonProperty("from")]
        public List<string> from;

        [JsonProperty("gold")]
        public GoldDto gold;

        [JsonProperty("group")]
        public string group;

        [JsonProperty("hideFromAll")]
        public bool hideFromAll;

        [JsonProperty("id")]
        public int id;

        [JsonProperty("image")]
        public ImageDto image;

        [JsonProperty("inStore")]
        public bool inStore;

        [JsonProperty("into")]
        public List<String> into;

        [JsonProperty("maps")]
        public Dictionary<string, bool> maps;

        [JsonProperty("name")]
        public string name;

        [JsonProperty("plaintext")]
        public string plainText;

        [JsonProperty("requiredChampion")]
        public string requiredChampion;

        [JsonProperty("rune")]
        public MetaDataDto rune;

        [JsonProperty("sanitizedDescription")]
        public string sanitizedDescriprion;

        [JsonProperty("specialRecipe")]
        public int specialRecipe;

        [JsonProperty("stacks")]
        public int stacks;

        [JsonProperty("stats")]
        public BasicDataStatsDto stats;

        [JsonProperty("tags")]
        public List<string> tags;

        #endregion

        #region Propriedades

        public string Colloq
        {
            get { return colloq; }
            set { colloq = value; }
        }

        public bool ConsumeOnFull
        {
            get { return consumeOnFull; }
            set { consumeOnFull = value; }
        }

        public bool Consumed
        {
            get { return consumed; }
            set { consumed = value; }
        }

        public int Depth
        {
            get { return depth; }
            set { depth = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public List<string> From
        {
            get { return from; }
            set { from = value; }
        }

        public GoldDto Gold
        {
            get { return gold; }
            set { gold = value; }
        }

        public string Group
        {
            get { return group; }
            set { group = value; }
        }

        public bool HideFromAll
        {
            get { return hideFromAll; }
            set { hideFromAll = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public ImageDto Image
        {
            get { return image; }
            set { image = value; }
        }

        public bool InStore
        {
            get { return inStore; }
            set { inStore = value; }
        }

        public List<String> Into
        {
            get { return into; }
            set { into = value; }
        }

        public Dictionary<string, bool> Maps
        {
            get { return maps; }
            set { maps = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PlainText
        {
            get { return plainText; }
            set { plainText = value; }
        }

        public string RequiredChampion
        {
            get { return requiredChampion; }
            set { requiredChampion = value; }
        }

        public MetaDataDto Rune
        {
            get { return rune; }
            set { rune = value; }
        }

        public string SanitizedDescriprion
        {
            get { return sanitizedDescriprion; }
            set { sanitizedDescriprion = value; }
        }

        public int SpecialRecipe
        {
            get { return specialRecipe; }
            set { specialRecipe = value; }
        }

        public int Stacks
        {
            get { return stacks; }
            set { stacks = value; }
        }

        public BasicDataStatsDto Stats
        {
            get { return stats; }
            set { stats = value; }
        }

        public List<string> Tags
        {
            get { return tags; }
            set { tags = value; }
        }

        #endregion
    }
}
