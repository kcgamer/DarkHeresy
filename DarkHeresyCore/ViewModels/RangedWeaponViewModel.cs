using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DarkHeresy.Models;

namespace DarkHeresy.ViewModels
{
    public class RangedWeaponViewModel
    {
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

        [StringLength(10)]
        public string RoF { get; set; }

        [StringLength(20)]
        public string Damage { get; set; }

        public int? Pen { get; set; }

        public int? Clip { get; set; }

        [StringLength(20)]
        public string Reload { get; set; }

        [StringLength(50)]
        public string Special { get; set; }

        [StringLength(10)]
        public string Weight { get; set; }

        [DisplayFormat(DataFormatString = "{0:n}")]
        public int? Cost { get; set; }

        [Required]
        [Display(Name="Availability")]
        public int AvailabilityId { get; set; }

        [StringLength(10)]
        public string Source { get; set; }

        public string Notes { get; set; }

        public Availability Availability { get; set; }
        public Category Category { get; set; }
        public Class Class { get; set; }

        public RangedWeaponViewModel(RangedWeapon rangedWeapon)
        {
            Id = rangedWeapon.Id;
            Name = rangedWeapon.Name;
            CategoryId = rangedWeapon.CategoryId;
            ClassId = rangedWeapon.ClassId;
            Range = rangedWeapon.Range;
            RoF = rangedWeapon.RoF;
            Damage = rangedWeapon.Damage;
            Pen = rangedWeapon.Pen;
            Clip = rangedWeapon.Clip;
            Reload = rangedWeapon.Reload;
            Special = rangedWeapon.Special;
            Weight = rangedWeapon.Weight;
            Cost = rangedWeapon.Cost;
            AvailabilityId = rangedWeapon.AvailabilityId;
            Source = rangedWeapon.Source;
            Notes = rangedWeapon.Notes;
            Availability = rangedWeapon.Availability;
            Category = rangedWeapon.Category;
            Class = rangedWeapon.Class;
        }

        public RangedWeaponViewModel()
        {
            Id = 0;
        }
    }
}
