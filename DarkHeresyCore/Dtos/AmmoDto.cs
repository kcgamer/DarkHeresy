using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkHeresy.Dtos
{
    public class AmmoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Cost { get; set; }
        public string Amount { get; set; }
        public int AvailabilityId { get; set; }
        public AvailabilityDto Availability { get; set; }
        public string Source { get; set; }
        public string Notes { get; set; }
    }
}
