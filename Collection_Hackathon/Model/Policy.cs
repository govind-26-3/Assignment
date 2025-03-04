using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_Hackathon.Model
{
    internal class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyHolderName { get; set; }

        public enum PolicyType
        {
            Life, Health, Vehicle, Property
        }

        public PolicyType policyType { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Policy(int pId, string pHolderName, PolicyType pType, DateTime sDate, DateTime eDate)
        {
            PolicyId = pId;
            PolicyHolderName = pHolderName;
            policyType = pType;
            StartTime = sDate;
            EndTime = eDate;
        }

    }
}
