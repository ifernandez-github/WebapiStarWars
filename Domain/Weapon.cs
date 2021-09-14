using System;
using System.Collections.Generic;

#nullable disable

namespace WebapiMaestros.Domain
{
    public partial class Weapon
    {
        public int IdWeapon { get; set; }
        public int? IdShip { get; set; }
        public string WeaponName { get; set; }
        public int? Power { get; set; }

        public virtual Ship IdShipNavigation { get; set; }
    }
}
