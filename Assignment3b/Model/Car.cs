using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3b.Model
{
    internal class Car
    {
       private string cName;
       private string cType;
       private double cValue;


        public string carName
        {
            get { return cName; }
            set { cName = value; }
        }

        public string carType
        {
            get { return cType; }
            set { cType = value; }
        }
        public Car()
        {
            this.cName = "Unknown";
            this.cType = "Unknown";
            this.cValue = 0.0;
        }

        public double carValue
        {
            get { return cValue; }
            set { cValue = value; }
        }


        public Car(string name, string type, double value)
        {
            this.cName = name;
            this.cType = type;
            this.cValue = value;
        }



        public void Display()
        {
            Console.WriteLine($"Car Name:{carName}   Type:{carType}   Value:{carValue}");
        }

    }
}