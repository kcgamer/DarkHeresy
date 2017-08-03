using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkHeresy.Dtos
{
    public class CharacterSkillDto
    {
        public int CharacterId { get; set; }
        public int SkillId { get; set; }
        public bool IsBasic { get; set; }
        public bool IsTrained { get; set; }
        public bool IsTen { get; set; }
        public bool IsTwenty { get; set; }

        public SkillDto Skill { get; set; }

    }
}
