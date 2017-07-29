using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkHeresyCore.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string CharacterName { get; set; }
        public string PlayerName { get; set; }
        public int WeaponSkill { get; set; }
        public int BallisticSkill { get; set; }
        public int Strength { get; set; }
        public int Toughness { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Perception { get; set; }
        public int Willpower { get; set; }
        public int Fellowship { get; set; }
        public int? CareerId { get; set; }
        public string Career { get; set; }
        public string Rank { get; set; }
        public string HomeWorld { get; set; }
        public string Quirk { get; set; }
        public string Divination { get; set; }
        public string OrdoFaction { get; set; }
        public string Description { get; set; }
        public int Wounds { get; set; }
        public int FatePoints { get; set; }
        public int? TotalXp { get; set; }
        public int? SpentXp { get; set; }
        public Armor HeadArmor { get; set; }
        public Armor ChestArmor { get; set; }
        public Armor LeftArmArmor { get; set; }
        public Armor RightArmArmor { get; set; }
        public Armor LeftLegArmor { get; set; }
        public Armor RightLegArmor { get; set; }

        public ICollection<CharacterSkill> CharacterSkills { get; set; }

    }
}
