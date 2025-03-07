using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection_Hackathon.Exception;
using Collection_Hackathon.Interface;
using Collection_Hackathon.Model;
using static Collection_Hackathon.Model.Policy;

namespace Collection_Hackathon.Repository
{
    internal class PolicyRepository : IPolicy
    {
        List<Policy> policies = new List<Policy>() {
         new Policy(101,"Govind",PolicyType.Life,new DateTime(2025,12,21),new DateTime(2039,12,21))};
        private int policyID;
        string policyHolderName ="";
        PolicyType policyType;
        DateTime startDate;
        DateTime endDate;

        public void AddPolicy()
        {

                while (true)
                {
                    Console.Write("Enter Policy ID : ");
                    string policyIDInp = Console.ReadLine();
                    if (int.TryParse(policyIDInp, out policyID))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid Policy ID.");
                    }
                }
            Policy res = GetPolicyById(policyID);
            if (res == null)
            {

                while (true)
                {
                    Console.Write("Enter Policy Holder Name: ");
                    policyHolderName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(policyHolderName))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Policy Holder Name cannot be empty.");
                    }
                }


                while (true)
                {
                    Console.WriteLine("Enter Policy Type (Life, Health, Vehicle, Property): ");
                    string policyTypeIn = Console.ReadLine();
                    if (Enum.TryParse(policyTypeIn, true, out policyType) && Enum.IsDefined(typeof(PolicyType), policyType))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid!! Please enter a valid policy type From Life, Health, Vehicle, Property.");
                    }
                }

                while (true)
                {
                    Console.Write("Enter Start Date (yyyy-MM-dd): ");
                    string startDateIn = Console.ReadLine();
                    if (DateTime.TryParse(startDateIn, out startDate))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please enter a valid date in the format yyyy-MM-dd.");
                    }
                }

                while (true)
                {
                    Console.Write("Enter End Date (yyyy-MM-dd): ");
                    string endDateInput = Console.ReadLine();
                    if (DateTime.TryParse(endDateInput, out endDate) && endDate > startDate)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("End date must be later than the start date. Please enter a valid end date.");
                    }
                }
                Console.WriteLine("Policy Added Successfully");
                policies.Add(new Policy(policyID,policyHolderName,policyType,startDate,endDate));
            }
            else
            {
                Console.WriteLine($"Policy Id::{policyID} Already Exists!!!");
            }
        }

        public void DeletePolicyById(int pId)
        {
            try
            {
                Policy res = GetPolicyById(pId);



                if (res == null)
                {
                    throw new PolicyNotFound("Policy does not exists!!!");
                }
                else
                {
                    Console.WriteLine("Do you really want to delete Policy ?\n" +
                        "press 1 to Delete.\n"
                        );

                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        policies.Remove(res);

                        Console.WriteLine("Policy Deleted Successfully");
                    }


                }
            } catch(PolicyNotFound e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void GetAllPolicies()

        {
            if (policies.Count ==0)
            {
                Console.WriteLine("No data available");
                return;
            }

            Console.WriteLine("\n");
            foreach (var item in policies)
            {
                Console.WriteLine($"Policy id :{item.PolicyId}    Policy Holder Name :{item.PolicyHolderName}   Policy Type :{item.policyType}   Policy Start date :{item.StartTime:yyyy-mm-dd}Date :{item.EndTime:yyyy-mm-dd}");
            }
        }

        //public void SearchPolicyById(int pId)
        //{
        //    var sPolicy=policies.Where(p=>p.PolicyId==pId);
        //    foreach (var item in sPolicy)
        //    {
        //        Console.WriteLine($"Policy id :{item.PolicyId}    Policy Holder Name :{item.PolicyHolderName}   Policy Type :{item.policyType}   Policy Start date :{item.StartTime}   Policy End Date :{item.EndTime}  \n");

        //    }
        //}
        public void SearchById(int id)
        {
           
                if (GetPolicyById(id) != null)
                {
                    var search = policies.Where(p => p.PolicyId == id);
                    foreach (var sp in search)
                    {

                        Console.WriteLine($"Policy Id:{sp.PolicyId}\t Policy Holder Name:{sp.PolicyHolderName}\tPolicy Type:{sp.policyType}\t Start Date:{sp.StartTime:yyyy-MM-dd}\tEnd Date:{sp.EndTime:yyyy-MM-dd}");
                    }

                }
                else
                {
                    throw new PolicyNotFound($"Policy Id:{id} is not Found!!");
                }
            


        }

        public Policy GetPolicyById(int pId)
        {
            
            return policies.Find(p => p.PolicyId == pId);

        }

        public void UpdatePolicyById(int pId)
        {
            Policy res = GetPolicyById(pId);

            if (res != null)
            {
                while (true)
                {
                    Console.Write("Enter New Policy Holder Name: ");
                    string newPolicyHolderName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newPolicyHolderName))
                    {
                        res.PolicyHolderName = newPolicyHolderName;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Policy Holder Name cannot be empty. Please enter a valid name.");
                    }
                }

                Console.WriteLine("Enter New Policy Type (Life, Health, Vehicle, Property): ");
                if (Enum.TryParse(Console.ReadLine(), true, out PolicyType newPolicyType) && Enum.IsDefined(typeof(PolicyType), newPolicyType))
                {
                    res.policyType = newPolicyType;
                }

                while (true)
                {
                    Console.Write("Enter New Start Date (yyyy-MM-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime newStartDate))
                    {
                        res.StartTime = newStartDate;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please enter a valid date in the format yyyy-MM-dd.");
                    }
                }

                while (true)
                {
                    Console.Write("Enter New End Date (yyyy-MM-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime newEndDate) && newEndDate > res.StartTime)
                    {
                        res.EndTime = newEndDate;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("End date must be later than the start date. Please enter a valid end date.");
                    }
                }

                Console.WriteLine("Policy Updated Successfully!");
            }
            else
            {
                Console.WriteLine($"Policy Id::{pId} Not Found!!!");
            }

        }

        public List<Policy> ViewActivePolicy()
        {
            DateTime currentDate = DateTime.Now;
            return policies.FindAll(p => p.StartTime <= currentDate && p.EndTime >= currentDate);
        }
    }
}
