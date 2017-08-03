using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DarkHeresy.Dtos;
using DarkHeresy.Models;

namespace DarkHeresy
{
    public class MappingProfile : Profile

    {
        public MappingProfile()
        {
            // Domain to Dto
            CreateMap<Ammo, AmmoDto>();
            CreateMap<Armor, ArmorDto>();
            CreateMap<Availability, AvailabilityDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Class, ClassDto>();
            CreateMap<Cybernetic, CyberneticDto>();
            CreateMap<Gear, GearDto>();
            CreateMap<MeleeWeapon, MeleeWeaponDto>();
            CreateMap<RangedWeapon, RangedWeaponDto>();
            CreateMap<Service, ServiceDto>();
            CreateMap<Source, SourceDto>();
            CreateMap<WeaponUpgrade, WeaponUpgradeDto>();
            CreateMap<Character, CharacterDto>();
            CreateMap<Skill, SkillDto>();

            //Dto to Domain
            CreateMap<AmmoDto, Ammo>();
            CreateMap<ArmorDto, Armor>();
            CreateMap<AvailabilityDto, Availability>();
            CreateMap<CategoryDto, Category>();
            CreateMap<ClassDto, Class>();
            CreateMap<CyberneticDto, Cybernetic>();
            CreateMap<GearDto, Gear>();
            CreateMap<MeleeWeaponDto, MeleeWeapon>();
            CreateMap<RangedWeaponDto, RangedWeapon>();
            CreateMap<ServiceDto, Service>();
            CreateMap<SourceDto, Source>();
            CreateMap<WeaponUpgradeDto, WeaponUpgrade>();
            CreateMap<CharacterDto, Character>();
            CreateMap<SkillDto, Skill>();

        }
    }
}
