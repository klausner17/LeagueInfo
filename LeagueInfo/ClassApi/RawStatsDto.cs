using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    class RawStatsDto
    {
        [JsonProperty("assists")]
        public int Assists { get; set; }

        [JsonProperty("barracksKilled")]
        public int BarracksKilled { get; set; }

        [JsonProperty("championsKilled")]
        public int championsKilled { get; set; }

        [JsonProperty("combatPlayerScore")]
        public int combatPlayerScore { get; set; }

        [JsonProperty("consumablesPurchased")]
        public int consumablesPurchased { get; set; }

        [JsonProperty("damageDealtPlayer")]
        public int damageDealtPlayer { get; set; }

        [JsonProperty("doubleKills")]
        public int doubleKills { get; set; }

        [JsonProperty("firstBlood")]
        public int firstBlood { get; set; }

        [JsonProperty("gold")]
        public int gold { get; set; }

        [JsonProperty("goldEarned")]
        public int goldEarned { get; set; }

        [JsonProperty("goldSpent")]
        public int goldSpent { get; set; }

        [JsonProperty("item0")]
        public int item0 { get; set; }

        [JsonProperty("item1")]
        public int item1 { get; set; }

        [JsonProperty("item2")]
        public int item2 { get; set; }

        [JsonProperty("item3")]
        public int item3 { get; set; }

        [JsonProperty("item4")]
        public int item4 { get; set; }

        [JsonProperty("item5")]
        public int item5 { get; set; }

        [JsonProperty("item6")]
        public int item6 { get; set; }

        [JsonProperty("itemsPurchased")]
        public int itemsPurchased { get; set; }

        [JsonProperty("killingSprees")]
        public int killingSprees { get; set; }

        [JsonProperty("largestCriticalStrike")]
        public int largestCriticalStrike { get; set; }

        [JsonProperty("largestKillingSpree")]
        public int largestKillingSpree { get; set; }

        [JsonProperty("largestMultiKill")]
        public int largestMultiKill { get; set; }

        [JsonProperty("legendaryItemsCreated")]
        public int legendaryItemsCreated { get; set; }

        [JsonProperty("level")]
        public int level { get; set; }

        [JsonProperty("magicDamageDealtPlayer")]
        public int magicDamageDealtPlayer { get; set; }

        [JsonProperty("magicDamageDealtToChampions")]
        public int magicDamageDealtToChampions { get; set; }

        [JsonProperty("magicDamageTaken")]
        public int magicDamageTaken { get; set; }

        [JsonProperty("minionsDenied")]
        public int minionsDenied { get; set; }

        [JsonProperty("minionsKilled")]
        public int minionsKilled { get; set; }

        [JsonProperty("neutralMinionsKilled")]
        public int neutralMinionsKilled { get; set; }

        [JsonProperty("neutralMinionsKilledEnemyJungle")]
        public int neutralMinionsKilledEnemyJungle { get; set; }

        [JsonProperty("neutralMinionsKilledYourJungle")]
        public int neutralMinionsKilledYourJungle { get; set; }

        [JsonProperty("nexusKilled")]
        public bool nexusKilled { get; set; }

        [JsonProperty("nodeCapture")]
        public int nodeCapture { get; set; }

        [JsonProperty("nodeCaptureAssist")]
        public int nodeCaptureAssist { get; set; }

        [JsonProperty("nodeNeutralize")]
        public int nodeNeutralize { get; set; }

        [JsonProperty("nodeNeutralizeAssist")]
        public int nodeNeutralizeAssist { get; set; }

        [JsonProperty("numDeaths")]
        public int numDeaths { get; set; }

        [JsonProperty("numItemsBought")]
        public int numItemsBought { get; set; }

        [JsonProperty("objectivePlayerScore")]
        public int objectivePlayerScore { get; set; }

        [JsonProperty("pentaKills")]
        public int pentaKills { get; set; }

        [JsonProperty("physicalDamageDealtPlayer")]
        public int physicalDamageDealtPlayer { get; set; }

        [JsonProperty("physicalDamageDealtToChampions")]
        public int physicalDamageDealtToChampions { get; set; }

        [JsonProperty("physicalDamageTaken")]
        public int physicalDamageTaken { get; set; }

        [JsonProperty("playerPosition")]
        public int playerPosition { get; set; }

        [JsonProperty("playerRole")]
        public int playerRole { get; set; }

        [JsonProperty("quadraKills")]
        public int quadraKills { get; set; }

        [JsonProperty("sightWardsBought")]
        public int sightWardsBought { get; set; }

        [JsonProperty("spell1Cast")]
        public int spell1Cast { get; set; }

        [JsonProperty("spell2Cast")]
        public int spell2Cast { get; set; }

        [JsonProperty("spell3Cast")]
        public int spell3Cast { get; set; }

        [JsonProperty("spell4Cast")]
        public int spell4Cast { get; set; }

        [JsonProperty("summonSpell1Cast")]
        public int summonSpell1Cast { get; set; }

        [JsonProperty("summonSpell2Cast")]
        public int summonSpell2Cast { get; set; }

        [JsonProperty("superMonsterKilled")]
        public int superMonsterKilled { get; set; }

        [JsonProperty("team")]
        public int team { get; set; }

        [JsonProperty("teamObjective")]
        public int teamObjective { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("totalDamageDealt")]
        public int totalDamageDealt { get; set; }

        [JsonProperty("totalDamageDealtToChampions")]
        public int totalDamageDealtToChampions { get; set; }

        [JsonProperty("totalDamageTaken")]
        public int totalDamageTaken { get; set; }

        [JsonProperty("totalHeal")]
        public int totalHeal { get; set; }

        [JsonProperty("totalPlayerScore")]
        public int totalPlayerScore { get; set; }

        [JsonProperty("totalScoreRank")]
        public int totalScoreRank { get; set; }

        [JsonProperty("totalTimeCrowdControlDealt")]
        public int totalTimeCrowdControlDealt { get; set; }

        [JsonProperty("totalUnitsHealed")]
        public int totalUnitsHealed { get; set; }

        [JsonProperty("tripleKills")]
        public int tripleKills { get; set; }

        [JsonProperty("trueDamageDealtPlayer")]
        public int trueDamageDealtPlayer { get; set; }

        [JsonProperty("trueDamageDealtToChampions")]
        public int trueDamageDealtToChampions { get; set; }

        [JsonProperty("trueDamageTaken")]
        public int trueDamageTaken { get; set; }

        [JsonProperty("turretsKilled")]
        public int turretsKilled { get; set; }

        [JsonProperty("unrealKills")]
        public int unrealKills { get; set; }

        [JsonProperty("victoryPointTotal")]
        public int victoryPointTotal { get; set; }

        [JsonProperty("visionWardsBought")]
        public int visionWardsBought { get; set; }

        [JsonProperty("wardKilled")]
        public int wardKilled { get; set; }

        [JsonProperty("wardPlaced")]
        public int wardPlaced { get; set; }

        [JsonProperty("win")]
        public int win { get; set; }
    }
}
