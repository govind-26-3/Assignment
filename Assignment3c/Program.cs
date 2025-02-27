namespace Assignment3c
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("Enter the Password ::");
                string pass = Console.ReadLine();

                if ((pass.Length >= 6) && (pass.Any(char.IsUpper)) && pass.Any(char.IsDigit))
                {
                    Console.WriteLine("Welcome to App");

                    break;
                }
                else

                    Console.WriteLine("Password should contain atleast 6 characters,one UpperCase and one digit");

            }
        }
    }
}
