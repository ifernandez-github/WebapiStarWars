using System;
using System.Collections.Generic;

#nullable disable

namespace WebapiMaestros.Domain
{
    public partial class Ship
    {
        public Ship()
        {
            Weapons = new HashSet<Weapon>();
        }

        public int IdShip { get; set; }
        public int? IdArmy { get; set; }
        public string ShipName { get; set; }
        public int? Power { get; set; }

        public virtual Army IdArmyNavigation { get; set; }
        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}
