using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DarkHeresy.Models;

namespace DarkHeresy.Models
{
    public class CharacterRanged
    {
        public int CharacterId { get; set; }
        public int RangedWeaponId { get; set; }

        public Character Character { get; set; }
        public RangedWeapon RangedWeapon { get; set; }
    }
}
