using System;
using System.Collections.Generic;

namespace DarkHeresyCore.Models
{
    public  class Class
    {
        public Class()
        {
            MeleeWeapons = new HashSet<MeleeWeapon>();
            RangedWeapons = new HashSet<RangedWeapon>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public  ICollection<MeleeWeapon> MeleeWeapons { get; set; }
        public  ICollection<RangedWeapon> RangedWeapons { get; set; }
    }
}
