using System;
using System.Collections.Generic;

namespace KeysOne.Models
{
    public partial class VendingMachineDrink
    {
        public int IdVendingMachineDrinks { get; set; }
        public int IdVendingMachine { get; set; }
        public int DrinksId { get; set; }
        public int Count { get; set; }

        public virtual Drink Drinks { get; set; } = null!;
        public virtual VendingMachine IdVendingMachineNavigation { get; set; } = null!;
    }
}
