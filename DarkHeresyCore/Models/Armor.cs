using System.Collections.Generic;

namespace DarkHeresy.Models
{
    public class Armor
    {
        public Armor()
        {
            HeadCharacters = new HashSet<Character>();
            ChestCharacters = new HashSet<Character>();
            LeftArmCharacters = new HashSet<Character>();
            LeftLegCharacters = new HashSet<Character>();
            RightArmCharacters = new HashSet<Character>();
            RightLegCharacters = new HashSet<Character>();
        }

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

        public Availability Availability { get; set; }
        public Category Category { get; set; }

        public ICollection<Character> HeadCharacters { get; set; }
        public ICollection<Character> ChestCharacters { get; set; }
        public ICollection<Character> LeftArmCharacters { get; set; }
        public ICollection<Character> LeftLegCharacters { get; set; }
        public ICollection<Character> RightArmCharacters { get; set; }
        public ICollection<Character> RightLegCharacters { get; set; }
    }
}