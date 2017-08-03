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

        public IEnumerable<Availability> Availability { get; set; }
        public IEnumerable<Category> Category { get; set; }
    }
}
