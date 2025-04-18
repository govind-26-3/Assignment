﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlHackathon.Exception;
using SqlHackathon.Model;
using SqlHackathon.Utility;
using static SqlHackathon.Constants.PolicTyp;

namespace SqlHackathon.Repository
{
    internal class PolicyRepository : IPolicy
    {
        
        string policyHolderName = "";
        PolicyType policyType;
        DateTime startDate;
        DateTime endDate;

        
        string connstring;
        SqlCommand cmd;

        public PolicyRepository()
        {
            cmd = new SqlCommand();
            connstring = DbConnUtil.GetConnectionString();

        }

        public int AddPolicy(Policy policy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                while (true)
                {
                    Console.Write("Enter Policy Holder Name: ");
                    policyHolderName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(policyHolderName))
                    {
                        break;
                    }
                    Console.WriteLine("Policy Holder Name cannot be empty.");
                }

                while (true)
                {
                    Console.WriteLine("Enter Policy Type (Life, Health, Vehicle, Property): ");
                    string policyTypeIn = Console.ReadLine();
                    if (Enum.TryParse(policyTypeIn, true, out policyType) && Enum.IsDefined(typeof(PolicyType), policyType))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid!! Please enter a valid policy type (Life, Health, Vehicle, Property).");
                }

                while (true)
                {
                    Console.Write("Enter Start Date (yyyy-MM-dd): ");
                    string startDateIn = Console.ReadLine();
                    if (DateTime.TryParse(startDateIn, out startDate))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid date format. Please enter a valid date in the format yyyy-MM-dd.");
                }

                while (true)
                {
                    Console.Write("Enter End Date (yyyy-MM-dd): ");
                    string endDateInput = Console.ReadLine();
                    if (DateTime.TryParse(endDateInput, out endDate) && endDate > startDate)
                    {
                        break;
                    }
                    Console.WriteLine("End date must be later than the start date. Please enter a valid end date.");
                }

                cmd.Parameters.Clear();

                cmd.CommandText = "INSERT INTO Policies VALUES ( @PolicyHolderName, @policyType, @StartTime, @EndTime)";


                cmd.Parameters.AddWithValue("@PolicyHolderName", policyHolderName);
                cmd.Parameters.AddWithValue("@policyType", (int)policyType);
                cmd.Parameters.AddWithValue("@StartTime", startDate);
                cmd.Parameters.AddWithValue("@EndTime", endDate);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                Console.WriteLine("Policy Added Successfully!");
                return cmd.ExecuteNonQuery();

            }
        }


        public int DeletePolicyById(int pId)
        {
            int res = 0;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connstring))
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "Delete from Policies where policyId=@PolicyId";
                    cmd.Parameters.AddWithValue("@PolicyId", pId);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    res = cmd.ExecuteNonQuery();
                    if (res == 0)
                    {
                        throw new PolicyNotFound("Policy does not exists!!!");
                    }
                    else
                    {
                        Console.WriteLine("Policy Deleted!!");

                    }
                }
            }
            catch (PolicyNotFound e)
            {
                Console.WriteLine(e.Message);
            }

            return res;
        }

        public List<Policy> GetAllPolicies()
        {
            List<Policy> policies = new List<Policy>();

            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                cmd.CommandText = "Select * from Policies";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Policy policy = new Policy();
                    policy.PolicyId = reader.GetInt32("PolicyId");
                    policy.PolicyHolderName = reader.GetString("PolicyHolderName");
                    policy.policyType = (PolicyType)reader.GetInt32("PolicyType");
                    policy.StartTime = reader.GetDateTime("StartTime");
                    policy.EndTime = reader.GetDateTime("EndTime");

                    policies.Add(policy);

                }

            }
            return policies;

        }

        public int UpdatePolicyById(int pId)
        {
            int res = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                cmd.Parameters.Clear();

                sqlConnection.Open();
                cmd.Connection = sqlConnection;

                using (SqlConnection sqlConn = new SqlConnection(connstring))

                {
                    cmd.CommandText = "SELECT COUNT(*) FROM Policies WHERE PolicyId = @PolicyId";
                    cmd.Parameters.AddWithValue("@PolicyId", pId);
                    int count = (int)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        Console.WriteLine($"Policy Id {pId} Not Found!");
                        return 0;
                    }
                }
                cmd.Parameters.Clear();

                string newPolicyHolderName;
                while (true)
                {
                    Console.Write("Enter New Policy Holder Name: ");
                    newPolicyHolderName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newPolicyHolderName))
                    {

                        break;
                    }
                    else
                    {
                        Console.WriteLine("Policy Holder Name cannot be empty. Please enter a valid name.");
                    }
                }

                PolicyType newPolicyType;
                while (true)
                {
                    Console.WriteLine("Enter New Policy Type (Life, Health, Vehicle, Property): ");
                    string policyTypeIn = Console.ReadLine();
                    if (Enum.TryParse(policyTypeIn, true, out newPolicyType) && Enum.IsDefined(typeof(PolicyType), newPolicyType))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid!! Please enter a valid policy type (Life, Health, Vehicle, Property).");
                }

                DateTime newEndDate;
                while (true)
                {
                    Console.Write("Enter New End Date (yyyy-MM-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out newEndDate) && newEndDate > DateTime.Now)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("End date must be later than the start date. Please enter a valid end date.");
                    }
                }


                cmd.CommandText = "UPDATE Policies SET PolicyHolderName = @PolicyHolderName, PolicyType = @PolicyType, EndTime = @EndTime WHERE PolicyId = @PolicyId";
                cmd.Parameters.AddWithValue("@PolicyId", pId);
                cmd.Parameters.AddWithValue("@PolicyType", (int)newPolicyType);
                cmd.Parameters.AddWithValue("@EndTime", newEndDate);
                cmd.Parameters.AddWithValue("@PolicyHolderName", newPolicyHolderName);
                
                res = cmd.ExecuteNonQuery();
                if (res == 1)
                {

                    Console.WriteLine("Policy Updated Successfully!");
                    return res;

                }
            }
            return res;
        }


    }
}
