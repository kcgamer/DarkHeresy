using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DarkHeresyCore.Models;

namespace DarkHeresyCore.Dtos
{
    public class ArmorDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string LocCovered { get; set; }
        public string Ap { get; set; }
        public string Weight { get; set; }
        public int? Cost { get; set; }
        public int AvailabilityId { get; set; }
        public string Source { get; set; }
        public string Notes { get; set; }

        public AvailabilityDto Availability { get; set; }
        public CategoryDto Category { get; set; }
    }
}
