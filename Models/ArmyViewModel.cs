using System;
using System.Collections.Generic;

#nullable disable

namespace WebapiMaestros.Models
{
    public partial class ArmyViewModel
    {
        public ArmyViewModel()
        {
            Ships = new HashSet<ShipViewModel>();
        }

        public int IdArmy { get; set; }
        public string ArmyName { get; set; }

        public virtual ICollection<ShipViewModel> Ships { get; set; }
    }
}
