using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DarkHeresy.Models;

namespace DarkHeresy.ViewModels
{
    public class MeleeWeaponViewModel
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Category")]
        public int? CategoryId { get; set; }

        [Required]
        [Display(Name="Class")]
        public int? ClassId { get; set; }

        [StringLength(10)]
        public string Range { get; set; }

        [StringLength(20)]
        public string Damage { get; set; }

        public int? Pen { get; set; }

        [StringLength(50)]
        public string Special { get; set; }

        [StringLength(10)]
        public string Weight { get; set; }

        [DisplayFormat(DataFormatString = "{0:n}")]
        public int? Cost { get; set; }

        [Required]
        [Display(Name="Availability")]
        public int? AvailabilityId { get; set; }

        [StringLength(10)]
        public string Source { get; set; }

        [Display(Name = "2H")]
        public bool TwoHanded { get; set; }

        public string Notes { get; set; }

        public Availability Availability { get; set; }
        public Category Category { get; set; }
        public Class Class { get; set; }

        public MeleeWeaponViewModel(MeleeWeapon meleeWeapon)
        {
            Id = meleeWeapon.Id;
            Name = meleeWeapon.Name;
            CategoryId = meleeWeapon.CategoryId;
            ClassId = meleeWeapon.ClassId;
            Range = meleeWeapon.Range;
            Damage = meleeWeapon.Damage;
            Pen = meleeWeapon.Pen;
            Special = meleeWeapon.Special;
            Weight = meleeWeapon.Weight;
            Cost = meleeWeapon.Cost;
            AvailabilityId = meleeWeapon.AvailabilityId;
            Source = meleeWeapon.Source;
            TwoHanded = meleeWeapon.TwoHanded;
            Notes = meleeWeapon.Notes;
            Availability = meleeWeapon.Availability;
            Category = meleeWeapon.Category;
            Class = meleeWeapon.Class;

        }

        public MeleeWeaponViewModel()
        {
            Id = 0;
        }
    }
}
