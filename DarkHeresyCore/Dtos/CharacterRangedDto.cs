using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkHeresy.Dtos
{
    public class CharacterRangedDto
    {
        public int CharacterId { get; set; }
        public int RangedWeaponId { get; set; }

        public RangedWeaponDto RangedWeapon { get; set; }
    }
}
