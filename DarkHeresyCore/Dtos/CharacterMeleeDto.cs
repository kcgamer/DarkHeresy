using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkHeresy.Dtos
{
    public class CharacterMeleeDto
    {
        public int CharacterId { get; set; }
        public int MeleeWeaponId { get; set; }

        public MeleeWeaponDto MeleeWeapon { get; set; }

    }
}
