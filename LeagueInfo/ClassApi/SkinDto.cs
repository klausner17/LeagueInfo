using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    /// <summary>
    /// Esta classe representa as skins do campeão.
    /// </summary>
    public class SkinDto
    {
        #region SkinDto

        [JsonProperty("id")]
        private int id;

        [JsonProperty("name")]
        private string name;

        [JsonProperty("num")]
        private int num;

        #endregion

        #region Properties

        public int Id
        {
            get{ return id; }
        }

        public string Name
        {
            get
            {
                if (name.ToUpper() == "DEFAULT")
                    return "Clássica";
                else
                    return name;
            }
        }

        public int Num
        {
            get { return num; }
        }

        public string ImageSource
        {
            get
            {
                return "http://ddragon.leagueoflegends.com/cdn/img/champion/splash/" + this.Champion.Key + "_" + this.Num.ToString() + ".jpg";
            }
        }


        public ChampionDto Champion { get; set; }

        public SkinDto(ChampionDto champion)
        {
            Champion = champion;
        }

        #endregion
    }
}
