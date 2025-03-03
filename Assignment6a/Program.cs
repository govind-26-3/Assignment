using System.Collections;
using Assignment6a.Model;

namespace Assignment6a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Customer c1 = new(101,"Raju");
            c1.TokenNumber(bank);
            Customer c2 = new(102,"Baburao");
            c2.TokenNumber(bank);
            Customer c3 = new(1033,"Shaam");
            c3.TokenNumber(bank);

            bank.LeavingQueue();
            bank.NextPerson();
            
            
            
        }
    }
}
