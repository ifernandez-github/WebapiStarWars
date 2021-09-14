using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebapiMaestros.Domain;

namespace WebapiMaestros.Data.Interfaces
{
   public interface IStarWarsData
   {
      public List<Army> GetArmies();
      public List<Ship> GetShips();
      public List<Ship> GetShipsByName(string nameShip);
      public Ship GetShipsById(int idShip);
   }
}
