namespace DarkHeresy.Models
{
    public class Ammo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Cost { get; set; }
        public string Amount { get; set; }
        public int AvailabilityId { get; set; }
        public string Source { get; set; }
        public string Notes { get; set; }

        public Availability Availability { get; set; }
    }
}