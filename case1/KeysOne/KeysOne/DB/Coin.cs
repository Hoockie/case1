using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KeysOne.Models
{
    public partial class Coin
    {
        public Coin()
        {
            VendingMachineCoins = new HashSet<VendingMachineCoin>();
        }

        public int IdCoin { get; set; }
        public int Denomination { get; set; }

        [JsonIgnore]
        public virtual ICollection<VendingMachineCoin> VendingMachineCoins { get; set; }
    }
}
