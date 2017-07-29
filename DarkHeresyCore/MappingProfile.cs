using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DarkHeresyCore.Dtos;
using DarkHeresyCore.Models;

namespace DarkHeresyCore
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

        }
    }
}
