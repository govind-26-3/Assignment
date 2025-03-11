using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlHackathon.Model;

namespace SqlHackathon.Repository
{
    internal interface IPolicy
    {
        int AddPolicy(Policy policy);
        List<Policy> GetAllPolicies();
        int DeletePolicyById(int pId);
            //Policy GetPolicyById(int pId);

            int UpdatePolicyById(int pId);
    }
}
