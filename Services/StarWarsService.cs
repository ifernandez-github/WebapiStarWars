using AutoMapper;
using System.Collections.Generic;
using WebapiMaestros.Data.Interfaces;
using WebapiMaestros.Models;
using WebapiMaestros.Services.Interfaces;

namespace WebapiMaestros.Services
{
   public class StarWarsService : IStarWarsService
   {

      private readonly IStarWarsData _starWarsData;
      private readonly IMapper _mapper;
      public StarWarsService(IMapper mapper, IStarWarsData starWarsData)
      {
         _starWarsData = starWarsData;
         _mapper = mapper;
      }

      public List<ArmyViewModel> GetArmies()
      {
         return _mapper.Map<List<ArmyViewModel>>(_starWarsData.GetArmies());
      }

      public List<ShipViewModel> GetShips()
      {
         return _mapper.Map<List<ShipViewModel>>(_starWarsData.GetShips());
      }

      public List<ShipViewModel> GetShipsByName(string nameShip)
      {
         return _mapper.Map<List<ShipViewModel>>(_starWarsData.GetShipsByName(nameShip));
      }

      public ShipViewModel GetShipsById(int idShip)
      {
         return _mapper.Map<ShipViewModel>(_starWarsData.GetShipsById(idShip));
      }
   }
}


