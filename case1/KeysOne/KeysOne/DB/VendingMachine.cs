using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KeysOne.Models
{
    public partial class VendingMachine
    {
        public VendingMachine()
        {
            VendingMachineCoins = new HashSet<VendingMachineCoin>();
            VendingMachineDrinks = new HashSet<VendingMachineDrink>();
        }

        public int IdVendingMachine { get; set; }
        public string SecretCode { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<VendingMachineCoin> VendingMachineCoins { get; set; }
        [JsonIgnore]
        public virtual ICollection<VendingMachineDrink> VendingMachineDrinks { get; set; }
    }
}
