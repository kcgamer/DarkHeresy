using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkHeresy.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Stat { get; set; }
        public string Description { get; set; }

        public ICollection<CharacterSkill> CharacterSkills { get; set; }
    }
}
