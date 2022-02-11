using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KeysOne.Models
{
    public partial class VendingMachineCoin
    {
        public int IdVendingMachineCoins { get; set; }
        public int IdVendingMachine { get; set; }
        public int IdCoin { get; set; }
        public int Count { get; set; }
        public int IsActive { get; set; }

        public virtual Coin IdCoinNavigation { get; set; }
        public virtual VendingMachine IdVendingMachineNavigation { get; set; }
    }
}
