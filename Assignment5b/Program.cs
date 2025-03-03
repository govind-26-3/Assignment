using Assignment5b.Model;

namespace Assignment5b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle v1 = new TwoWheeler(1, 100000,"Splendor");
            Console.WriteLine(v1.CalculatePremium() );

            Vehicle v2 = new FourWheeler(2, 100000,"Ertiga");
            Console.WriteLine(v2.CalculatePremium());

            Vehicle v3 = new Commercial(3, 100000,"Waymo");
            Console.WriteLine(v3.CalculatePremium());

        }
    }
}
