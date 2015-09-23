using Newtonsoft.Json;

namespace LeagueInfo.ClassApi
{
    /// <summary>
    /// This object contains basic data stats.
    /// </summary>
    public class BasicDataStatsDto
    {
        [JsonProperty("FlatArmorMod")]
        public double FlatArmorMod { get; set; }

        [JsonProperty("FlatAttackSpeedMod")]
        public double FlatAttackSpeedMod { get; set; }

        [JsonProperty("FlatBlockMod")]
        public double FlatBlockMod { get; set; }

        [JsonProperty("FlatCritChanceMod")]
        public double FlatCritChanceMod { get; set; }

        [JsonProperty("FlatCritDamageMod")]
        public double FlatCritDamageMod { get; set; }

        [JsonProperty("FlatExpBonus")]
        public double FlatExpBonus { get; set; }

        [JsonProperty("FlatEnergyPoolMod")]
        public double FlatEnergyPoolMod { get; set; }

        [JsonProperty("FlatEnergyRegenMod")]
        public double FlatEnergyRegenMod { get; set; }

        [JsonProperty("FlatHPPoolMod")]
        public double FlatHPPoolMod { get; set; }

        [JsonProperty("FlatHPRegenMod")]
        public double FlatHPRegenMod { get; set; }

        [JsonProperty("FlatMPPoolMod")]
        public double FlatMPPoolMod { get; set; }

        [JsonProperty("FlatMPRegenMod")]
        public double FlatMPRegenMod { get; set; }

        [JsonProperty("FlatMagicDamageMod")]
        public double FlatMagicDamageMod { get; set; }

        [JsonProperty("FlatMovementSpeedMod")]
        public double FlatMovementSpeedMod { get; set; }

        [JsonProperty("FlatPhysicalDamageMod")]
        public double FlatPhysicalDamageMod { get; set; }

        [JsonProperty("FlatSpellBlockMod")]
        public double FlatSpellBlockMod { get; set; }

        [JsonProperty("PercentArmorMod")]
        public double PercentArmorMod { get; set; }

        [JsonProperty("PercentAttackSpeedMod")]
        public double PercentAttackSpeedMod { get; set; }

        [JsonProperty("PercentBlockMod")]
        public double PercentBlockMod { get; set; }

        [JsonProperty("PercentCritChanceMod")]
        public double PercentCritChanceMod { get; set; }

        [JsonProperty("PercentCritDamageMod")]
        public double PercentCritDamageMod { get; set; }

        [JsonProperty("PercentDodgeMod")]
        public double PercentDodgeMod { get; set; }

        [JsonProperty("PercentEXPBonus")]
        public double PercentEXPBonus { get; set; }

        [JsonProperty("PercentHPPoolMod")]
        public double PercentHPPoolMod { get; set; }

        [JsonProperty("PercentHPRegenMod")]
        public double PercentHPRegenMod { get; set; }

        [JsonProperty("PercentLifeStealMod")]
        public double PercentLifeStealMod { get; set; }

        [JsonProperty("PercentMPPoolMod")]
        public double PercentMPPoolMod { get; set; }

        [JsonProperty("PercentMPRegenMod")]
        public double PercentMPRegenMod { get; set; }

        [JsonProperty("PercentMagicDamageMod")]
        public double PercentMagicDamageMod { get; set; }

        [JsonProperty("PercentMovementSpeedMod")]
        public double PercentMovementSpeedMod { get; set; }

        [JsonProperty("PercentPhysicalDamageMod")]
        public double PercentPhysicalDamageMod { get; set; }

        [JsonProperty("PercentSpellBlockMod")]
        public double PercentSpellBlockMod { get; set; }

        [JsonProperty("PercentSpellVampMod")]
        public double PercentSpellVampMod { get; set; }

        [JsonProperty("rFlatArmorModPerLevel")]
        public double rFlatArmorModPerLevel { get; set; }

        [JsonProperty("rFlatArmorPenetrationMod")]
        public double rFlatArmorPenetrationMod { get; set; }

        [JsonProperty("rFlatArmorPenetrationModPerLevel")]
        public double rFlatArmorPenetrationModPerLevel { get; set; }

        [JsonProperty("rFlatCritChanceModPerLevel")]
        public double rFlatCritChanceModPerLevel { get; set; }

        [JsonProperty("rFlatCritDamageModPerLevel")]
        public double rFlatCritDamageModPerLevel { get; set; }

        [JsonProperty("rFlatDodgeMod")]
        public double rFlatDodgeMod { get; set; }

        [JsonProperty("rFlatDodgeModPerLevel")]
        public double rFlatDodgeModPerLevel { get; set; }

        [JsonProperty("rFlatEnergyModPerLevel")]
        public double rFlatEnergyModPerLevel { get; set; }

        [JsonProperty("rFlatEnergyRegenModPerLevel")]
        public double rFlatEnergyRegenModPerLevel { get; set; }

        [JsonProperty("rFlatGoldPer10Mod")]
        public double rFlatGoldPer10Mod { get; set; }

        [JsonProperty("rFlatHPModPerLevel")]
        public double rFlatHPModPerLevel { get; set; }

        [JsonProperty("rFlatHPRegenModPerLevel")]
        public double rFlatHPRegenModPerLevel { get; set; }

        [JsonProperty("rFlatMPModPerLevel")]
        public double rFlatMPModPerLevel { get; set; }

        [JsonProperty("rFlatMPRegenModPerLevel")]
        public double rFlatMPRegenModPerLevel { get; set; }

        [JsonProperty("rFlatMagicDamageModPerLevel")]
        public double rFlatMagicDamageModPerLevel { get; set; }

        [JsonProperty("rFlatMagicPenetrationMod")]
        public double rFlatMagicPenetrationMod { get; set; }

        [JsonProperty("rFlatMagicPenetrationModPerLevel")]
        public double rFlatMagicPenetrationModPerLevel { get; set; }

        [JsonProperty("rFlatMovementSpeedModPerLevel")]
        public double rFlatMovementSpeedModPerLevel { get; set; }

        [JsonProperty("rFlatPhysicalDamageModPerLevel")]
        public double rFlatPhysicalDamageModPerLevel { get; set; }

        [JsonProperty("rFlatSpellBlockModPerLevel")]
        public double rFlatSpellBlockModPerLevel { get; set; }

        [JsonProperty("rFlatTimeDeadMod")]
        public double rFlatTimeDeadMod { get; set; }

        [JsonProperty("rFlatTimeDeadModPerLevel")]
        public double rFlatTimeDeadModPerLevel { get; set; }

        [JsonProperty("rPercentArmorPenetrationMod")]
        public double rPercentArmorPenetrationMod { get; set; }

        [JsonProperty("rPercentArmorPenetrationModPerLevel")]
        public double rPercentArmorPenetrationModPerLevel { get; set; }

        [JsonProperty("rPercentAttackSpeedModPerLevel")]
        public double rPercentAttackSpeedModPerLevel { get; set; }

        [JsonProperty("rPercentCooldownMod")]
        public double rPercentCooldownMod { get; set; }

        [JsonProperty("rPercentCooldownModPerLevel")]
        public double rPercentCooldownModPerLevel { get; set; }

        [JsonProperty("rPercentMagicPenetrationMod")]
        public double rPercentMagicPenetrationMod { get; set; }

        [JsonProperty("rPercentMagicPenetrationModPerLevel")]
        public double rPercentMagicPenetrationModPerLevel { get; set; }

        [JsonProperty("rPercentMovementSpeedModPerLevel")]
        public double rPercentMovementSpeedModPerLevel { get; set; }

        [JsonProperty("rPercentTimeDeadMod")]
        public double rPercentTimeDeadMod { get; set; }

        [JsonProperty("rPercentTimeDeadModPerLevel")]
        public double rPercentTimeDeadModPerLevel { get; set; }

    }
}