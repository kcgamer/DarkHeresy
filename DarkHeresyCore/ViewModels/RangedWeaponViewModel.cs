using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DarkHeresyCore.Models;

namespace DarkHeresyCore.ViewModels
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

        public IEnumerable<Availability> Availability { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<Class> Class { get; set; }
    }
}
