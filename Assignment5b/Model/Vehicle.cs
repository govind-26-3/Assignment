using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5b.Model
{
    internal abstract class Vehicle
    {
        public int PolicyNumber { get; set; }

        public string VehicleName { get; set; }

        public double InsuaranceAmount { get; set; }

        public Vehicle(int pNumber, double insuaranceAmount, string vehicleName)
        {
            PolicyNumber = pNumber;
            InsuaranceAmount = insuaranceAmount;
            VehicleName = vehicleName;
        }

        public abstract string CalculatePremium();
    }
}
