using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkHeresy.Dtos
{
    public class CharacterDto
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
        public int? HeadArmorId { get; set; }
        public int? ChestArmorId { get; set; }
        public int? LeftArmArmorId { get; set; }
        public int? RightArmArmorId { get; set; }
        public int? LeftLegArmorId { get; set; }
        public int? RightLegArmorId { get; set; }

        public ArmorDto HeadArmor { get; set; }
        public ArmorDto ChestArmor { get; set; }
        public ArmorDto LeftArmArmor { get; set; }
        public ArmorDto RightArmArmor { get; set; }
        public ArmorDto LeftLegArmor { get; set; }
        public ArmorDto RightLegArmor { get; set; }

        public ICollection<CharacterSkillDto> CharacterSkills { get; set; }
        public ICollection<CharacterMeleeDto> CharacterMelees { get; set; }
        public ICollection<CharacterRangedDto> CharacterRangeds { get; set; }
    }
}
