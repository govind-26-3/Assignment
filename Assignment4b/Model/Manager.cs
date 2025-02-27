using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4b.Model
{
    internal class Manager:Employee
    {
        public int Bonus { get; set; }

        public Manager(string name, int salary,int bonus):base( name, salary) 
        {
            Bonus = bonus;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Name of Employee ::{Name}  Salary of Employee::{Salary}  Bouns For Employee::{Bonus}");

        }
    }
}
