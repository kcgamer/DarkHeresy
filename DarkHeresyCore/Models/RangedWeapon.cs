using System;
using System.Collections.Generic;

namespace DarkHeresy.Models
{
    public  class RangedWeapon
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

        public  Availability Availability { get; set; }
        public  Category Category { get; set; }
        public  Class Class { get; set; }

        public ICollection<CharacterRanged> CharacterRangeds { get; set; }
    }
}
