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
        #region Api Class

        [JsonProperty("full")]
        private string full;

        [JsonProperty("group")]
        private string group;

        [JsonProperty("h")]
        private int h { get; set; }

        [JsonProperty("sprite")]
        private string sprite { get; set; }

        [JsonProperty("w")]
        private int w;

        [JsonProperty("x")]
        private int x;

        [JsonProperty("y")]
        private int y;

        #endregion

        #region Propriedades

        public string Full
        {
            get { return full; }
            set { full = value; }
        }

        public string Group
        {
            get { return group; }
            set { group = value; }
        }

        public int H
        {
            get { return h; }
            set { h = value; }
        }

        public string Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        public int W
        {
            get { return w; }
            set { w = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        #endregion
    }
}
