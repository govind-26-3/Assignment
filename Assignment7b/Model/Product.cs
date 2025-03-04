using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7b.Model
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public string Category { get; set; }
        public int Price { get; internal set; }
    }
}
