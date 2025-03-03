using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5b.Model
{
    internal class FourWheeler:Vehicle
    {
        public FourWheeler(int pNumber, double insuaranceAmount, string vehicleName) : base(pNumber, insuaranceAmount,vehicleName)
        {

        }
        public override string CalculatePremium()
        {
            return $"Premium Amount for Four-Wheeler::{InsuaranceAmount * .10}";
        }
    }
}
