using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECommerceApplication.Domain
{
    public class CartItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartItemId { get; set; }
        public string UserId { get; set; }            
        public int ProductId { get; set; }        
        public Product Product { get; set; }
        public int Quantity { get; set; }          

       
    }
}
