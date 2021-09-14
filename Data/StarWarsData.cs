using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebapiMaestros.Data.Interfaces;
using WebapiMaestros.Domain;

namespace WebapiMaestros.Data
{
   public class StarWarsData : IStarWarsData
   {
      private readonly StarWarsContext _db;
      public StarWarsData(StarWarsContext db)
      {
         _db = db;

      }

      public List<Army> GetArmies()
      {
         return _db.Armies
            .Include(x => x.Ships)
               .ThenInclude(x => x.Weapons).ToList();
      }

      public List<Ship> GetShipsByName(string shipName)
      {
         return _db.Ships.Where(s => s.ShipName.Contains(shipName))
            .Include(x => x.IdArmyNavigation).ToList();
      }

      public List<Ship> GetShips()
      {
         return _db.Ships.Include(x => x.IdArmyNavigation).ToList();
      }

      public Ship GetShipsById(int idShip)
      {
         return _db.Ships.Where(x => x.IdShip == idShip).Include(x => x.IdArmyNavigation).FirstOrDefault();
      }
   }
}
