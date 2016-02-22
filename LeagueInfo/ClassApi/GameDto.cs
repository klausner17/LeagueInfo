using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    public class GameDto
    {
        #region GameDto

        [JsonProperty("championId")]
        private int championId;

        [JsonProperty("createDate")]
        private long createDate;

        [JsonProperty("fellowPlayers")]
        private List<PlayerDto> fellowPlayers;

        [JsonProperty("gameId")]
        private long gameId;

        [JsonProperty("gameMode")]
        private string gameMode;

        [JsonProperty("gameType")]
        private string gameType;

        [JsonProperty("invalid")]
        private bool invalid;

        [JsonProperty("ipEarned")]
        private int ipEarned;

        [JsonProperty("level")]
        private int level;

        [JsonProperty("mapId")]
        private int mapId;

        [JsonProperty("spell1")]
        private int spell1;

        [JsonProperty("spell2")]
        private int spell2;

        [JsonProperty("stats")]
        private RawStatsDto stats;

        [JsonProperty("subType")]
        private string subType;

        [JsonProperty("teamId")]
        private int teamId;
        
        #endregion

        #region Propriedades

        public ChampionDto Champion
        {
            get
            {
                return (from x in ChampionListDto.AllChampions 
                        where x.Id == championId select x).First();
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return new DateTime(createDate);
            }
        }

        public List<PlayerDto> FellowPlayers
        {
            get { return fellowPlayers; }
        }

        public long GameId
        {
            get { return gameId; }
        }

        public string GameMode
        {
            get { return gameMode; }
        }

        public string GameType
        {
            get { return gameType; }
        }

        public bool Invalid
        {
            get { return invalid; }
        }

        public int IpEarned
        {
            get { return ipEarned; }
        }

        public int Level
        {
            get { return level; }
        }

        public int MapId
        {
            get { return mapId; }
        }

        public int Spell1
        {
            get { return spell1; }
        }

        public int Spell2
        {
            get { return spell2; }
        }

        public RawStatsDto Stats
        {
            get { return stats; }
        }

        public string SubType
        {
            get { return subType; }
        }

        public int TeamId
        {
            get { return teamId; }
        }

        #endregion

    }
}
