using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Application.ViewModel.ProductViewModel
{
    public class AddProductViewModel
    {
        public string PName { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }
        public int Stock { get; set; }

        public string CategoryName { get; set; }

    }
}
