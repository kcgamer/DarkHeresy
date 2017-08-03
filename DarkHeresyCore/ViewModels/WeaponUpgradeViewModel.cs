using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DarkHeresy.Models;

namespace DarkHeresy.ViewModels
{
    public class WeaponUpgradeViewModel
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name="Category")]
        public int? CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Weight { get; set; }

        [DisplayFormat(DataFormatString = "{0:n}")]
        public int? Cost { get; set; }

        [Required]
        [Display(Name="Availability")]
        public int? AvailabilityId { get; set; }

        [StringLength(10)]
        public string Source { get; set; }

        public string Notes { get; set; }

        public Availability Availability { get; set; }
        public Category Category { get; set; }

        public WeaponUpgradeViewModel(WeaponUpgrade weaponUpgrade)
        {
            Id = weaponUpgrade.Id;
            CategoryId = weaponUpgrade.CategoryId;
            Name = weaponUpgrade.Name;
            Weight = weaponUpgrade.Weight;
            Cost = weaponUpgrade.Cost;
            AvailabilityId = weaponUpgrade.AvailabilityId;
            Source = weaponUpgrade.Source;
            Notes = weaponUpgrade.Notes;
            Availability = weaponUpgrade.Availability;
            Category = weaponUpgrade.Category;
        }

        public WeaponUpgradeViewModel()
        {
            Id = 0;
        }
    }
}
