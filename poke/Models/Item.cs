using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poke.Models
{
    public class Item
    {
        string name {get; set;}
        string description { get; set; }
        double weight { get; set; }

        public Item(string name, string description, double weight)
        {
            this.name = name;
            this.description = description;
            this.weight = weight;
        }
    }
}
