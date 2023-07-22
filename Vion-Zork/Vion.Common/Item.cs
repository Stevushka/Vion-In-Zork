using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Vion
{
    public abstract class Item
    {

        public string name { get; set; }

        public double cost { get; set; }

        public int quantity { get; set; }

        public ItemType itemType { get; set; }

        public Item(string name, double cost, ItemType itemType, int quantity)
        {
            this.name = name;
            this.cost = cost;
            this.itemType = itemType;
            this.quantity = quantity;
        }
    }
}