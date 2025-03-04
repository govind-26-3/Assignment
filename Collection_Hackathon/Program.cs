using Collection_Hackathon.Interface;
using Collection_Hackathon.Repository;

namespace Collection_Hackathon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPolicy policy = new PolicyRepository();
            Console.WriteLine("Welcome To NeoPolicies :)\n");
            while (true)
            {
                Console.WriteLine("\n"+
                                  "Press 1 to Add policy\n\n" +
                                  "Press 2 to Delete policy\n\n" +
                                  "Press 3 to View All Policies\n\n" +
                                  "Press 4 to Update Policy\n\n" +
                                  "Press 5 to View Active Policies\n\n" +
                                  "Press 6 to View Policy\n\n"+
                                  "Press 7 to Exit\n\n");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        policy.AddPolicy();
                        break;
                    case 2:
                        Console.WriteLine("Enter Policy Id to Delete Policy");
                        int pId = Convert.ToInt32(Console.ReadLine());
                        policy.DeletePolicyById(pId);
                        break;
                    case 3:
                        policy.GetAllPolicies();
                        break;
                    case 4:
                        Console.WriteLine("Enter Policy Id to Update Policy");
                        int dId = Convert.ToInt32(Console.ReadLine());
                        policy.UpdatePolicyById(dId);
                        break;
                    case 5:
                        policy.ViewActivePolicy();
                        break;
                    case 6:
                        Console.WriteLine("Enter Policy Id to View Policy");
                        int getId = Convert.ToInt32(Console.ReadLine());
                        policy.GetPolicyById(getId);
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
