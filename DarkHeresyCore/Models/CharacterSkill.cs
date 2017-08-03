using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkHeresy.Models
{
    public class CharacterSkill
    {
        public int CharacterId { get; set; }
        public int SkillId { get; set; }
        public bool IsBasic { get; set; }
        public bool IsTrained { get; set; }
        public bool IsTen { get; set; }
        public bool IsTwenty { get; set; }
        
        public Skill Skill { get; set; }
        public Character Character { get; set; }
    }
}
