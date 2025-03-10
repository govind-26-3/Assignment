using SqlHackathon.Model;
using SqlHackathon.Repository;

namespace SqlHackathon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPolicy policy = new PolicyRepository();
            Console.WriteLine("Welcome To NeoPolicies :)\n");
            while (true)
            {
                Console.WriteLine("\n" +
                                  "Press 1 to Add policy\n\n" +
                                  "Press 2 to Delete policy\n\n" +
                                  "Press 3 to View All Policies\n\n" +
                                  "Press 4 to Update Policy\n\n" +
                                  "Press 6 to View Policy\n\n" +
                                  "Press 7 to Exit\n\n");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        policy.AddPolicy(new Policy());
                        break;
                    case 2:
                        Console.WriteLine("Enter Policy Id to Delete Policy");
                        int pId = Convert.ToInt32(Console.ReadLine());
                        policy.DeletePolicyById(pId);
                        break;
                    case 3:
                        List<Policy> allPolicies = policy.GetAllPolicies();
                        foreach (Policy item in allPolicies)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 4:
                        //Console.WriteLine("Enter Policy Id to Update Policy");
                        //int dId = Convert.ToInt32(Console.ReadLine());
                        //policy.UpdatePolicyById(dId);
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
