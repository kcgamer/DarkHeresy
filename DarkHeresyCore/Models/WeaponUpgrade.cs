using System;
using System.Collections.Generic;

namespace DarkHeresyCore.Models
{
    public  class WeaponUpgrade
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public int? Cost { get; set; }
        public int AvailabilityId { get; set; }
        public string Source { get; set; }
        public string Notes { get; set; }

        public  Availability Availability { get; set; }
        public  Category Category { get; set; }
    }
}
