using DarkHeresy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarkHeresy.ViewModels
{
    public class CharacterViewModel
    {
        public int? Id { get; set; }

        [Display(Name="Character")]
        public string CharacterName { get; set; }

        [Display(Name="Player")]
        public string PlayerName { get; set; }

        [Display(Name="WS")]
        public int WeaponSkill { get; set; }

        [Display(Name="BS")]
        public int BallisticSkill { get; set; }

        [Display(Name="Str")]
        public int Strength { get; set; }

        [Display(Name="Tough")]
        public int Toughness { get; set; }

        [Display(Name="Agi")]
        public int Agility { get; set; }

        [Display(Name="Int")]
        public int Intelligence { get; set; }

        [Display(Name="Per")]
        public int Perception { get; set; }

        [Display(Name="Will")]
        public int Willpower { get; set; }

        [Display(Name="Fel")]
        public int Fellowship { get; set; }

        public string Career { get; set; }

        public string Rank { get; set; }

        [Display(Name="Home World")]
        public string HomeWorld { get; set; }

        public string Quirk { get; set; }

        public string Divination { get; set; }

        [Display(Name="Ordo/Faction")]
        public string OrdoFaction { get; set; }

        public string Description { get; set; }

        public int Wounds { get; set; }

        [Display(Name="Fate Points")]
        public int FatePoints { get; set; }

        [Display(Name="Total XP")]
        public int? TotalXp { get; set; }

        [Display(Name="Spent XP")]
        public int? SpentXp { get; set; }

        [Display(Name="Head Armor")]
        public int? HeadArmorId { get; set; }

        [Display(Name="ChestArmor")]
        public int? ChestArmorId { get; set; }

        [Display(Name="Left Arm")]
        public int? LeftArmArmorId { get; set; }

        [Display(Name="Right Arm")]
        public int? RightArmArmorId { get; set; }

        [Display(Name="Left Leg")]
        public int? LeftLegArmorId { get; set; }

        [Display(Name="Right Leg")]
        public int? RightLegArmorId { get; set; }

        public Armor HeadArmor { get; set; }
        public Armor ChestArmor { get; set; }
        public Armor LeftArmArmor { get; set; }
        public Armor LeftLegArmor { get; set; }
        public Armor RightArmArmor { get; set; }
        public Armor RightLegArmor { get; set; }

        public ICollection<CharacterSkill> CharacterSkills { get; set; }
        public ICollection<CharacterMelee> CharacterMelees { get; set; }
        public ICollection<CharacterRanged> CharacterRangeds { get; set; }

        public CharacterViewModel(Character character)
        {
            Id = character.Id;
            CharacterName = character.CharacterName;
            PlayerName = character.PlayerName;
            WeaponSkill = character.WeaponSkill;
            BallisticSkill = character.BallisticSkill;
            Strength = character.Strength;
            Toughness = character.Toughness;
            Agility = character.Agility;
            Intelligence = character.Intelligence;
            Perception = character.Perception;
            Willpower = character.Willpower;
            Fellowship = character.Fellowship;
            Career = character.Career;
            Rank = character.Rank;
            HomeWorld = character.HomeWorld;
            Quirk = character.Quirk;
            Divination = character.Divination;
            OrdoFaction = character.OrdoFaction;
            Description = character.Description;
            Wounds = character.Wounds;
            FatePoints = character.FatePoints;
            TotalXp = character.TotalXp;
            SpentXp = character.SpentXp;
            HeadArmor = character.HeadArmor;
            ChestArmor = character.ChestArmor;
            LeftArmArmor = character.LeftArmArmor;
            LeftLegArmor = character.LeftLegArmor;
            RightArmArmor = character.RightArmArmor;
            RightLegArmor = character.RightLegArmor;
            CharacterSkills = character.CharacterSkills;
            CharacterMelees = character.CharacterMelees;
            CharacterRangeds = character.CharacterRangeds;
        }

        public CharacterViewModel()
        {
            Id = 0;
        }
    }
}
