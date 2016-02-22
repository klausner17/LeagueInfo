using Newtonsoft.Json;
using System;
using System.Linq;
using System.Windows.Media;

namespace LeagueInfo.ClassApi
{
    public class RawStatsDto
    {
        #region RawStatsDto

        [JsonProperty("assists")]
        private int assists;

        [JsonProperty("barracksKilled")]
        private int barracksKilled;
        
        [JsonProperty("championsKilled")]
        private int championsKilled;
        
        [JsonProperty("combatPlayerScore")]
        private int combatPlayerScore;
        
        [JsonProperty("consumablesPurchased")]
        private int consumablesPurchased;
        
        [JsonProperty("damageDealtPlayer")]
        private int damageDealtPlayer;
        
        [JsonProperty("doubleKills")]
        private int doubleKills;
        
        [JsonProperty("firstBlood")]
        private int firstBlood;
        
        [JsonProperty("gold")]
        private int gold;
        
        [JsonProperty("goldEarned")]
        private int goldEarned;
        
        [JsonProperty("goldSpent")]
        private int goldSpent;

        [JsonProperty("item0")]
        private int item0;

        [JsonProperty("item1")]
        private int item1;

        [JsonProperty("item2")]
        private int item2;

        [JsonProperty("item3")]
        private int item3;

        [JsonProperty("item4")]
        private int item4;

        [JsonProperty("item5")]
        private int item5;

        [JsonProperty("item6")]
        private int item6;

        [JsonProperty("itemsPurchased")]
        private int itemsPurchased;
        
        [JsonProperty("killingSprees")]
        private int killingSprees;
        
        [JsonProperty("largestCriticalStrike")]
        private int largestCriticalStrike;
        
        [JsonProperty("largestKillingSpree")]
        private int largestKillingSpree;
        
        [JsonProperty("largestMultiKill")]
        private int largestMultiKill;
        
        [JsonProperty("legendaryItemsCreated")]
        private int legendaryItemsCreated;
        
        [JsonProperty("level")]
        private int level;
        
        [JsonProperty("magicDamageDealtPlayer")]
        private int magicDamageDealtPlayer;
        
        [JsonProperty("magicDamageDealtToChampions")]
        private int magicDamageDealtToChampions;
        
        [JsonProperty("magicDamageTaken")]
        private int magicDamageTaken;
        
        [JsonProperty("minionsDenied")]
        private int minionsDenied;
        
        [JsonProperty("minionsKilled")]
        private int minionsKilled;
        
        [JsonProperty("neutralMinionsKilled")]
        private int neutralMinionsKilled;
        
        [JsonProperty("neutralMinionsKilledEnemyJungle")]
        private int neutralMinionsKilledEnemyJungle;
        
        [JsonProperty("neutralMinionsKilledYourJungle")]
        private int neutralMinionsKilledYourJungle;
        
        [JsonProperty("nexusKilled")]
        private bool nexusKilled;
        
        [JsonProperty("nodeCapture")]
        private int nodeCapture;
        
        [JsonProperty("nodeCaptureAssist")]
        private int nodeCaptureAssist;
        
        [JsonProperty("nodeNeutralize")]
        private int nodeNeutralize;
        
        [JsonProperty("nodeNeutralizeAssist")]
        private int nodeNeutralizeAssist;
        
        [JsonProperty("numDeaths")]
        private int numDeaths;
        
        [JsonProperty("numItemsBought")]
        private int numItemsBought;
        
        [JsonProperty("objectivePlayerScore")]
        private int objectivePlayerScore;
        
        [JsonProperty("pentaKills")]
        private int pentaKills;
        
        [JsonProperty("physicalDamageDealtPlayer")]
        private int physicalDamageDealtPlayer;
        
        [JsonProperty("physicalDamageDealtToChampions")]
        private int physicalDamageDealtToChampions;
        
        [JsonProperty("physicalDamageTaken")]
        private int physicalDamageTaken;
        
        [JsonProperty("playerPosition")]
        private int playerPosition;
        
        [JsonProperty("playerRole")]
        private int playerRole;

        [JsonProperty("quadraKills")]
        private int quadraKills;

        [JsonProperty("sightWardsBought")]
        private int sightWardsBought;

        [JsonProperty("spell1Cast")]
        private int spell1Cast;

        [JsonProperty("spell2Cast")]
        private int spell2Cast;

        [JsonProperty("spell3Cast")]
        private int spell3Cast;

        [JsonProperty("spell4Cast")]
        private int spell4Cast;

        [JsonProperty("summonSpell1Cast")]
        private int summonSpell1Cast;

        [JsonProperty("summonSpell2Cast")]
        private int summonSpell2Cast;

        [JsonProperty("superMonsterKilled")]
        private int superMonsterKilled;

        [JsonProperty("team")]
        private int team;

        [JsonProperty("teamObjective")]
        private int teamObjective;

        [JsonProperty("timePlayed")]
        private int timePlayed;

        [JsonProperty("totalDamageDealt")]
        private int totalDamageDealt;

        [JsonProperty("totalDamageDealtToChampions")]
        private int totalDamageDealtToChampions;

        [JsonProperty("totalDamageTaken")]
        private int totalDamageTaken;

        [JsonProperty("totalHeal")]
        private int totalHeal;

        [JsonProperty("totalPlayerScore")]
        private int totalPlayerScore;

        [JsonProperty("totalScoreRank")]
        private int totalScoreRank;

        [JsonProperty("totalTimeCrowdControlDealt")]
        private int totalTimeCrowdControlDealt;

        [JsonProperty("totalUnitsHealed")]
        private int totalUnitsHealed;

        [JsonProperty("tripleKills")]
        private int tripleKills;

        [JsonProperty("trueDamageDealtPlayer")]
        private int trueDamageDealtPlayer;

        [JsonProperty("trueDamageDealtToChampions")]
        private int trueDamageDealtToChampions;

        [JsonProperty("trueDamageTaken")]
        private int trueDamageTaken;

        [JsonProperty("turretsKilled")]
        private int turretsKilled;

        [JsonProperty("unrealKills")]
        private int unrealKills;

        [JsonProperty("victoryPointTotal")]
        private int victoryPointTotal;

        [JsonProperty("visionWardsBought")]
        private int visionWardsBought;

        [JsonProperty("wardKilled")]
        private int wardKilled;

        [JsonProperty("wardPlaced")]
        private int wardPlaced;

        [JsonProperty("win")]
        private bool win;

        #endregion

        #region Propriedades

        public int Assists
        {
            get { return assists; }
        }

        public int BarracksKilled
        {
            get { return barracksKilled; }
        }

        public int ChampionsKilled
        {
            get { return championsKilled; }
        }

        public int CombatPlayerScore{
            get { return assists; }
        }

        public int ConsumablesPurchased
        {
            get { return consumablesPurchased; }
        }

        public int DamageDealtPlayer
        {
            get { return damageDealtPlayer; }
        }

        public int DoubleKills
        {
            get { return doubleKills; }
        }

        public int FirstBlood
        {
            get { return firstBlood; }
        }

        public int Gold
        {
            get { return gold; }
        }

        public int GoldEarned
        {
            get { return goldEarned; }
        }

        public int GoldSpent
        {
            get { return goldSpent; }
        }

        public ItemDto Item0
        {
            get
            {
                return (from item in ItemListDto.AllItems
                        where item.id == item0
                        select item).FirstOrDefault();
            }
        }

        public ItemDto Item1
        {
            get
            {
                return (from item in ItemListDto.AllItems
                        where item.id == item1
                        select item).FirstOrDefault();
            }
        }

        public ItemDto Item2
        {
            get
            {
                return (from item in ItemListDto.AllItems
                        where item.id == item2
                        select item).FirstOrDefault();
            }
        }

        public ItemDto Item3
        {
            get
            {
                return (from item in ItemListDto.AllItems
                        where item.id == item3
                        select item).FirstOrDefault();
            }
        }

        public ItemDto Item4
        {
            get
            {
                return (from item in ItemListDto.AllItems
                        where item.id == item4
                        select item).FirstOrDefault();
            }
        }

        public ItemDto Item5
        {
            get
            {
                return (from item in ItemListDto.AllItems
                        where item.id == item5
                        select item).FirstOrDefault();
            }
        }

        public ItemDto Item6
        {
            get
            {
                return (from item in ItemListDto.AllItems
                        where item.id == item6
                        select item).First();
            }
        }

        public int ItemsPurchased
        {
            get { return itemsPurchased; }
        }

        public int KillingSprees
        {
            get { return killingSprees; }
        }

        public int LargestCriticalStrike
        {
            get { return largestCriticalStrike; }
        }

        public int LargestKillingSpree
        {
            get { return largestKillingSpree; }
        }

        public int LargestMultiKill
        {
            get { return largestMultiKill; }
        }

        public int LegendaryItemsCreated
        {
            get { return legendaryItemsCreated; }
        }

        public int Level
        {
            get { return level; }
        }

        public int MagicDamageDealtPlayer
        {
            get { return magicDamageDealtPlayer; }
        }

        public int MagicDamageDealtToChampions
        {
            get { return magicDamageDealtToChampions; }
        }

        public int MagicDamageTaken
        {
            get { return magicDamageTaken; }
        }

        public int MinionsDenied
        {
            get { return minionsDenied; }
        }

        public int MinionsKilled
        {
            get { return minionsKilled; }
        }

        public int NeutralMinionsKilled
        {
            get { return neutralMinionsKilled; }
        }

        public int NeutralMinionsKilledEnemyJungle
        {
            get { return neutralMinionsKilledEnemyJungle; }
        }

        public int NeutralMinionsKilledYourJungle
        {
            get { return neutralMinionsKilledYourJungle; }
        }

        public bool NexusKilled
        {
            get { return nexusKilled; }
        }

        public int NodeCapture
        {
            get { return nodeCapture; }
        }

        public int NodeCaptureAssist
        {
            get { return nodeCaptureAssist; }
        }

        public int NodeNeutralize
        {
            get { return nodeNeutralize; }
        }

        public int NodeNeutralizeAssist
        {
            get { return nodeNeutralizeAssist; }
        }

        public int NumDeaths
        {
            get { return numDeaths; }
        }

        public int NumItemsBought
        {
            get { return numItemsBought; }
        }

        public int ObjectivePlayerScore
        {
            get { return objectivePlayerScore; }
        }

        public int PentaKills
        {
            get { return pentaKills; }
        }

        public int PhysicalDamageDealtPlayer
        {
            get { return physicalDamageDealtPlayer; }
        }

        public int PhysicalDamageDealtToChampions
        {
            get { return physicalDamageDealtToChampions; }
        }

        public int PhysicalDamageTaken
        {
            get { return physicalDamageTaken; }
        }

        public int PlayerPosition
        {
            get { return playerPosition; }
        }

        public int PlayerRole
        {
            get { return playerRole; }
        }

        public int QuadraKills
        {
            get { return quadraKills; }
        }

        public int SightWardsBought
        {
            get { return sightWardsBought; }
        }

        public int Spell1Cast
        {
            get { return spell1Cast; }
        }

        public int Spell2Cast
        {
            get { return spell2Cast; }
        }

        public int Spell3Cast
        {
            get { return spell3Cast; }
        }

        public int Spell4Cast
        {
            get { return spell4Cast; }
        }

        public int SummonSpell1Cast
        {
            get { return summonSpell1Cast; }
        }

        public int SummonSpell2Cast
        {
            get { return summonSpell2Cast; }
        }

        public int SuperMonsterKilled
        {
            get { return superMonsterKilled; }
        }

        public int Team { get { return team ; } }

        public int TeamObjective
        {
            get { return teamObjective; }
        }

        public double TimePlayed
        {
            get { return Math.Round((double)(timePlayed / 60), 0); }
        }

        public int TotalDamageDealt
        {
            get { return totalDamageDealt; }
        }

        public int TotalDamageDealtToChampions
        {
            get { return totalDamageDealtToChampions; }
        }

        public int TotalDamageTaken
        {
            get { return totalDamageTaken; }
        }

        public int TotalHeal
        {
            get { return totalHeal; }
        }

        public int TotalPlayerScore
        {
            get { return totalPlayerScore; }
        }

        public int TotalScoreRank
        {
            get { return totalScoreRank; }
        }

        public int TotalTimeCrowdControlDealt
        {
            get { return totalTimeCrowdControlDealt; }
        }

        public int TotalUnitsHealed
        {
            get { return totalUnitsHealed; }
        }

        public int TripleKills
        {
            get { return tripleKills; }
        }

        public int TrueDamageDealtPlayer
        {
            get { return trueDamageDealtPlayer; }
        }

        public int TrueDamageDealtToChampions
        {
            get { return trueDamageDealtToChampions; }
        }

        public int TrueDamageTaken
        {
            get { return trueDamageTaken; }
        }

        public int TurretsKilled
        {
            get { return turretsKilled; }
        }

        public int UnrealKills
        {
            get { return unrealKills; }
        }

        public int VictoryPointTotal
        {
            get { return victoryPointTotal; }
        }

        public int VisionWardsBought
        {
            get { return visionWardsBought; }
        }

        public int WardKilled
        {
            get { return wardKilled; }
        }

        public int WardPlaced
        {
            get { return wardPlaced; }
        }

        public bool Win
        {
            get { return win; }
        }

        public SolidColorBrush WinColor
        {
            get
            {
                if (win)
                    return new SolidColorBrush(Colors.Green);
                else
                    return new SolidColorBrush(Colors.Red);
            }
        }

        #endregion
    }
}
