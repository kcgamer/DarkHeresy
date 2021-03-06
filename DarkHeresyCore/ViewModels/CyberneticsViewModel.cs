﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DarkHeresy.Models;

namespace DarkHeresy.ViewModels
{
    public class CyberneticsViewModel
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name="Category")]
        public int? CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Cost { get; set; }

        [Required]
        [Display(Name="Availability")]
        public int? AvailabilityId { get; set; }

        [StringLength(10)]
        public string Source { get; set; }

        public string Notes { get; set; }

        public Availability Availability { get; set; }
        public Category Category { get; set; }

        public CyberneticsViewModel(Cybernetic cybernetic)
        {
            Id = cybernetic.Id;
            CategoryId = cybernetic.CategoryId;
            Name = cybernetic.Name;
            Cost = cybernetic.Cost;
            AvailabilityId = cybernetic.AvailabilityId;
            Source = cybernetic.Source;
            Notes = cybernetic.Notes;
            Availability = cybernetic.Availability;
            Category = cybernetic.Category;
        }

        public CyberneticsViewModel()
        {
            Id = 0;
        }
    }
}
