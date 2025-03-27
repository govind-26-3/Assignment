using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string PName { get; set; }
        public string Description { get; set; }

        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
