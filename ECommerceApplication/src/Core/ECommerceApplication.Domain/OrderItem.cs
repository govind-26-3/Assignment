﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Domain
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }               
        public int OrderId { get; set; }          
        public Orders Order { get; set; }           
        public int ProductId { get; set; }        
       
        public Product Product { get; set; }
        public int Quantity { get; set; }          
    }
}
