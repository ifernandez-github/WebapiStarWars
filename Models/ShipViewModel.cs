using System;
using System.Collections.Generic;

#nullable disable

namespace WebapiMaestros.Models
{
   public class ShipViewModel
   {
      public ShipViewModel()
      {
         //Weapons = new HashSet<WeaponViewModel>();
      }

      public int IdShip { get; set; }
      //public int? IdArmy { get; set; }
      //public string ArmyName { get; set; }
      public string ShipName { get; set; }
      public int? Power { get; set; }

      //public virtual ICollection<WeaponViewModel> Weapons { get; set; }
   }
}
