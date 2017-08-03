using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DarkHeresy.Models;

namespace DarkHeresy.ViewModels
{
    public class GearViewModel
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

        [StringLength(10)]
        public string Cost { get; set; }

        [Required]
        [Display(Name="Availability")]
        public int? AvailabilityId { get; set; }

        [StringLength(10)]
        public string Source { get; set; }

        public string Notes { get; set; }

        public Availability Availability { get; set; }
        public Category Category { get; set; }

        public GearViewModel(Gear gear)
        {
            Id = gear.Id;
            CategoryId = gear.CategoryId;
            Name = gear.Name;
            Weight = gear.Weight;
            Cost = gear.Cost;
            AvailabilityId = gear.AvailabilityId;
            Source = gear.Source;
            Notes = gear.Notes;
            Availability = gear.Availability;
            Category = gear.Category;
        }

        public GearViewModel()
        {
            Id = 0;
        }
    }
}
