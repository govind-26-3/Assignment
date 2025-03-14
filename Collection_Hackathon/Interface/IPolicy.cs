﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection_Hackathon.Model;

namespace Collection_Hackathon.Interface
{
    internal interface IPolicy
    {

        void AddPolicy();
        void GetAllPolicies();
        void DeletePolicyById(int pId);
        Policy GetPolicyById(int pId);

        void UpdatePolicyById(int pId);
        void SearchById(int id);


        List<Policy> ViewActivePolicy();

    }
}
