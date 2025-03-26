using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain
{
    public class Product
    {
        //Id, Name, Description, Price, Stock, CategoryId

        public int ProductId { get; set; }
        public string PName { get; set; }
        public string Description { get; set; }

        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }



    }
}
