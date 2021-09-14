using System.Collections.Generic;
using WebapiMaestros.Models;

namespace WebapiMaestros.Services.Interfaces
{
   public interface IStarWarsService
   {
      public List<ArmyViewModel> GetArmies();
      public List<ShipViewModel> GetShips();
      public List<ShipViewModel> GetShipsByName(string nameShip);
      public ShipViewModel GetShipsById(int idShip);
   }
}


