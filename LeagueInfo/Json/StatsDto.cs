using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.Json
{
    /// <summary>
    /// Esta classe representa os stats do campeão.
    /// </summary>
    public class StatsDto
    {
        [JsonProperty("armor")]
        public double Armor { get; set; }

        [JsonProperty("armorperlevel")]
        public double ArmorPerLevel { get; set; }

        [JsonProperty("attackdamage")]
        public double AttackDamage { get; set; }

        [JsonProperty("attackdamageperlevel")]
        public double AttackDamagePerLevel { get; set; }

        [JsonProperty("attackrange")]
        public double AttackRange { get; set; }

        [JsonProperty("attackspeedoffset")]
        public double AttackSpeedPerLevel { get; set; }

        [JsonProperty("Crit")]
        public double Critic { get; set; }

        [JsonProperty("hp")]
        public double HP { get; set; }

        [JsonProperty("hpperlevel")]
        public double HPPerLevel { get; set; }

        [JsonProperty("hpregen")]
        public double HPRegen { get; set; }

        [JsonProperty("hpregenperlevel")]
        public double HPRegenPerLevel { get; set; }

        [JsonProperty("movespeed")]
        public double MoveSpeed { get; set; }

        [JsonProperty("mp")]
        public double MP { get; set; }

        [JsonProperty("mpperlevel")]
        public double MPPerLevel { get; set; }

        [JsonProperty("mpregen")]
        public double MPRegen { get; set; }

        [JsonProperty("mpregenperlevel")]
        public double MPRegenPerLevel { get; set; }

        [JsonProperty("spellblock")]
        public double SpellBlock { get; set; }

        [JsonProperty("spellblockperlevel")]
        public double SpellBlockPerLevel { get; set; }
    }
}
