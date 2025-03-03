using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5b.Model
{
    internal class TwoWheeler:Vehicle
    {
        public TwoWheeler(int pNumber, double insuaranceAmount, string vehicleName) : base(pNumber, insuaranceAmount, vehicleName)
        {

        }
        public override string CalculatePremium()
        {
            return $"Premium Amount for Two-Wheeler::{InsuaranceAmount * .5}";
        }
    }
}
