﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DarkHeresyCore.Models;

namespace DarkHeresyCore.ViewModels
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

        public IEnumerable<Availability> Availability { get; set; }
        public IEnumerable<Category> Category { get; set; }
    }
}