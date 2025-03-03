using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5a.Exception
{
    internal class BankAccExists:ApplicationException
    {
        public BankAccExists() { }

        public BankAccExists(string? message) : base(message)
        {
        }
    }
}
