using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6a.Model
{
    internal class Customer

    {
        public int TokenId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }


        public Customer(int id, string name)
        {

            CustomerId = id;
            CustomerName = name;

        }
        public void TokenNumber(Bank bank)
        {
            TokenId = bank.GetInQueue(this);
            Console.WriteLine($"Customer Name ::{CustomerName}  Customer Token Number:: {TokenId}");
        }

    }
}
