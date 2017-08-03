using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DarkHeresy.Models;

namespace DarkHeresy.ViewModels
{
    public class ArmorViewModel
    {
        public int? Id { get; set; }

        [Display(Name="Category")]
        [Required]
        public int? CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Loc Covered")]
        public string LocCovered { get; set; }

        [StringLength(50)]
        [Display(Name = "AP")]
        public string Ap { get; set; }

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

        public ArmorViewModel(Armor armor)
        {
            Id = armor.Id;
            Name = armor.Name;
            LocCovered = armor.LocCovered;
            Ap = armor.Ap;
            Weight = armor.Weight;
            Cost = armor.Cost;
            Availability = armor.Availability;
            AvailabilityId = armor.AvailabilityId;
            Source = armor.Source;
            Notes = armor.Notes;
            Category = armor.Category;
        }

        public ArmorViewModel()
        {
            Id = 0;
        }
    }
}
