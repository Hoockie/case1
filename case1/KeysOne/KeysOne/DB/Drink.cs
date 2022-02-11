using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KeysOne.Models
{
    public partial class Drink
    {
        public Drink()
        {
            VendingMachineDrinks = new HashSet<VendingMachineDrink>();
        }

        public int IdDrink { get; set; }
        public string Name { get; set; } = null!;
        public byte[]? Image { get; set; }
        public decimal Cost { get; set; }

        [JsonIgnore]
        public virtual ICollection<VendingMachineDrink> VendingMachineDrinks { get; set; }
    }
}
