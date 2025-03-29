using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Domain
{
    public class Orders
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }               
        public int UserId { get; set; }          
        public DateTime OrderDate { get; set; }   
        public string Status { get; set; }         
        public decimal TotalAmount { get; set; }   
        public User User { get; set; }
    }
}
