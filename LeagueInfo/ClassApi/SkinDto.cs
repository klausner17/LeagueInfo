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
            get { return name; }
        }

        public int Num
        {
            get { return num; }
        }

        #endregion


    }
}
