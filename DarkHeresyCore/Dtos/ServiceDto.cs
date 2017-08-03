using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkHeresy.Dtos
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? Cost { get; set; }
        public int? MaterialCost { get; set; }
        public string Effect { get; set; }
        public int AvailabilityId { get; set; }
        public string Difficulty { get; set; }
        public string Source { get; set; }
        public string Notes { get; set; }

        public AvailabilityDto Availability { get; set; }
        public CategoryDto Category { get; set; }
    }
}
