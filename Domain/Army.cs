using System;
using System.Collections.Generic;

#nullable disable

namespace WebapiMaestros.Domain
{
    public partial class Army
    {
        public Army()
        {
            Ships = new HashSet<Ship>();
        }

        public int IdArmy { get; set; }
        public string ArmyName { get; set; }

        public virtual ICollection<Ship> Ships { get; set; }
    }
}
