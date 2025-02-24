namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {

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

            Console.WriteLine("Enter your email :");
            string email = Console.ReadLine();
            if (email == "")
            {
                Console.WriteLine("Email  can't be empty!!");
                email = Console.ReadLine();

            }

            Console.WriteLine($"Email :{email}");

            Console.WriteLine("Enter Patient discharge date :");


            string? date = Console.ReadLine();

            if (date != "")
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
