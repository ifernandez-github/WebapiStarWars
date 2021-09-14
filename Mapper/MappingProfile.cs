using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebapiMaestros.Domain;
using WebapiMaestros.Models;

namespace WebapiMaestros.Mapper
{
   public class MappingProfile : Profile
   {
      public MappingProfile()
      {
         CreateMap<Ship, ShipViewModel>()
            //.ForMember(p => p.Weapons,
            // opts => opts.MapFrom(source => source.Weapons))
            //.ForPath(p => p.ArmyName,
            // opts => opts.MapFrom(source => source.IdArmyNavigation.ArmyName))
            .ReverseMap();

         CreateMap<Army, ArmyViewModel>()
            .ForMember(p => p.Ships,
             opts => opts.MapFrom(source => source.Ships))
            .ReverseMap();

         CreateMap<Weapon, WeaponViewModel>()
            .ReverseMap();
      }

      

   }
}
