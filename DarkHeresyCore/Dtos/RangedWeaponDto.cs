using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkHeresyCore.Dtos
{
    public class RangedWeaponDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int ClassId { get; set; }
        public string Range { get; set; }
        public string RoF { get; set; }
        public string Damage { get; set; }
        public int? Pen { get; set; }
        public int? Clip { get; set; }
        public string Reload { get; set; }
        public string Special { get; set; }
        public string Weight { get; set; }
        public int? Cost { get; set; }
        public int AvailabilityId { get; set; }
        public string Source { get; set; }
        public string Notes { get; set; }

        public AvailabilityDto Availability { get; set; }
        public CategoryDto Category { get; set; }
        public ClassDto Class { get; set; }
    }
}
