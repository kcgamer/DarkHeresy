﻿using System;
using System.Collections.Generic;

namespace DarkHeresy.Models
{
    public  class Availability
    {
        public Availability()
        {
            Ammo = new HashSet<Ammo>();
            Armor = new HashSet<Armor>();
            Cybernetics = new HashSet<Cybernetic>();
            Gear = new HashSet<Gear>();
            MeleeWeapons = new HashSet<MeleeWeapon>();
            RangedWeapons = new HashSet<RangedWeapon>();
            Services = new HashSet<Service>();
            WeaponUpgrades = new HashSet<WeaponUpgrade>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public  ICollection<Ammo> Ammo { get; set; }
        public  ICollection<Armor> Armor { get; set; }
        public  ICollection<Cybernetic> Cybernetics { get; set; }
        public  ICollection<Gear> Gear { get; set; }
        public  ICollection<MeleeWeapon> MeleeWeapons { get; set; }
        public  ICollection<RangedWeapon> RangedWeapons { get; set; }
        public  ICollection<Service> Services { get; set; }
        public  ICollection<WeaponUpgrade> WeaponUpgrades { get; set; }
    }
}
