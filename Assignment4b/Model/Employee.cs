using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4b.Model
{
    internal class Employee
    {
        
        public string Name { get; set; }
        public int Salary { get; set; }

        public Employee(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }
        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Name of Employee ::{Name}  Salary of Employee::{Salary}");
        }
    }
}
