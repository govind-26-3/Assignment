using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6a.Model
{
    internal class Bank
    {
        Queue<Customer> customers = new();

        
        public int GetInQueue(Customer customer)
        {
            customers.Enqueue(customer);
            return customers.Count;

        }
       
        public void LeavingQueue()
        {
            Console.WriteLine("Customer Leaving");
            Customer lastPerson = customers.Dequeue();
            Console.WriteLine( $"Customer Name::{lastPerson.CustomerName}  Customer Id::{lastPerson.CustomerId}  Customer Token Number::{lastPerson.TokenId}");
        }
        public void NextPerson()
        {
            Console.WriteLine("Next person in queue is");
            Customer lastPerson = customers.Peek();
            Console.WriteLine( $"Customer Name::{lastPerson.CustomerName}  Customer Id::{lastPerson.CustomerId}  Customer Token Number::{lastPerson.TokenId}");
        }
    }
}
