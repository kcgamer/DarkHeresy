using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DarkHeresy.Models;

namespace DarkHeresy.Models
{
    public class CharacterMelee
    {
        public int CharacterId { get; set; }
        public int MeleeWeaponId { get; set; }

        public Character Character { get; set; }
        public MeleeWeapon MeleeWeapon { get; set; }
    }
}
