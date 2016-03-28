using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using LeagueInfo.ClassApi.Request;
using System.Threading.Tasks;

namespace LeagueInfo.ClassApi
{
	public class ChampionDto
    {
   
        #region ChampionDto
        [JsonProperty("allytips")]
        private List<string> allyTips;

        [JsonProperty("blurb")]
        private string blurb;

        [JsonProperty("enemytips")]
        private List<string> enimyTips;

        [JsonProperty("id")]
        private int id;

        [JsonProperty("image")]
        private ImageDto image;

        [JsonProperty("info")]
        private InfoDto info;

        [JsonProperty("key")]
        private string key;

        [JsonProperty("lore")]
        private string lore;

        [JsonProperty("name")]
        private string name;

        [JsonProperty("partype")]
        private string partype;

        [JsonProperty("passive")]
        private PassiveDto passive;

        [JsonProperty("recommended")]
        private List<RecommendedDto> recommended;

        [JsonProperty("skins")]
        private List<SkinDto> skins;

        [JsonProperty("spells")]
        private List<ChampionSpellDto> spells;

        [JsonProperty("stats")]
        private StatsDto stats;

        [JsonProperty("tags")]
        private List<string> tags;

        [JsonProperty("title")]
        private string title;

        [JsonProperty("active")]
        private bool active;

        [JsonProperty("botEnabled")]
        private bool botEnabled;

        [JsonProperty("botMmEnabled")]
        private bool botMmEnabled;

        [JsonProperty("freeToPlay")]
        private bool freeToPlay;

        [JsonProperty("rankedPlayEnabled")]
        private bool rankedPlayEnabled;
        #endregion

        #region Properties

        public List<string> AllyTips
        {
            get { return allyTips; }
            set { allyTips = value; }
        }

        public string Blurb
        {
            get { return blurb; }
            set { blurb = value; }
        }

        public List<string> EnimyTips
        {
            get { return enimyTips; }
            set { enimyTips = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string SquareChampion
        {
            get { return "http://ddragon.leagueoflegends.com/cdn/" + EndPointDDragon.GetVersions().Result.GeralVersion.Champion + "/img/champion/" + this.image.Full; }
        }

        public List<string> SplashSkins
        {
            get 
            {
                List<string> skinsSources = new List<string>();
                foreach (SkinDto skin in Skins)
                {
                    skinsSources.Add("http://ddragon.leagueoflegends.com/cdn/img/champion/splash/" + this.Key + "_" + skin.Num.ToString() + ".jpg");
                }
                return skinsSources; 
            }
        }

        public List<string> ChampionLoading
        {
            get
            {
                List<string> loadingSources = new List<string>();
                foreach (SkinDto skin in Skins)
                    loadingSources.Add("http://ddragon.leagueoflegends.com/cdn/img/champion/loading/" + this.Key + "_" + skin.Id.ToString() + ".jpg");
                return loadingSources;
            }
        }

        public ImageDto Image
        {
            get { return image; }
            set { image = value; }
        }

        public InfoDto Info
        {
            get { return info; }
            set { info = value; }
        }

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public string Lore
        {
            get { return lore; }
            set { lore = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Partype
        {
            get { return partype; }
            set { partype = value; }
        }

        public PassiveDto Passive
        {
            get { return passive; }
            set { passive = value; }
        }

        public List<RecommendedDto> Recommended
        {
            get { return recommended; }
            set { recommended = value; }
        }

        public List<SkinDto> Skins
        {
            get { return skins; }
            set { skins = value; }
        }

        public List<ChampionSpellDto> Spells
        {
            get { return spells; }
            set { spells = value; }
        }

        public StatsDto Stats
        {
            get { return stats; }
            set { stats = value; }
        }

        public List<ChampionTag>  Tags
        {
            get
            {
                List<ChampionTag> tagsTemp = new List<ChampionTag>();
                foreach (string tag in this.tags)
                {
                    switch (tag)
                    {
                        case "Fighter":
                            tagsTemp.Add(new ChampionTag("lutador", new SolidColorBrush(Color.FromArgb(255, 197, 255, 73))));
                            break;
                        case "Support":
                            tagsTemp.Add(new ChampionTag("suporte", new SolidColorBrush(Color.FromArgb(255, 55, 232, 194))));
                            break;
                        case "Tank":
                            tagsTemp.Add(new ChampionTag("tanque", new SolidColorBrush(Color.FromArgb(255, 232, 67, 132))));
                            break;
                        case "Mage":
                            tagsTemp.Add(new ChampionTag("mago", new SolidColorBrush(Color.FromArgb(255, 81, 73, 255))));
                            break;
                        case "Assassin":
                            tagsTemp.Add(new ChampionTag("assassino", new SolidColorBrush(Color.FromArgb(255, 255, 178, 73))));
                            break;
                        case "Marksman":
                            tagsTemp.Add(new ChampionTag("atirador", new SolidColorBrush(Color.FromArgb(255, 255, 144, 104))));
                            break;
                        default:
                            tagsTemp.Add(new ChampionTag("desconhecido", new SolidColorBrush(Colors.LightGray)));
                            break;
                    }
                }
                return tagsTemp;
            }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public bool BotEnabled
        {
            get { return botEnabled; }
            set { botEnabled = value; }
        }

        public bool BotMmEnabled
        {
            get { return botMmEnabled; }
            set { botMmEnabled = value; }
        }

        public string Free
        {
            get
            {
                if (freeToPlay)
                    return "free";
                else return "";
            }
        }

        public bool RankedPlayEnabled
        {
            get { return rankedPlayEnabled; }
            set { rankedPlayEnabled = value; }
        }

        #endregion

        public static async Task<ChampionDto> SearchChampionAllData(long idChampion)
        {
            string json = await new Requester(@"https://global.api.pvp.net/api/lol/static-data/br/v1.2/champion/" + idChampion.ToString() + 
                "?champData=all&api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33").GetJson();
            return JsonConvert.DeserializeObject<ChampionDto>(json);
        }

        public static async Task<ChampionDto> SearchChampionLowData(long idChampion)
        {
            string json = await new Requester(@"https://global.api.pvp.net/api/lol/static-data/br/v1.2/champion/" + idChampion.ToString() + 
                "?champData=image&api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33").GetJson();
            return JsonConvert.DeserializeObject<ChampionDto>(json);
        }

        public void SetFree(bool status)
        {
            freeToPlay = true;
        }
    }
}
