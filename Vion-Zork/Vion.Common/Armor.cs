using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Vion
{
    public class Armor : Item
    {
        public double damageThreshold { get; set; }

        public Armor(string name, double cost, ItemType itemType, double damageThreshold)
        {
            this.damageThreshold = damageThreshold;
            this.name = name;
            this.cost = cost;
            this.itemType = itemType;
            this.quantity = 1;
        }
    }
}