using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SqlHackathon.Constants.PolicTyp;

namespace SqlHackathon.Model
{
    internal class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyHolderName { get; set; }
        public PolicyType policyType { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        //public Policy(int pId, string pHolderName, PolicyType pType, DateTime sDate, DateTime eDate)
        //{
        //    PolicyId = pId;
        //    PolicyHolderName = pHolderName;
        //    policyType = pType;
        //    StartTime = sDate;
        //    EndTime = eDate;
        //}

        public override string ToString()
        {
            return $"PolicyId:{PolicyId}\tPolicy Holder Name:{PolicyHolderName}\tPolicy Type:{ policyType}\tStartTime:{StartTime}\tEndTime:{EndTime}";
        }

    }
}
