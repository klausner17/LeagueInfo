using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace LeagueInfo.ClassApi
{
    /// <summary>
    /// Esta classe representa as habilidades do campeão.
    /// </summary>
    public class ChampionSpellDto
    {
        #region Api
        [JsonProperty("altimages")]
        private List<ImageDto> altImages;

        [JsonProperty("cooldown")]
        private List<double> cooldown;

        [JsonProperty("cooldownBurn")]
        private string cooldownBurn;

        [JsonProperty("cost")]
        private List<int> cost;

        [JsonProperty("costBurn")]
        private string costBurn;

        [JsonProperty("costType")]
        private string costType;

        [JsonProperty("description")]
        private string description;

        [JsonProperty("effect")]
        private List<List<double>> effect;

        [JsonProperty("effectBurn")]
        private List<string> effectBurn;

        [JsonProperty("image")]
        private ImageDto image;

        [JsonProperty("key")]
        private string key;

        [JsonProperty("leveltip")]
        private LevelTipDto levelTip;

        [JsonProperty("maxrank")]
        private int maxRank;

        [JsonProperty("name")]
        private string name;

        [JsonProperty("range")]
        private object range;

        [JsonProperty("rangeBurn")]
        private string rangeBurn;

        [JsonProperty("resource")]
        private string resource;

        [JsonProperty("sanitizedDescription")]
        private string sanitizedDescription;

        [JsonProperty("tooltip")]
        private string toolTip;

        [JsonProperty("vars")]
        private List<SpellVarsData> vars;
        #endregion

        public List<ImageDto> AltImages
        {
            get { return altImages; }
        }

        public List<double> Cooldown
        {
            get { return cooldown; }
        }

        public string CooldownBurn
        {
            get { return cooldownBurn; }
        }

        public List<int> Cost
        {
            get { return cost; }
        }

        public string CostBurn
        {
            get { return costBurn; }
        }

        public string CostType
        {
            get { return costType; }
        }

        public string Description
        {
            get { return description; }
        }

        public string DescriptionNoHtml
        {
            get { return Code.HtmlRemoval.StripTagsCharArray(description); }
        }

        public List<List<double>> Effect
        {
            get { return effect; }
        }

        public List<string> EffectBurn
        {
            get { return effectBurn; }
        }

        public ImageDto Image
        {
            get { return image; }
        }

        public string Key
        {
            get { return key; }
        }

        public LevelTipDto LevelTip
        {
            get { return levelTip; }
        }

        public int MaxRank
        {
            get { return MaxRank; }
        }

        public string Name
        {
            get { return name; }
        }

        public object Range
        {
            get { return range; }
        }

        public string RangeBurn
        {
            get { return rangeBurn; }
        }

        public string Resource
        {
            get { return resource; }
        }

        public string SanitizedDescription
        {
            get { return sanitizedDescription; }
        }

        public string ToolTip
        {
            get { return toolTip; }
        }

        public List<SpellVarsData> Vars
        {
            get { return vars; }
        }

        public string ImageSpell
        {
            get { return "http://ddragon.leagueoflegends.com/cdn/" + (EndPointDDragon.GetVersions().Result).GeralVersion.Champion + "/img/spell/" + this.Image.Full; }
        }
    }
}
