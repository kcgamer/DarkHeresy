using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DarkHeresy.Models;

namespace DarkHeresy.ViewModels
{
    public class AmmoViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:n}")]
        public int? Cost { get; set; }

        [StringLength(10)]
        public string Amount { get; set; }

        [Display(Name="Availability")]
        public int AvailabilityId { get; set; }

        [StringLength(10)]
        public string Source { get; set; }

        public string Notes { get; set; }

        public Availability Availability { get; set; }

        public AmmoViewModel(Ammo ammo)
        {
            Id = ammo.Id;
            Name = ammo.Name;
            Cost = ammo.Cost;
            Amount = ammo.Amount;
            AvailabilityId = ammo.AvailabilityId;
            Source = ammo.Source;
            Notes = ammo.Notes;
            Availability = ammo.Availability;
        }

        public AmmoViewModel()
        {
            Id = 0;
        }
    }
}
