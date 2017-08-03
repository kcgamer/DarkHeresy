using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DarkHeresy.Models;

namespace DarkHeresy.ViewModels
{
    public class ServiceViewModel
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name="Category")]
        public int? CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:n}")]
        public int? Cost { get; set; }

        [DisplayFormat(DataFormatString = "{0:n}")]
        public int? MaterialCost { get; set; }

        [StringLength(50)]
        public string Effect { get; set; }

        [Required]
        [Display(Name="Availability")]
        public int? AvailabilityId { get; set; }

        [StringLength(50)]
        public string Difficulty { get; set; }

        [StringLength(10)]
        public string Source { get; set; }

        public string Notes { get; set; }

        public Availability Availability { get; set; }
        public Category Category { get; set; }

        public ServiceViewModel(Service service)
        {
            Id = service.Id;
            CategoryId = service.CategoryId;
            Name = service.Name;
            Cost = service.Cost;
            MaterialCost = service.MaterialCost;
            Effect = service.Effect;
            AvailabilityId = service.AvailabilityId;
            Difficulty = service.Difficulty;
            Source = service.Source;
            Notes = service.Notes;
            Availability = service.Availability;
            Category = service.Category;
        }

        public ServiceViewModel()
        {
            Id = 0;
        }
    }
}
