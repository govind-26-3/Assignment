namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
//Assignment 1 task 1
            Console.WriteLine("Enter name of the Student :");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age of the Student :");
            int age;
            bool res;
            res = int.TryParse(Console.ReadLine(), out age);

            if (!res)
            {
                Console.WriteLine("Enter a valid age!!!");
                res = int.TryParse(Console.ReadLine(), out age);

            }
            Console.WriteLine("Enter percentage of the Student :");

            double percentage = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($" Name :{name}    Age :{age}   Percentage :{percentage}%");
//Assignment 1 task 2
            Console.WriteLine("Enter your email :");
            string email = Console.ReadLine();
            if (email == "")
            {
                Console.WriteLine("Email  can't be empty!!");
                email = Console.ReadLine();

            }

            Console.WriteLine($"Email :{email}");
//Assignment 1 task 3
            Console.WriteLine("Enter Patient discharge date :");


            string input = Console.ReadLine();

            if (DateOnly.TryParse(input, out DateOnly date))
            {
                Console.WriteLine("Patient discharge date :" + date);

            }
            else
            {
                Console.WriteLine("Not Discharged");
            }

        }
    }
}
