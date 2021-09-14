using System;
using System.Collections.Generic;

#nullable disable

namespace WebapiMaestros.Models
{
    public class WeaponViewModel
   {
        public int IdWeapon { get; set; }
        public int? IdShip { get; set; }
        public string WeaponName { get; set; }
        public int? Power { get; set; }

    }
}
