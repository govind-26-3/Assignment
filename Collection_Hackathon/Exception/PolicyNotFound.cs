using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_Hackathon.Exception
{
    internal class PolicyNotFound : ApplicationException
    {
        public PolicyNotFound(string? message) : base(message)
        {
        }
    }
}
