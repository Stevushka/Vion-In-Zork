using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Vion
{
    public class Weapon : Item
    {
        public double damage { get; set; }

        public double hitChance { get; set; }

        public Weapon(string name, double cost, double damage, double hitChance)
        {
            this.damage = damage;
            this.hitChance = hitChance;
            this.name = name;
            this.cost = cost;
            this.itemType = ItemType.WEAPON;
            this.quantity = 1;
        }
    }
}